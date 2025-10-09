using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [Header("Collider")]
    public Collider damageCollider;
   [Header("Damage")]
    public float physicalDamage = 0f;
    public float magicDamage = 0f;
    public float fireDamage = 0f;
    public float lightningDamage = 0f;
    public float holyDamage = 0f;

    [Header("Contact Point")]
    public Vector3 contactPoint;

    [Header("Character damage")]
    public List<CharacterManager> charactersDamaged = new List<CharacterManager>();

    public virtual void EnableDamageCollider()
    {
        this.damageCollider.enabled = true;
    }

    public virtual void DisableDamageCollider()
    {
        this.damageCollider.enabled = false;
        this.charactersDamaged.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterManager targetDamage = other.GetComponent<CharacterManager>();
        if (targetDamage != null)
        {
            this.contactPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            this.DamageTarget(targetDamage);
        }
    }
    
    protected virtual void DamageTarget(CharacterManager targetDamage)
    {
        if (this.charactersDamaged.Contains(targetDamage))
        {
            return;
        }

        this.charactersDamaged.Add(targetDamage);
        
            TakeDamageEffect damageEffect = Instantiate(WorldCharacterEffectManager.instance.takeDamageEffect);
            damageEffect.physicalDamage = this.physicalDamage;
            damageEffect.magicDamage = this.magicDamage;
            damageEffect.fireDamage = this.fireDamage;
            damageEffect.lightningDamage = this.lightningDamage;
            damageEffect.holyDamage = this.holyDamage;
            damageEffect.contactPoint = this.contactPoint;

            targetDamage.characterEffectManager.ProcessInstantEffect(damageEffect);
    }
}
