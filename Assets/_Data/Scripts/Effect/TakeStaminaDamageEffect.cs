using UnityEngine;

[CreateAssetMenu(menuName = "Character Effect/ Instant Effect/ Take Stamina Damage")]
public class TakeStaminaDamageEffect : InstantCharacterEffect
{
    public float staminaDamage;

    public override void ProcessEffecr(CharacterManager character)
    {
        this.CalculateStaminaDamage(character);
    }

    private void CalculateStaminaDamage(CharacterManager character)
    {
        Debug.Log("Stamina Damage" + " " + this.staminaDamage);
        character.characterStatusManager.currentStamina -= this.staminaDamage;
        PlayerUIManger.instance.hudManager.SetNewStaminaValue(character.characterStatusManager.currentStamina);

    }

}
