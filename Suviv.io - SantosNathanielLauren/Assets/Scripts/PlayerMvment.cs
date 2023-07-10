using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvment : MonoBehaviour
{
    private PlayerData Data;

    public GameObject LeftJoystick;
    public GameObject RightJoystick;
    public Joystick LeftJoystickScript;
    public Joystick RightJoystickScript;

    public Rigidbody2D rb;
    void Start()
    {
        Data = this.GetComponent<PlayerData>();

        LeftJoystickScript = LeftJoystick.GetComponent<FixedJoystick>();
        RightJoystickScript = RightJoystick.GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(LeftJoystickScript.Direction.x * Data.MvmentSpeed, LeftJoystickScript.Direction.y * Data.MvmentSpeed);

        Quaternion ToRotate = Quaternion.LookRotation(Vector3.forward, RightJoystickScript.Direction);
        this.transform.rotation = Quaternion.RotateTowards(transform.rotation, ToRotate, 1);
    }
}
