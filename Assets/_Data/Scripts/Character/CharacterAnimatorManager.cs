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
}
