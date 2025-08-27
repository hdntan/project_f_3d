using UnityEngine;

public class PlayerLocomotionManager : CharacterLocomotionManager
{
    [SerializeField] private PlayerManager player;

    public float verticalMovement;
    public float horizontalMovement;
    public float moveAmount;

    public float walkingSpeed = 2f;
    public float runningSpeed = 5f;

    public float rotationSpeed = 15f;

    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 targetRotationDirection;
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
        this.HandleGetMovementInput();
        this.moveDirection = PlayerCamera.instance.transform.forward * this.verticalMovement;
        this.moveDirection += PlayerCamera.instance.transform.right * this.horizontalMovement;
        this.moveDirection.Normalize();
        this.moveDirection.y = 0;

        if (PlayerInputManager.instance.moveAmount > 0)
        {
            //move at a run speed
            this.player.characterController.Move(this.moveDirection * this.runningSpeed * Time.deltaTime);
        }
        else
        {
            //move at a walk speed
            this.player.characterController.Move(this.moveDirection * this.walkingSpeed * Time.deltaTime);
        }
    }

    protected virtual void HandleRotation()
    {
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
    
    
}
