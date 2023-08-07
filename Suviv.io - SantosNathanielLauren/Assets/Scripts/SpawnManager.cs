using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Ammo;
    public GameObject[] Weapons;
    public GameObject Enemy;
    [SerializeField] private int enemyAmount;
    [SerializeField] private int LootablesAmmount;
    private int LootableSpawned;
    void Start()
    {
        while (LootableSpawned != LootablesAmmount) 
        {
            float rand = Random.Range(0, 101);
            float randX = Random.Range(-30, 30);
            float randY = Random.Range(-24, 24);
            Vector2 RandPosition = new Vector3(randX, randY);
            if (rand <= 70)
            {
                Instantiate(Ammo[(int)Random.Range(0, Ammo.Length)], RandPosition, Quaternion.identity);
                LootableSpawned++;
            }
            else
            {
                Instantiate(Weapons[(int)Random.Range(0, Weapons.Length)], RandPosition, Quaternion.identity);
                LootableSpawned++;
            }
        }
        for (int i = 0; i < enemyAmount; i++) 
        {
            float randX = Random.Range(-30, 30);
            float randY = Random.Range(-24, 24);
            Vector2 RandPosition = new Vector3(randX, randY);
            Instantiate(Enemy, RandPosition, Quaternion.identity);
            GameManager.Instance.EnemyAmount++;
            UIManager.Instance.UpdateUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
