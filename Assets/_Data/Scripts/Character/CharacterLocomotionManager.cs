using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterLocomotionManager : MonoBehaviour
{
   [SerializeField] protected CharacterManager character;

   [Header("Ground check & jumping")]
   [SerializeField] protected float gravityForce = -40f;
   [SerializeField] protected LayerMask groundLayer;
   [SerializeField] protected float groundCheckSphereRadius = 1;
   [SerializeField] protected Vector3 yVelocity;
   [SerializeField] protected float groundedYVelocity = -20;
   [SerializeField] protected float fallStartYVelocity = -5;
   [SerializeField] protected bool fallingVelocityHasBeenSet = false;
   [SerializeField] protected float inAirTimer = 0;


   protected virtual void Awake()
   {
      this.character = GetComponent<CharacterManager>();
   }

   protected virtual void Update()
   {
      this.HandleGroundCheck();
      if (this.character.isGrounded)
      {
         //if we are not attempting to jump or move upward
         if (this.yVelocity.y < 0)
         {
            this.inAirTimer = 0;
            this.fallingVelocityHasBeenSet = false;
            this.yVelocity.y = this.groundedYVelocity;
         }
      }
      else
      {
         // if we are not jumping, and our falling velocity has not been set
         if (!character.isJumping && !this.fallingVelocityHasBeenSet)
         {
            this.fallingVelocityHasBeenSet = true;
            this.yVelocity.y = this.fallStartYVelocity;
         }
         this.inAirTimer += Time.deltaTime;
         this.character.animator.SetFloat("inAirTimer", this.inAirTimer);
         this.yVelocity.y += this.gravityForce * Time.deltaTime;

         this.character.characterController.Move(this.yVelocity * Time.deltaTime);
      }

      //there should always be some force applied to the y vecolity

      this.character.characterController.Move(this.yVelocity * Time.deltaTime);

      
   }

   protected virtual void HandleGroundCheck()
   {
      this.character.isGrounded = Physics.CheckSphere(this.character.transform.position, this.groundCheckSphereRadius, this.groundLayer);

   }
   protected virtual void OnDrawGizmosSelected()
   {
      Gizmos.DrawSphere(this.character.transform.position, this.groundCheckSphereRadius);
   }
}

