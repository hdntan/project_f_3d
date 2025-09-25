using System.Collections;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class CharacterManager : NetworkBehaviour
{
    public CharacterController characterController;
    public CharacterStatusManager characterStatusManager;

    public CharacterEffectManager characterEffectManager;
    public CharacterAnimatorManager characterAnimatorManager;
    public Animator animator;
     [Header("Player Settings")]
    public string characterName = "CharacterName";

    [Header("Flags")]
    public bool isPerformingAction = false;
    public bool isJumping = false;
    public bool isSprinting = false;


    public bool isGrounded = true;

    public bool applyRootMotion = false;
    public bool canRotate = true;
    public bool canMove = true;




    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
        this.characterController = GetComponent<CharacterController>();
        this.characterStatusManager = GetComponent<CharacterStatusManager>();
        this.characterEffectManager = GetComponent<CharacterEffectManager>();
        this.characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        this.animator = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
     
    }

    protected virtual void Update()
    {
        this.animator.SetBool("isGrounded", this.isGrounded);
    }

    protected virtual void LateUpdate()
    {

    }


    public virtual IEnumerator ProcessDeathEvent(bool manuallySelectDeathAnimation = false)
    {
        this.characterStatusManager.currentHealth = 0;
        this.characterStatusManager.isDead = true;
        if (!manuallySelectDeathAnimation)
        {
            this.characterAnimatorManager.PlayTargetActionAnimation("Death_01", true);
        }

        yield return new WaitForSeconds(5);
    }

    public virtual void ReviveCharacter()
    {
       
    }


  
}
