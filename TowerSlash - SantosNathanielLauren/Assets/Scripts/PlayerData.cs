using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int Health;
    public int CurrentHP;
    public Sprite PlayerSprite;
    public float MvmentSpeed;
    public int Points;
    public int DashMeterMod;
    public static PlayerData Instance;
    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Object.Destroy(this);
        }
        DontDestroyOnLoad(this);
        ResetGame();
    }

    public void ResetGame() 
    {
        CurrentHP = Health;
        Points = 0;
    }
}
