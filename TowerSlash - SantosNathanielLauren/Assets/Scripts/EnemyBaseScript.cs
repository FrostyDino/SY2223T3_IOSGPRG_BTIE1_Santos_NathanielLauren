using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{
    public GameObject[] GreenArrowArray;
    public GameObject[] RedArrowArray;
    public GameObject ArrowType;
    public GameObject ArrowObject;
    public string ArrowDirection;
    public string ArrowColor;
    void Start()
    {
        int RandomColor = Random.Range(1,3);
        if (RandomColor == 1)
        {
            int RandomArrow = Random.Range(0, GreenArrowArray.Length);
            ArrowType = GreenArrowArray[RandomArrow];
            if (RandomArrow == 0) ArrowDirection = "Up";
            else if (RandomArrow == 1) ArrowDirection = "Right";
            else if (RandomArrow == 2) ArrowDirection = "Left";
            ArrowColor = "Green";
        }
        else if(RandomColor == 2)
        {
            int RandomArrow = Random.Range(0, RedArrowArray.Length);
            ArrowType = RedArrowArray[RandomArrow];
            if (RandomArrow == 0) ArrowDirection = "Up";
            else if (RandomArrow == 1) ArrowDirection = "Right";
            else if (RandomArrow == 2) ArrowDirection = "Left";
            ArrowColor = "Red";
        }
        
        
       ArrowObject = Instantiate(ArrowType, new Vector3(this.transform.position.x - 2, this.transform.position.y), Quaternion.identity);
    }

    public void EnemyKilled() 
    {
        Object.Destroy(ArrowObject);
        Object.Destroy(this.gameObject);
    }
}
