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
            if (collision.gameObject.GetComponent<EnemyBaseClass>())
            {
                GameObject npc = collision.gameObject;
                npc.GetComponent<EnemyBaseClass>().HP -= 10;
                UIManager.Instance.UpdateUI();
                if (npc.GetComponent<EnemyBaseClass>().HP <= 0)
                {
                    npc.GetComponent<EnemyBaseClass>().Death();
                }
            }
            else Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), collision.gameObject.GetComponent<CircleCollider2D>());
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
