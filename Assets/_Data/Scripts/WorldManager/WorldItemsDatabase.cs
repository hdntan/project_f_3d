using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WorldItemsDatabase : MonoBehaviour
{
    public static WorldItemsDatabase instance;
    public WeaponItem unarmedWeapon  ;
    public List<WeaponItem> weaponItems = new();
    private List<Item> items = new();

    protected void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        this.AddWeapon();
        this.CreateItemId();

    }

    protected virtual void AddWeapon()
    {
        foreach (var weapon in weaponItems)
        {
            items.Add(weapon);
        }
    }

    protected virtual void CreateItemId()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].itemID = i;
        }
    }

    public WeaponItem GetWeaponById(int id)
    {
        return weaponItems.FirstOrDefault(w => w.itemID == id);
    }
    
    public Item GetItemById(int id)
    {
        return items.FirstOrDefault(i => i.itemID == id);
    }
}
