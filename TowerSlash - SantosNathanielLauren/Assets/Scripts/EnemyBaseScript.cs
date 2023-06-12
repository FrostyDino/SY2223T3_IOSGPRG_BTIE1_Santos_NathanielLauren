using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{
    public GameObject[] ArrowArray;
    public GameObject ArrowType;
    public GameObject ArrowObject;
    public string[] ArrowDirection;
    public string ChosenArrow;
    public Color ChosenColor;
    private int NextSprite;
    private Coroutine Rotation;
    void Start()
    {
        int RandomColor = Random.Range(1,4);
        if (RandomColor == 1)
        {
            ChosenColor = new Color(0, 255, 0);
        }
        else if (RandomColor == 2)
        {
            ChosenColor = new Color(255, 0, 0);
        }
        else if (RandomColor == 3) 
        {
            ChosenColor = new Color(255, 255, 0);
        }

        int RandomArrow = Random.Range(0, ArrowArray.Length);
        ArrowType = ArrowArray[RandomArrow];
        ArrowType.GetComponent<SpriteRenderer>().color = ChosenColor;
        if (RandomArrow == 0) ChosenArrow = ArrowDirection[0];
        else if (RandomArrow == 1) ChosenArrow = ArrowDirection[1];
        else if (RandomArrow == 2) ChosenArrow = ArrowDirection[2];
        else if (RandomArrow == 3) ChosenArrow = ArrowDirection[3];

        ArrowObject = Instantiate(ArrowType, new Vector3(this.transform.position.x - 2, this.transform.position.y), Quaternion.identity);
        if (RandomColor == 3) 
        {
            Rotation = StartCoroutine(RotatingArrow());
        }
    }

    public void EnemyKilled() 
    {
        Object.Destroy(ArrowObject);
        Object.Destroy(this.gameObject);
    }

    IEnumerator RotatingArrow() 
    {
        while (true) {
            ArrowObject.GetComponent<SpriteRenderer>().sprite = ArrowArray[NextSprite].GetComponent<SpriteRenderer>().sprite;
            ChosenArrow = ArrowDirection[NextSprite];
            NextSprite++;
            if (NextSprite > ArrowArray.Length - 1)
            {
                NextSprite = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void StopRotation() 
    {
        StopCoroutine(Rotation);
    }
}
