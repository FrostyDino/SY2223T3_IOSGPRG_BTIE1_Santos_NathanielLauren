using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;
    void Start()
    {
        StartCoroutine(SpawnEnemy());   
    }

    IEnumerator SpawnEnemy() 
    {
        while (true) 
        {
            float RandomSpawn = Random.Range(0,4);
            float RandomY = Random.Range(this.transform.position.y - 3, this.transform.position.y + 3);
            Instantiate(Enemy, new Vector3(this.transform.position.x, RandomY), Quaternion.identity);
            yield return new WaitForSeconds(RandomSpawn);
        }

        yield return null;
    }
}
