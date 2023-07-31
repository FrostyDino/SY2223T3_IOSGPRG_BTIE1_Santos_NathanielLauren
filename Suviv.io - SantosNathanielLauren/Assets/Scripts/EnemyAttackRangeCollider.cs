using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRangeCollider : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerData>() || collision.GetComponent<EnemyBaseClass>()) 
        {
            Debug.Log("Entity Entered Attack Range");
            GetComponentInParent<EnemyBaseClass>().currentState = EnemyState.Attacking;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerData>() || collision.GetComponent<EnemyBaseClass>())
        {
            
        }
    }
}
