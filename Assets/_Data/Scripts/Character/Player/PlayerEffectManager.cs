using UnityEngine;

public class PlayerEffectManager : CharacterEffectManager
{
    [Header("Debug delete later")]
    [SerializeField] InstantCharacterEffect effectToTest;
    public bool isTakeEffect = false;

    public void Update()
    {
        if(this.isTakeEffect)
        {
            InstantCharacterEffect newEffect = Instantiate(this.effectToTest);
            this.ProcessInstantEffect(newEffect);
            this.isTakeEffect = false;

        }
    }
}
