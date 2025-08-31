using NUnit.Framework;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    public PlayerLocomotionManager playerLocomotionManager;
    public PlayerAnimatorManager playerAnimatorManager;
    protected override void Awake()
    {
        base.Awake();
           this.playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        this.playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
     
       
    }


    protected override void Update()
    {
        base.Update();
        //handle player movement
        this.playerLocomotionManager.HandleAllMovement();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        //handle camera movement
        PlayerCamera.instance.HandleAllCameraAction();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            PlayerInputManager.instance.player = this;
            PlayerCamera.instance.player = this;    
           
        }
       
    }

}
