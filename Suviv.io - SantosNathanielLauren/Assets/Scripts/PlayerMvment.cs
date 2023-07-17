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

        Quaternion ToRotate = Quaternion.LookRotation(Vector3.forward, RightJoystickScript.Direction);
        this.transform.rotation = Quaternion.RotateTowards(transform.rotation, ToRotate, 1);
        if (AmmoPouch.PistolAmmo > 0) {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject bullet = Instantiate(BulletPrefab, FiringPoint.transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(FiringPoint.transform.up * 5f, ForceMode2D.Impulse);
                AmmoPouch.PistolAmmo--;
                GameManager.Instace.UpdateUI();
            }
        }
    }
}
