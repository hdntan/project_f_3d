using UnityEngine;

public class WorldSoundFxManager : MonoBehaviour
{
    public static WorldSoundFxManager instance;
    public AudioClip roolFx;

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
