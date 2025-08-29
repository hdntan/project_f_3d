using UnityEngine;

public class PlayerManager : CharacterManager
{
    [SerializeField] protected PlayerLocomotionManager playerLocomotionManager;
    protected override void Awake()
    {
        base.Awake();
        this.playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        PlayerCamera.instance.player = this;
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

  

}
