using UnityEngine;

public class PlayerEquipmentManager : CharacterEquipmentManager
{
    public PlayerManager player;
    public WeaponModelInstantiationSlot rightHandSlot;
    public WeaponModelInstantiationSlot leftHandSlot;

    public GameObject rightHandWeaponModel;
    public GameObject leftHandWeaponModel;

    protected override void Awake()
    {
        base.Awake();
        this.player = GetComponent<PlayerManager>();
        this.InitializeWeaponSlots();
    }
    protected override void Start()
    {
        base.Start();
        this.LoadWeaponOnBothHands();
    }

    private void InitializeWeaponSlots()
    {
        WeaponModelInstantiationSlot[] weaponSlots = GetComponentsInChildren<WeaponModelInstantiationSlot>();
        foreach (var weaponSlot in weaponSlots)
        {
            if (weaponSlot.weaponSlot == WeaponModelSlot.RightHand)
            {
                this.rightHandSlot = weaponSlot;
            }
            else if (weaponSlot.weaponSlot == WeaponModelSlot.LeftHand)
            {
                this.leftHandSlot = weaponSlot;
            }
        }
    }
    public void LoadWeaponOnBothHands()
    {
        this.LoadRightWeapon();
        this.LoadLeftWeapon();
    }
    public void LoadRightWeapon()
    {
        if(this.player.playerInventoryManager.currentRightHandWeapon != null)
        {
            this.rightHandWeaponModel = Instantiate(this.player.playerInventoryManager.currentRightHandWeapon.weaponModel);
            this.rightHandSlot.LoadWeapon(this.rightHandWeaponModel);
        }
    }
    public void LoadLeftWeapon()
    {
        if(this.player.playerInventoryManager.currentLeftHandWeapon != null)
        {
            this.leftHandWeaponModel = Instantiate(this.player.playerInventoryManager.currentLeftHandWeapon.weaponModel);
            this.leftHandSlot.LoadWeapon(this.leftHandWeaponModel);
        }
    }

}
