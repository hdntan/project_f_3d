using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    protected void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
