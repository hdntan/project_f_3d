using UnityEngine;

public class WeaponModelInstantiationSlot : MonoBehaviour
{
    public WeaponModelSlot weaponSlot;
    public GameObject currentWeaponModel;

    public void UnLoadWeapon()
    {
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);

        }
    }
    
    public void LoadWeapon(GameObject weaponModel)
    {
        this.currentWeaponModel = weaponModel;
        weaponModel.transform.SetParent(this.transform);
        weaponModel.transform.localPosition = Vector3.zero;
        weaponModel.transform.localRotation = Quaternion.identity;
        weaponModel.transform.localScale = Vector3.one;
    }
}
