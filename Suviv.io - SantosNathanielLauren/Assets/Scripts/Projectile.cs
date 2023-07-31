using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bullet") 
        {
            if (collision.gameObject.GetComponent<PlayerData>()) 
            {
                GameObject Player = collision.gameObject;
                Player.GetComponent<PlayerData>().Health -= 10;
                UIManager.Instance.UpdateUI();
                if (Player.GetComponent<PlayerData>().Health <= 0) 
                {
                    Player.GetComponent<PlayerMvment>().PlayerDeath();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
