using Unity.Netcode;
using UnityEngine;

public class CharacterManager : NetworkBehaviour
{
    public CharacterController characterController;
    public Animator animator;
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
