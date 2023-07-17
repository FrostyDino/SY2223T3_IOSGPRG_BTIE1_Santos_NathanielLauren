using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon {Pistol, Shotgun, AR};
public class PlayerData : MonoBehaviour
{
    public int Health;
    public Weapon CurrentlyEquip;
}
