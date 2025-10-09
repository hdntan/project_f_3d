using UnityEngine;
using System;

public class PlayerEquipmentManager : CharacterEquipmentManager
{
    public PlayerManager player;
    public WeaponModelInstantiationSlot rightHandSlot;
    public WeaponModelInstantiationSlot leftHandSlot;



    private int _currentRightHandWeaponId = 0;
    private int _currentLeftHandWeaponId = 0;

    public int currentRightHandWeaponId
    {
        get => _currentRightHandWeaponId;
        set
        {
            if (_currentRightHandWeaponId == value) return;
            _currentRightHandWeaponId = value;
            OnCurrentRightHandWeaponIdChanged?.Invoke(_currentRightHandWeaponId);
        }
    }

    public int currentLeftHandWeaponId
    {
        get => _currentLeftHandWeaponId;
        set
        {
            if (_currentLeftHandWeaponId == value) return;
            _currentLeftHandWeaponId = value;
            OnCurrentLeftHandWeaponIdChanged?.Invoke(_currentLeftHandWeaponId);
        }
    }
    public event Action<int> OnCurrentRightHandWeaponIdChanged;
    public event Action<int> OnCurrentLeftHandWeaponIdChanged;

    public WeaponManager rightWeaponManager;
    public WeaponManager leftWeaponManager;

    public GameObject rightHandWeaponModel;
    public GameObject leftHandWeaponModel;

    protected override void Awake()
    {
        base.Awake();
        this.player = GetComponent<PlayerManager>();
        this.InitializeWeaponSlots();
        this.OnCurrentLeftHandWeaponIdChanged += this.HandleChangeCurrentLeftHandWeaponByWeaponIdChange;
        this.OnCurrentRightHandWeaponIdChanged += this.HandleChangeCureentRightHandWeaponByWeaponIdChange;
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

    //right hand weapon
    public void HandleChangeCureentRightHandWeaponByWeaponIdChange(int newId)
    {
        Debug.Log("Change right hand weapon id to: " + newId);
        WeaponItem newWeapon = Instantiate(WorldItemsDatabase.instance.GetWeaponById(newId));
        this.player.playerInventoryManager.currentRightHandWeapon = newWeapon;
        this.LoadRightWeapon();
    }
    public void SwitchRightWeapon()
    {
        this.player.playerAnimatorManager.PlayTargetActionAnimation("Swap_Right_Weapon_01", false, true, true, true);
        WeaponItem slectedWeapon = null;

        this.player.playerInventoryManager.rightHandWeaponIndex += 1;
        if (this.player.playerInventoryManager.rightHandWeaponIndex < 0 || this.player.playerInventoryManager.rightHandWeaponIndex > 2)
        {
            this.player.playerInventoryManager.rightHandWeaponIndex = 0;

            int weaponCount = 0;
            WeaponItem firstWeapon = null;
            int firstWeaponPosition = 0;
            for (int i = 0; i < this.player.playerInventoryManager.weaponsInRightHandSlots.Length; i++)
            {
                if (this.player.playerInventoryManager.weaponsInRightHandSlots[i].itemID != WorldItemsDatabase.instance.unarmedWeapon.itemID)
                {
                    weaponCount += 1;
                    if (firstWeapon == null)
                    {
                        firstWeapon = this.player.playerInventoryManager.weaponsInRightHandSlots[i];
                        firstWeaponPosition = i;
                    }
                }
            }
            if (weaponCount <= 1)
            {
                this.player.playerInventoryManager.rightHandWeaponIndex = -1;
                slectedWeapon = WorldItemsDatabase.instance.unarmedWeapon;
                this.currentRightHandWeaponId = slectedWeapon.itemID;
            }
            else
            {
                this.player.playerInventoryManager.rightHandWeaponIndex = firstWeaponPosition;
                this.currentRightHandWeaponId = firstWeapon.itemID;
            }
            return;
        }

        foreach (WeaponItem weapon in this.player.playerInventoryManager.weaponsInRightHandSlots)
        {
            if (this.player.playerInventoryManager.weaponsInRightHandSlots[this.player.playerInventoryManager.rightHandWeaponIndex].itemID != WorldItemsDatabase.instance.unarmedWeapon.itemID)
            {
                slectedWeapon = this.player.playerInventoryManager.weaponsInRightHandSlots[this.player.playerInventoryManager.rightHandWeaponIndex];
                this.currentRightHandWeaponId = slectedWeapon.itemID;
                return;
            }
        }

        if (slectedWeapon == null && this.player.playerInventoryManager.rightHandWeaponIndex <= 2)
        {
            this.SwitchRightWeapon();
        }

    }
    public void LoadRightWeapon()
    {
        if (this.player.playerInventoryManager.currentRightHandWeapon != null)
        {
            //remove current weapon model
            this.rightHandSlot.UnLoadWeapon();

            // load new weapon model
            this.rightHandWeaponModel = Instantiate(this.player.playerInventoryManager.currentRightHandWeapon.weaponModel);
            this.rightHandSlot.LoadWeapon(this.rightHandWeaponModel);
            this.rightWeaponManager = this.rightHandWeaponModel.GetComponent<WeaponManager>();
            this.rightWeaponManager.SetWeaponDamage(this.player, this.player.playerInventoryManager.currentRightHandWeapon);
        }
    }

    // left hand weapon

    public void SwitchLeftWeapon()
    {
        this.player.playerAnimatorManager.PlayTargetActionAnimation("Swap_Left_Weapon_01", false, true, true, true);
        WeaponItem slectedWeapon = null;

        this.player.playerInventoryManager.leftHandWeaponIndex += 1;
        if (this.player.playerInventoryManager.leftHandWeaponIndex < 0 || this.player.playerInventoryManager.leftHandWeaponIndex > 2)
        {
            this.player.playerInventoryManager.leftHandWeaponIndex = 0;

            int weaponCount = 0;
            WeaponItem firstWeapon = null;
            int firstWeaponPosition = 0;
            for (int i = 0; i < this.player.playerInventoryManager.weaponsInLeftHandSlots.Length; i++)
            {
                if (this.player.playerInventoryManager.weaponsInLeftHandSlots[i].itemID != WorldItemsDatabase.instance.unarmedWeapon.itemID)
                {
                    weaponCount += 1;
                    if (firstWeapon == null)
                    {
                        firstWeapon = this.player.playerInventoryManager.weaponsInLeftHandSlots[i];
                        firstWeaponPosition = i;
                    }
                }
            }
            if (weaponCount <= 1)
            {
                this.player.playerInventoryManager.leftHandWeaponIndex = -1;
                slectedWeapon = WorldItemsDatabase.instance.unarmedWeapon;
                this.currentLeftHandWeaponId = slectedWeapon.itemID;
            }
            else
            {
                this.player.playerInventoryManager.leftHandWeaponIndex = firstWeaponPosition;
                this.currentLeftHandWeaponId = firstWeapon.itemID;
            }
            return;
        }

        foreach (WeaponItem weapon in this.player.playerInventoryManager.weaponsInLeftHandSlots)
        {
            if (this.player.playerInventoryManager.weaponsInLeftHandSlots[this.player.playerInventoryManager.leftHandWeaponIndex].itemID != WorldItemsDatabase.instance.unarmedWeapon.itemID)
            {
                slectedWeapon = this.player.playerInventoryManager.weaponsInLeftHandSlots[this.player.playerInventoryManager.leftHandWeaponIndex];
                this.currentLeftHandWeaponId = slectedWeapon.itemID;
                return;
            }
        }

        if (slectedWeapon == null && this.player.playerInventoryManager.leftHandWeaponIndex <= 2)
        {
            this.SwitchLeftWeapon();
        }
    }
    public void HandleChangeCurrentLeftHandWeaponByWeaponIdChange(int newId)
    {
        Debug.Log("Change left hand weapon id to: " + newId);
        WeaponItem newWeapon = Instantiate(WorldItemsDatabase.instance.GetWeaponById(newId));
        this.player.playerInventoryManager.currentLeftHandWeapon = newWeapon;
        this.LoadLeftWeapon();
    }
    public void LoadLeftWeapon()
    {
        if (this.player.playerInventoryManager.currentLeftHandWeapon != null)
        {
            //remove current weapon model
            this.leftHandSlot.UnLoadWeapon();

            // load new weapon model
            this.leftHandWeaponModel = Instantiate(this.player.playerInventoryManager.currentLeftHandWeapon.weaponModel);
            this.leftHandSlot.LoadWeapon(this.leftHandWeaponModel);
            this.leftWeaponManager = this.leftHandWeaponModel.GetComponent<WeaponManager>();
            this.leftWeaponManager.SetWeaponDamage(this.player, this.player.playerInventoryManager.currentLeftHandWeapon);
        }
    }

}
