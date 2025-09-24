using System.Collections.Generic;
using UnityEngine;

public class WorldCharacterEffectManager : MonoBehaviour
{
    public static WorldCharacterEffectManager instance;

    [SerializeField] List<InstantCharacterEffect> instantEffects;

    [Header("Damage Effect")]
    public TakeDamageEffect takeDamageEffect;

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
        this.GenerateEffectIds();
    }
    private void GenerateEffectIds()
    {
        for(int i = 0; i < this.instantEffects.Count; i++)
        {
            this.instantEffects[i].instantEffectId = i;
        }
    }
}
