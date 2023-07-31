using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState 
{ 
    Wondering,
    Chasing,
    Attacking
};
public class EnemyBaseClass : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private List<GameObject> EntityList;
    public GameObject[] GunPrefabs;
    [SerializeField] private GameObject CurrentGun;
    [SerializeField] private Weapon GunWeaponType;
    public GameObject GunSpawnLocation;
    public float movementSpeed;
    public EnemyState currentState;
    private Vector2 WonderDestination;
    void Start()
    {
        RandomizedWonderPoint();
        int RandomGun = Random.Range(0, GunPrefabs.Length - 1);
        CurrentGun = Instantiate(GunPrefabs[RandomGun], GunSpawnLocation.transform.position, Quaternion.identity);
        CurrentGun.transform.parent = transform;
        GunWeaponType = CurrentGun.GetComponent<WeaponBaseClass>().WeaponType;
        CurrentGun.GetComponent<WeaponBaseClass>().AmmoMag = 999;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) 
        {
            case EnemyState.Wondering:
                Move();
                break;
            case EnemyState.Chasing:
                SeekEntity();
                break;
            case EnemyState.Attacking:
                ShootEntity();
                break;
        }
    }

    private void Move() 
    {
        transform.up = new Vector3(WonderDestination.x, WonderDestination.y, transform.position.z) - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, WonderDestination, movementSpeed * Time.deltaTime);

        if (transform.position == new Vector3 (WonderDestination.x, WonderDestination.y, transform.position.z)) 
        {
            RandomizedWonderPoint();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerData>() || collision.GetComponent<EnemyBaseClass>()) 
        {
            EntityList.Add(collision.gameObject);
            currentState = EnemyState.Chasing;
        }
    }

    private void SeekEntity() 
    {
        transform.position = Vector2.MoveTowards(transform.position, EntityList[0].transform.position, movementSpeed * Time.deltaTime);
        float dis = Vector3.Distance(transform.position, EntityList[0].transform.position);

        transform.up = EntityList[0].transform.position - transform.position;

        if (dis <= 5) 
        {
            Debug.Log("Player Entered Range");
            currentState = EnemyState.Attacking;
        }
    }

    private void ShootEntity() 
    {
        transform.up = EntityList[0].transform.position - transform.position;
        float dis = Vector3.Distance(transform.position, EntityList[0].transform.position);
        if (CurrentGun.GetComponent<WeaponBaseClass>().IsFiring == false) {
            if (GunWeaponType == Weapon.Pistol)
            {
                CurrentGun.GetComponent<WeaponBaseClass>().pistolShoot();
            }
            else if (GunWeaponType == Weapon.AR)
            {
                CurrentGun.GetComponent<WeaponBaseClass>().ARTrigger = true;
                CurrentGun.GetComponent<WeaponBaseClass>().IsFiring = true;
                CurrentGun.GetComponent<WeaponBaseClass>().ARShoot();
            }
            else if (GunWeaponType == Weapon.Shotgun)
            {
                CurrentGun.GetComponent<WeaponBaseClass>().ShotgunShoot();
            }
        }

        if (dis >= 5)
        {
            Debug.Log("Entity Went Outside of Range");
            currentState = EnemyState.Chasing;
        }
    }

    private void RandomizedWonderPoint() 
    {
        WonderDestination =  Random.insideUnitCircle * 5 + new Vector2(transform.position.x, transform.position.y);
        
    }
}
