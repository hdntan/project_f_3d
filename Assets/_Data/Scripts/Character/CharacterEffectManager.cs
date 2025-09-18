using UnityEngine;

public class CharacterEffectManager : MonoBehaviour
{
    CharacterManager character;

    protected virtual void Awake()
    {
        this.character = GetComponent<CharacterManager>();
    }
    public virtual void ProcessInstantEffect(InstantCharacterEffect effect)
    {
        effect.ProcessEffecr(this.character);
    }
}
