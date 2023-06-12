using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject Floor;
    public void MoveFloor() 
    {

        Floor.transform.position = new Vector3(3, this.transform.position.y + 54);
    }
}
