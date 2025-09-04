using UnityEngine;

public class PlayerUIManger : MonoBehaviour
{
    public static PlayerUIManger instance;

    public PlayerUIHudManager hudManager;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

}
