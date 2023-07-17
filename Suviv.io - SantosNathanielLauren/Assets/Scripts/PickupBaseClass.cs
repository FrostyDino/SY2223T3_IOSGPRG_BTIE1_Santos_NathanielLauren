using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ammo { PistolAmmo, ShotgunAmmo, ARAmmo };
public class PickupBaseClass : MonoBehaviour
{
    public ammo AmmoType;

    public Inventory Inventory;
    public void OnPickUp() 
    {
        if (AmmoType == ammo.PistolAmmo) 
        {
            Inventory.PistolAmmo += 20;
        }
        if (AmmoType == ammo.ShotgunAmmo)
        {
            Inventory.ShotgunAmmo += 10;
        }
        if (AmmoType == ammo.ARAmmo)
        {
            Inventory.ARAmmo += 50;
        }
        GameManager.Instace.UpdateUI();
        Object.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Inventory = collision.gameObject.GetComponent<Inventory>())
        {
            OnPickUp();
        }
    }

}
