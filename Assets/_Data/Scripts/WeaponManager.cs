using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public MeleeWeaponDamageCollider meleeWeaponDamageCollider;

    private void Awake()
    {
        this.meleeWeaponDamageCollider = GetComponentInChildren<MeleeWeaponDamageCollider>();

    }
    
    public void SetWeaponDamage(CharacterManager characterWieldingWeapon, WeaponItem weapon)
    {
        this.meleeWeaponDamageCollider.characterCausingDamage = characterWieldingWeapon;
        this.meleeWeaponDamageCollider.physicalDamage = weapon.physicalDamage;
        this.meleeWeaponDamageCollider.magicDamage = weapon.magicDamage;
        this.meleeWeaponDamageCollider.fireDamage = weapon.fireDamage;
        this.meleeWeaponDamageCollider.lightningDamage = weapon.lightningDamage;
        this.meleeWeaponDamageCollider.holyDamage = weapon.holyDamage;
    }
}
