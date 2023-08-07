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
    [SerializeField] private bool IsReloading;
    public bool ARTrigger;
    public bool IsFiring;
    [SerializeField] private float FireRate;
    void Start()
    {
        Backpack = GetComponentInParent<Inventory>();
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
        else if(!IsReloading && Backpack.ammos[(int)WeaponType] > 0)
        {
            StartCoroutine(Reload());
            if (Backpack.ammos[(int)WeaponType] >= 15)
            {
                Backpack.RemoveAmmo(WeaponType, 15);
                AmmoMag += 15;
            }
            else 
            {
                AmmoMag += Backpack.ammos[(int)WeaponType];
                Backpack.RemoveAmmo(WeaponType, Backpack.ammos[(int)WeaponType]);
            }
            
        }

    }
    public void ARShoot()
    {
            if (AmmoMag > 0 && !IsReloading)
            {
            StartCoroutine(ARShooting());
            }
            else if (!IsReloading && Backpack.ammos[(int)WeaponType] > 0)
            {
            StartCoroutine(Reload());
            if (Backpack.ammos[(int)WeaponType] >= 30)
            {
                Backpack.RemoveAmmo(WeaponType, 30);
                AmmoMag += 30;
            }
            else
            {
                AmmoMag += Backpack.ammos[(int)WeaponType];
                Backpack.RemoveAmmo(WeaponType, Backpack.ammos[(int)WeaponType]);
            }

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
        else if (!IsReloading && Backpack.ammos[(int)WeaponType] > 0)
        {
            StartCoroutine(Reload());
            if (Backpack.ammos[(int)WeaponType] >= 2)
            {
                Backpack.RemoveAmmo(WeaponType, 2);
                AmmoMag += 2;
            }
            else
            {
                AmmoMag += Backpack.ammos[(int)WeaponType];
                Backpack.RemoveAmmo(WeaponType, Backpack.ammos[(int)WeaponType]);
            }

        }

    }

    IEnumerator Reload() 
    {
        IsReloading = true;
        if (this.gameObject.GetComponentInParent<PlayerMvment>()) 
        {
            UIManager.Instance.ReloadText.gameObject.SetActive(true);
            UIManager.Instance.ReloadBG.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
        IsReloading = false;
        UIManager.Instance.UpdateUI();
        UIManager.Instance.ReloadText.gameObject.SetActive(false);
        UIManager.Instance.ReloadBG.gameObject.SetActive(false);
    }

    IEnumerator ARShooting() 
    {
        while (ARTrigger && AmmoMag > 0) 
        {
            GameObject bullet = Instantiate(BulletPrefab, FiringPoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(FiringPoint.transform.up * 5f, ForceMode2D.Impulse);
            AmmoMag--;
            UIManager.Instance.UpdateUI();
            yield return StartCoroutine(FireRateCoroutine());
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
