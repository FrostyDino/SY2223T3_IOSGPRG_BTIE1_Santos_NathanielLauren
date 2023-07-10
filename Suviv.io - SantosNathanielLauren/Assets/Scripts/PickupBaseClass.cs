using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBaseClass : MonoBehaviour
{
    public int type;

    public PlayerData Player;
    public void OnPickUp() 
    {
        if (type == 1) 
        {
            Player.PistolAmmo += 20;
        }
        if (type == 2)
        {
            Player.ShotgunAmmo += 10;
        }
        if (type == 3)
        {
            Player.ARAmmo += 50;
        }

        Object.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Player = collision.gameObject.GetComponent<PlayerData>())
        {
            OnPickUp();
        }
    }

}
