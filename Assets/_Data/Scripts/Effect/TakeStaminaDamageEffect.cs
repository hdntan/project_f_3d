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
      if(character.characterStatusManager.currentHealth <= 0)
        {
            character.characterStatusManager.currentHealth = 0;
            return;
        }
        character.characterStatusManager.currentStamina -= this.staminaDamage;
        character.characterStatusManager.currentHealth -= this.staminaDamage;

       // PlayerUIManger.instance.hudManager.SetNewStaminaValue(character.characterStatusManager.currentStamina);

    }

}
