using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 StartTouchPosition;
    private Vector2 EndTouchPosition;

    public static PlayerData Data;

    private GameObject Enemy;
    private EnemyBaseScript EnemeyScript;
    void Start()
    {
        Data = this.GetComponent<PlayerData>();
    }
    // Update is called once per frame
    void Update()
    {
        //This Moves the player Up Continously
        this.transform.position = new Vector2(1, this.transform.position.y + Data.MvmentSpeed);

        //This Block of Code is for the Swiping and checks if there is an anemy to swipe for
        if (Enemy != null)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                StartTouchPosition = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                EndTouchPosition = Input.GetTouch(0).position;
                if (EnemeyScript.ArrowColor == "Green") 
                {
                    if (EndTouchPosition.x < StartTouchPosition.x)
                    {
                        if (EnemeyScript.ArrowDirection == "Left")
                        {
                            Debug.Log("Enemy Killed");
                            EnemeyScript.EnemyKilled();
                            Enemy = null;
                            EnemeyScript = null;
                        }
                    }
                    if (EndTouchPosition.x > StartTouchPosition.x)
                    {
                        if (EnemeyScript.ArrowDirection == "Right")
                        {
                            Debug.Log("Enemy Killed");
                            EnemeyScript.EnemyKilled();
                            Enemy = null;
                            EnemeyScript = null;
                        }
                    }
                    if (EndTouchPosition.y > StartTouchPosition.y)
                    {
                        if (EnemeyScript.ArrowDirection == "Up")
                        {
                            Debug.Log("Enemy Killed");
                            EnemeyScript.EnemyKilled();
                            Enemy = null;
                            EnemeyScript = null;
                        }
                    }
                }

                else if (EnemeyScript.ArrowColor == "Red")
                {
                    if (EndTouchPosition.x < StartTouchPosition.x)
                    {
                        if (EnemeyScript.ArrowDirection == "Right")
                        {
                            Debug.Log("Enemy Killed");
                            EnemeyScript.EnemyKilled();
                            Enemy = null;
                            EnemeyScript = null;
                        }
                    }
                    if (EndTouchPosition.x > StartTouchPosition.x)
                    {
                        if (EnemeyScript.ArrowDirection == "Left")
                        {
                            Debug.Log("Enemy Killed");
                            EnemeyScript.EnemyKilled();
                            Enemy = null;
                            EnemeyScript = null;
                        }
                    }
                    if (EndTouchPosition.y < StartTouchPosition.y)
                    {
                        if (EnemeyScript.ArrowDirection == "Up")
                        {
                            Debug.Log("Enemy Killed");
                            EnemeyScript.EnemyKilled();
                            Enemy = null;
                            EnemeyScript = null;
                        }
                    }
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy = collision.gameObject;
            EnemeyScript = Enemy.GetComponent<EnemyBaseScript>();
            Debug.Log("Enemy Seen");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy = null;
            EnemeyScript = null;
            Debug.Log("Enemy Left");
        }
    }
}
