using UnityEngine;

public class WeaponItem : Item
{
    [Header("Weapon Model")]
    public GameObject weaponModel;

    [Header("Weapon Requirements")]
    public int strengthREQ = 0;
    public int dexREQ = 0;
    public int intREQ = 0;
    public int faithREQ = 0;

    [Header("Weapon Base Damage")]
    public int physicalDamage = 0;
    public int magicDamage = 0;
    public int fireDamage = 0;
    public int lightningDamage = 0;
    public int holyDamage = 0;

    [Header("Weapon Poise")]
    public float poiseDamage = 10f;

    [Header("Stamina Cost")]
    public int baseStaminaCost = 20;
}
