using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject Player;
    public PlayerData Data;
    public Inventory Inventory;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI CurrentlyEquiped;
    public GameObject Pistol;
    public GameObject AR;
    public GameObject Shotgun;

    private void Awake()
    {
        if (Instance != null) Destroy(this);
        else Instance = this;
    }
    void Start()
    {
        Data = Player.GetComponent<PlayerData>();
        Inventory = Player.GetComponent<Inventory>();
        Health.text = "Health: " + Data.Health;
        CurrentlyEquiped.text = "Currently Equiped " + Data.CurrentlyEquip;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        CurrentlyEquiped.text = "Currently Equiped " + Data.CurrentlyEquip;
        if (Data.CurrentlyEquip == Weapon.Pistol)
        {
            CurrentlyEquiped.text = Data.CurrentlyEquip + ": "+ Pistol.GetComponent<WeaponBaseClass>().AmmoMag +"/" + Inventory.PistolAmmo;
        }
        if (Data.CurrentlyEquip == Weapon.AR)
        {
            CurrentlyEquiped.text = Data.CurrentlyEquip + ": " + AR.GetComponent<WeaponBaseClass>().AmmoMag + "/" + Inventory.ARAmmo;
        }
        if (Data.CurrentlyEquip == Weapon.Shotgun)
        {
            CurrentlyEquiped.text = Data.CurrentlyEquip + ": "+ Shotgun.GetComponent<WeaponBaseClass>().AmmoMag +"/" + Inventory.ShotgunAmmo;
        }
    }

    public void ShootButton()
    {
        if (Data.CurrentlyEquip == Weapon.Pistol) 
        {
            Pistol.GetComponent<WeaponBaseClass>().pistolShoot();
        }
        if (Data.CurrentlyEquip == Weapon.Shotgun)
        {
            Shotgun.GetComponent<WeaponBaseClass>().ShotgunShoot();
        }
    }
    public void ReleaseAR() 
    {
        AR.GetComponent<WeaponBaseClass>().ARTrigger = false;
    }
    public void ShootAR() 
    {
        if (Data.CurrentlyEquip == Weapon.AR)
        {
            AR.GetComponent<WeaponBaseClass>().ARTrigger = true;
            AR.GetComponent<WeaponBaseClass>().ARShoot();
        }
    }
}
