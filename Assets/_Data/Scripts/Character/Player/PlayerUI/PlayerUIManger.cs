using UnityEngine;

public class PlayerUIManger : MonoBehaviour
{
    public static PlayerUIManger instance;

    public PlayerUIHudManager hudManager;
    public PlayerUIPopUpManager popUpManager;
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

    private void Start()
    {
      
    }

}
