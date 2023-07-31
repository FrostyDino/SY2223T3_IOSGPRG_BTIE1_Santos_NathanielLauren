using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int PistolAmmo;
    public int ShotgunAmmo;
    public int ARAmmo;
    [SerializeField] private List<int> ammos;
    public InventorySlot currentlyEquipped;
    [SerializeField] private List<WeaponBaseClass> weapons;
    [SerializeField] private GameObject player;

    public void AddAmmo(Weapon weaponType, int ammount)
    {
        //Clamp After Adding
        ammos[(int)weaponType] += ammount;
    }

    public void AddWeapon(InventorySlot slot, Weapon weapon) 
    {
        if (weapons[(int)slot]) 
        {
            Destroy(weapons[(int)slot].gameObject);
        }
        for (int i = 0; i < player.transform.childCount; i++) 
        {
            player.transform.GetChild(i).gameObject.SetActive(false);
            if (i == (int)weapon) 
            {
                player.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        //Set as Current Gun;
    }

    public void SwitchGun() 
    { 
    
    }
}
