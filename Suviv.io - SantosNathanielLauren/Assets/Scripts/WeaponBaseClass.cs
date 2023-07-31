using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBaseClass : MonoBehaviour
{
    public Weapon WeaponType;
    public int AmmoMag;
    public GameObject BulletPrefab;
    public GameObject FiringPoint;
    public GameObject Player;
    public Inventory Backpack;
    private bool IsReloading;
    public bool ARTrigger;
    public bool IsFiring;
    [SerializeField] private float FireRate;
    void Start()
    {
        Backpack = Player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pistolShoot() 
    {
        if (AmmoMag > 0 && !IsReloading)
        {
            GameObject bullet = Instantiate(BulletPrefab, FiringPoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(FiringPoint.transform.up * 5f, ForceMode2D.Impulse);
            AmmoMag--;
            UIManager.Instance.UpdateUI();
            StartCoroutine(FireRateCoroutine());
        }
        else if(!IsReloading && Backpack.PistolAmmo > 0)
        {
            StartCoroutine(Reload());
            Backpack.PistolAmmo -= 9;
            AmmoMag += 9;
        }

    }
    public void ARShoot()
    {
            if (AmmoMag > 0 && !IsReloading)
            {
            StartCoroutine(ARShooting());
            }
            else if (!IsReloading && Backpack.ARAmmo > 0)
            {
                StartCoroutine(Reload());
                Backpack.PistolAmmo -= 50;
                AmmoMag += 50;
            }

    }
    public void ShotgunShoot()
    {
        
        if (AmmoMag > 0 && !IsReloading) 
        {
            
            for (int i = 0; i < 5; i++) 
            {
                float SpreadAngle = Random.Range(-20, 20);
                var Xpoint = FiringPoint.transform.position.x - this.transform.position.x;
                var Ypoint = FiringPoint.transform.position.y - this.transform.position.y;
                float RotateToAngle = SpreadAngle + (Mathf.Atan2(Ypoint, Xpoint) * Mathf.Rad2Deg);
                GameObject bullet = Instantiate(BulletPrefab, FiringPoint.transform.position, Quaternion.identity);
                Vector2 dir = new Vector2(Mathf.Cos(RotateToAngle * Mathf.Deg2Rad), Mathf.Sin(RotateToAngle * Mathf.Deg2Rad)).normalized;
                bullet.GetComponent<Rigidbody2D>().AddForce(dir * 5f, ForceMode2D.Impulse);
            }
            AmmoMag--;
            UIManager.Instance.UpdateUI();
            StartCoroutine(FireRateCoroutine());
        }
        else if (!IsReloading && Backpack.ShotgunAmmo > 0)
        {
            StartCoroutine(Reload());
            Backpack.ShotgunAmmo -= 2;
            AmmoMag += 2;
        }

    }

    IEnumerator Reload() 
    {
        IsReloading = true;
        UIManager.Instance.CurrentlyEquiped.text = "Reloading...";
        yield return new WaitForSeconds(2f);
        IsReloading = false;
        UIManager.Instance.UpdateUI();
    }

    IEnumerator ARShooting() 
    {
        while (ARTrigger) 
        {
            GameObject bullet = Instantiate(BulletPrefab, FiringPoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(FiringPoint.transform.up * 5f, ForceMode2D.Impulse);
            AmmoMag--;
            UIManager.Instance.UpdateUI();
            yield return new WaitForSeconds(0.25f);
        }
        yield return null;
    }

    IEnumerator FireRateCoroutine() 
    {
        IsFiring = true;
        yield return new WaitForSeconds(FireRate);
        IsFiring = false;
    }
}
