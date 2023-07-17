using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instace;

    public Canvas UI;
    public PlayerData Data;
    public GameObject Player;
    private void Awake()
    {
        if (Instace != null) Destroy(this);
        else Instace = this; 
    }
    void Start()
    {
        Data = Player.GetComponent<PlayerData>();
    }
    void Update()
    {   
    }

    public void UpdateUI() 
    {
        UI.GetComponent<UIManager>().UpdateAmmo();
    }
}
