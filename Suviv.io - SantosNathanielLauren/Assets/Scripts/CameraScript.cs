using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (Player != null) 
        { 
            this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, this.transform.position.z);
        }
    }
}
