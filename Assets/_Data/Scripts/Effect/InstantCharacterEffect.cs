using UnityEngine;

public class InstantCharacterEffect : ScriptableObject
{
    [Header("Effect Id")]
    public int instantEffectId;

    public virtual void ProcessEffecr(CharacterManager character)
    {
        //override
    }
}
