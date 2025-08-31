using UnityEngine;

public class PlayerAnimatorManager : CharacterAnimatorManager
{
    PlayerManager player;

    protected override void Awake()
    {
        base.Awake();
        this.player = GetComponent<PlayerManager>();
    }

    private void OnAnimatorMove()
    {
        if (this.player.applyRootMotion)
        {
            Vector3 vecolity = this.player.animator.deltaPosition;
            this.player.characterController.Move(vecolity);
            this.player.transform.rotation *= this.player.animator.deltaRotation;
        }   
    }

}
