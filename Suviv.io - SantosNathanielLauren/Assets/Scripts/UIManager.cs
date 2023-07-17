using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject Player;
    public PlayerData Data;
    public Inventory Inventory;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI PistolAmmo;
    public TextMeshProUGUI ShotgunAmmo;
    public TextMeshProUGUI ARAmmo;
    public TextMeshProUGUI CurrentlyEquiped;

    // Start is called before the first frame update
    void Start()
    {
        Data = Player.GetComponent<PlayerData>();
        Inventory = Player.GetComponent<Inventory>();
        Health.text = "Health: " + Data.Health;
        CurrentlyEquiped.text = "Currently Equiped " + Data.CurrentlyEquip;
        UpdateAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAmmo() 
    {
        PistolAmmo.text = "Pistol: " + Inventory.PistolAmmo;
        ShotgunAmmo.text = "Shotgun: " + Inventory.ShotgunAmmo;
        ARAmmo.text = "AR: " + Inventory.ARAmmo;
    }
}
