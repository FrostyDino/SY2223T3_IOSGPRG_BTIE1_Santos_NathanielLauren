using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x - 1, Player.transform.position.y + 3, -10);
    }
}
