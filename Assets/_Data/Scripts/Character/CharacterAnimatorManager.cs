using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    CharacterManager character;

    protected virtual void Awake()
    {
        this.character = GetComponent<CharacterManager>();
    }
    public void UpdateAnimatorMovementParameters(float horizontalMovement, float verticalMovement)
    {
        character.animator.SetFloat("Horizontal", horizontalMovement, 0.1f, Time.deltaTime);

        character.animator.SetFloat("Vertical", verticalMovement, 0.1f, Time.deltaTime);
    }

    public virtual void PlayTargetActionAnimation(string targetAnim,
    bool isPerformingAction,
    bool applyRootMotion = true,
    bool canRotate = false,
    bool canMove = false)

    {
        this.character.applyRootMotion = applyRootMotion;
        this.character.animator.CrossFade(targetAnim, 0.2f);
        this.character.isPerformingAction = isPerformingAction;
        this.character.canRotate = canRotate;
        this.character.canMove = canMove;
    }
  
}
 