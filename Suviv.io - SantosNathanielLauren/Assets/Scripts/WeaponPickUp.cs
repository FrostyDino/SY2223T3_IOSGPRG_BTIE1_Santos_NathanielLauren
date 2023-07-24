using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Weapon WeaponType;
    public int type;

    public PlayerData Data;
    public Inventory BackPack;
    void OnPickUp() 
    {
        if (WeaponType == Weapon.Pistol)
        {
            Data.CurrentlyEquip = Weapon.Pistol;
        }
        if (WeaponType == Weapon.Shotgun)
        {
            Data.CurrentlyEquip = Weapon.Shotgun;
        }
        if (WeaponType == Weapon.AR)
        {
            Data.CurrentlyEquip = Weapon.AR;
        }

        UIManager.Instance.UpdateUI();
        Object.Destroy(this.gameObject);

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
