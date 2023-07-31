using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvment : MonoBehaviour
{
    public float MvmentSpeed;

    public PlayerData Data;
    public Inventory AmmoPouch;
    public GameObject LeftJoystick;
    public GameObject RightJoystick;
    public Joystick LeftJoystickScript;
    public Joystick RightJoystickScript;
    public Rigidbody2D rb;
    public GameObject BulletPrefab;
    public GameObject FiringPoint;
    void Start()
    {
        AmmoPouch = this.GetComponent<Inventory>();
        Data = this.GetComponent<PlayerData>();
        LeftJoystickScript = LeftJoystick.GetComponent<FixedJoystick>();
        RightJoystickScript = RightJoystick.GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(LeftJoystickScript.Direction.x * MvmentSpeed, LeftJoystickScript.Direction.y * MvmentSpeed);
        
        if (RightJoystickScript.Direction != new Vector2 (0,0)) {
            Quaternion ToRotate = Quaternion.LookRotation(Vector3.forward, RightJoystickScript.Direction);
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, ToRotate, 1);
        }
    }

    public void PlayerDeath() 
    {
        Debug.Log("Player is Dead");
        Destroy(this.gameObject);
    }
}
