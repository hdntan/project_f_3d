using UnityEngine;

public class PlayerManager : CharacterManager
{
    [SerializeField] protected PlayerLocomotionManager playerLocomotionManager;
    protected override void Awake()
    {
        base.Awake();
        this.playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
    }

    protected override void Update()
    {
        base.Update();
        //handle player movement
        this.playerLocomotionManager.HandleAllMovement();
    }
}
