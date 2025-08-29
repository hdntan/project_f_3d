using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterController characterController;
    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
        this.characterController = GetComponent<CharacterController>();
    }

    protected virtual void Update()
    {

    }
    
    protected virtual void LateUpdate()
    {

    }
}
