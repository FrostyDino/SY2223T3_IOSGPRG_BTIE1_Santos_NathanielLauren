using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Weapon WeaponType;
    [SerializeField] private InventorySlot slot;
    public int type;

    public PlayerData Data;
    public Inventory BackPack;
    private void OnPickUp() 
    {
        BackPack.AddWeapon(slot, WeaponType);
        //if (WeaponType == Weapon.Pistol)
        //{
        //    Data.CurrentlyEquip = Weapon.Pistol;
        //}
        //if (WeaponType == Weapon.Shotgun)
        //{
        //    Data.CurrentlyEquip = Weapon.Shotgun;
        //}
        //if (WeaponType == Weapon.AR)
        //{
        //    Data.CurrentlyEquip = Weapon.AR;
        //}

        UIManager.Instance.UpdateUI();
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Data = collision.gameObject.GetComponent<PlayerData>())
        {
            BackPack = collision.gameObject.GetComponent<Inventory>();
            OnPickUp();
        }
    }
}
