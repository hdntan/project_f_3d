using UnityEngine;

public class PlayerLocomotionManager : CharacterLocomotionManager
{
    [SerializeField] private PlayerManager player;

    public float verticalMovement;
    public float horizontalMovement;
    public float moveAmount;
    [Header("Movement Settings")]
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 targetRotationDirection;
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 4.5f;

    public float sprintingSpeed = 6.5f;
    public float rotationSpeed = 15f;
    public float sprintingStaminaCost = 2;

    [Header("Dodge")]
    [SerializeField] private Vector3 rollDirection;


    protected override void Awake()
    {
        base.Awake();
        this.player = GetComponent<PlayerManager>();
    }

    public void HandleAllMovement()
    {
        this.HandleGroundMovement();
        this.HandleRotation();

    }

    private void HandleGetMovementInput()
    {
        this.verticalMovement = PlayerInputManager.instance.verticalInput;
        this.horizontalMovement = PlayerInputManager.instance.horizontalInput;

    }

    protected virtual void HandleGroundMovement()
    {
        if (!this.player.canMove)
            return;
        this.HandleGetMovementInput();
        this.moveDirection = PlayerCamera.instance.transform.forward * this.verticalMovement;
        this.moveDirection += PlayerCamera.instance.transform.right * this.horizontalMovement;
        this.moveDirection.Normalize();
        this.moveDirection.y = 0;
        if (PlayerInputManager.instance.sprintInput)
        {
             this.player.characterController.Move(this.moveDirection * this.sprintingSpeed * Time.deltaTime);
        }
        else
        {

        if (PlayerInputManager.instance.moveAmount > 0.5f)
        {
            //move at a run speed
            this.player.characterController.Move(this.moveDirection * this.runningSpeed * Time.deltaTime);
        }
        else if (PlayerInputManager.instance.moveAmount <= 0.5f)
        {
            //move at a walk speed
            this.player.characterController.Move(this.moveDirection * this.walkingSpeed * Time.deltaTime);
        }
        }
    }

    protected virtual void HandleRotation()
    {
        if (!this.player.canRotate)
            return;
        this.targetRotationDirection = PlayerCamera.instance.cameraObject.transform.forward * this.verticalMovement;
        this.targetRotationDirection += PlayerCamera.instance.cameraObject.transform.right * this.horizontalMovement;
        targetRotationDirection.Normalize();
        targetRotationDirection.y = 0;

        if (this.targetRotationDirection == Vector3.zero)
        {
            this.targetRotationDirection = transform.forward;
        }
        Quaternion newRotation = Quaternion.LookRotation(this.targetRotationDirection);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, this.rotationSpeed * Time.deltaTime);
        transform.rotation = targetRotation;
    }

    public void AttemptToPerformDodge()
    {
        if (this.player.isPerformingAction)
            return;
        if (PlayerInputManager.instance.moveAmount > 0)
        {
            this.rollDirection = PlayerCamera.instance.transform.forward * PlayerInputManager.instance.verticalInput;
            this.rollDirection += PlayerCamera.instance.transform.right * PlayerInputManager.instance.horizontalInput;
            this.rollDirection.Normalize();
            this.rollDirection.y = 0;

            Quaternion playerRotation = Quaternion.LookRotation(this.rollDirection);
            this.player.transform.rotation = playerRotation;

            //perform a roll animation
            this.player.playerAnimatorManager.PlayTargetActionAnimation("Roll_Forward_01", true, true);
        }

        else
        {
            this.player.playerAnimatorManager.PlayTargetActionAnimation("Back_Step_01", true, true);
            //perform a backstep animation
        }
    }

    public void HandleSprinting()
    {
        if (this.player.isPerformingAction)
        {
            PlayerInputManager.instance.sprintInput = false;
        }
        if (this.player.playerStatsManager.currentStamina <= 0)
        {
            PlayerInputManager.instance.sprintInput = false;
            return;
        }
        // if (PlayerInputManager.instance.moveAmount  > 0.5f)
        // {
        //     PlayerInputManager.instance.sprintInput = false;
        // }
        // else
        // {
        //     PlayerInputManager.instance.sprintInput = false;
        // }
        if(PlayerInputManager.instance.sprintInput)
        {
            this.player.playerStatsManager.currentStamina -= this.sprintingStaminaCost * Time.deltaTime;
            Debug.Log("Stamina: " + this.player.playerStatsManager.currentStamina);
            PlayerUIManger.instance.hudManager.SetNewStaminaValue(this.player.playerStatsManager.currentStamina);
        }
    }
    
    
}
