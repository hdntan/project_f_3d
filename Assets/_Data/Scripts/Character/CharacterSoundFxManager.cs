using UnityEngine;

public class CharacterSoundFxManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    protected virtual void Awake()
    {


        this.audioSource = GetComponent<AudioSource>();

    }
   
   public void PlayRollSoundFX()
    {
        this.audioSource.PlayOneShot(WorldSoundFxManager.instance.roolFx);
    }
}
