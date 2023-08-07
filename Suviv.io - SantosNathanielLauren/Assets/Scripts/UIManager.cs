using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject Player;
    public PlayerData Data;
    public Inventory inventory;
    public Slider Health;
    public TextMeshProUGUI ammoMag;
    public TextMeshProUGUI ammoCapacity;
    public GameObject Pistol;
    public GameObject AR;
    public GameObject Shotgun;
    public TextMeshProUGUI invetoryPistolAmmo;
    public TextMeshProUGUI invetoryARAmmo;
    public TextMeshProUGUI invetoryShotgunAmmo;
    public Image ReloadBG;
    public TextMeshProUGUI ReloadText;
    public TextMeshProUGUI HuntersLeftAliveText;

    private void Awake()
    {
        if (Instance != null) Destroy(this);
        else Instance = this;
    }
    void Start()
    {
        Data = Player.GetComponent<PlayerData>();
        inventory = Player.GetComponent<Inventory>();
        Health.maxValue = Data.Health;
        UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        Health.value = Data.Health;
        ammoMag.text = "Currently Equiped " + Data.CurrentlyEquip;
        if (Data.CurrentlyEquip == Weapon.Pistol)
        {
            ammoMag.text = "" + Pistol.GetComponent<WeaponBaseClass>().AmmoMag;
            ammoCapacity.text = "" + inventory.ammos[0];
        }
        if (Data.CurrentlyEquip == Weapon.Shotgun)
        {
            ammoMag.text = "" + Shotgun.GetComponent<WeaponBaseClass>().AmmoMag;
            ammoCapacity.text = "" + inventory.ammos[1];
        }
        if (Data.CurrentlyEquip == Weapon.AR)
        {
            ammoMag.text = "" + AR.GetComponent<WeaponBaseClass>().AmmoMag;
            ammoCapacity.text = "" + inventory.ammos[2];
        }
        
        invetoryPistolAmmo.text = ""+ inventory.ammos[0];
        invetoryShotgunAmmo.text = "" + inventory.ammos[1];
        invetoryARAmmo.text = "" + inventory.ammos[2];
        HuntersLeftAliveText.text = "" + GameManager.Instance.EnemyAmount;
        
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
