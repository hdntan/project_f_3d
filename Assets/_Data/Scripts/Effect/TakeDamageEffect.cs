using UnityEngine;

[CreateAssetMenu(menuName = "Character Effect/ Instant Effect/ Take Damage")]
public class TakeDamageEffect : InstantCharacterEffect
{
    [Header("Character causing damage")]
    public CharacterManager characterCausingDamage;

    [Header("Damage")]
    public float physicalDamage = 0f;
    public float magicalDamage = 0f;
    public float fireDamage = 0f;
    public float lightDamage = 0f;
    public float holyDamage = 0f;
    [Header("Final Damage")]
    public int finalDamageDealt = 0;

    [Header("Poise")]
    public float poiseDamage = 0f;
    public bool poiseIsBroken = false;  // if a character's poise is broken, they will be "Stunned" and play a damage animation

    [Header("Animation")]
    public bool playDamageAnimation = true;
    public bool manuallySelectDamageAnimation = false;
    public string damageAnimation;

    [Header("Sound Fx")]
    public bool willPlayDamageSFX = true;
    public AudioClip elementalDamageSoundSFX; // used on top of regular sfx if there is elemental damage present (Magic, Fire, Lightning, Holy)

    [Header("Direction Damage Take From")]
    public float angleHitFrom; // used to determine whar damage animation to play (Move backwards, Left, Right, Forward)
    public Vector3 contactPoint; // used to determine the blood fx instantiate   
    public override void ProcessEffecr(CharacterManager character)
    {
        base.ProcessEffecr(character);
        if (character.characterStatusManager.isDead)
            return;

        this.CalculateFinalDamage(character);
    }

    private void CalculateFinalDamage(CharacterManager character)
    {
        if (this.characterCausingDamage != null)
        {

        }

        this.finalDamageDealt = Mathf.RoundToInt(physicalDamage + magicalDamage + fireDamage + lightDamage + holyDamage);
        if (this.finalDamageDealt <= 0)
        {
            this.finalDamageDealt = 1;
        }
        Debug.Log("Final Damage Dealt: " + this.finalDamageDealt);
        character.characterStatusManager.currentHealth -= this.finalDamageDealt;
    }
}
