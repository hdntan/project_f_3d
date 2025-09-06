using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class CharacterManager : NetworkBehaviour
{
    public CharacterController characterController;
    public Animator animator;
     [Header("Player Settings")]
    public string characterName = "CharacterName";

    [Header("Flags")]
    public bool isPerformingAction = false;
    public bool applyRootMotion = false;
    public bool canRotate = true;
    public bool canMove = true;




    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
        this.characterController = GetComponent<CharacterController>();
        this.animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void LateUpdate()
    {

    }



  
}
