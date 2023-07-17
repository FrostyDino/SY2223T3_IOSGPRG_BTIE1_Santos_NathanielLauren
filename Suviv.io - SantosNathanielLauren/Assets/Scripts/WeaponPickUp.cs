using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gun { Pistol, Shotgun, AR};
public class WeaponPickUp : MonoBehaviour
{
    public Gun WeaponType;

    public PlayerData Data;
    void OnPickUp() 
    {
        if (WeaponType == Gun.Pistol)
        { 
            Debug.Log("Picked up Pistol");
        }
        if (WeaponType == Gun.Shotgun)
        {
            Debug.Log("Picked up Shotgun");
        }
        if (WeaponType == Gun.AR)
        {
            Debug.Log("Picked up AR");
        }

        Object.Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Data = collision.gameObject.GetComponent<PlayerData>())
        {
            OnPickUp();
        }
    }
}
