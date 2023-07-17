using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Ammo;
    public GameObject[] Weapons;
    void Start()
    {
        for (int i = 0; i < Ammo.Length; i++) 
        {
            float randX = Random.Range(-10, 10);
            float randY = Random.Range(-4, 4);
            Vector2 RandPosition = new Vector3(randX, randY);
            Instantiate(Ammo[i], RandPosition, Quaternion.identity);
        }
        for (int i = 0; i < Weapons.Length; i++)
        {
            float randX = Random.Range(-10, 10);
            float randY = Random.Range(-4, 4);
            Vector2 RandPosition = new Vector3(randX, randY);
            Instantiate(Weapons[i], RandPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
