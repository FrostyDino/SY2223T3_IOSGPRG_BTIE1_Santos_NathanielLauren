using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject Player;
    public PlayerData Data;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI PistolAmmo;
    public TextMeshProUGUI ShotgunAmmo;
    public TextMeshProUGUI ARAmmo;

    // Start is called before the first frame update
    void Start()
    {
        Data = Player.GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "Health: " + Data.Health;
        PistolAmmo.text = "Pistol: " + Data.PistolAmmo;
        ShotgunAmmo.text = "Shotgun: " + Data.ShotgunAmmo;
        ARAmmo.text = "AR: " + Data.ARAmmo;
    }
}
