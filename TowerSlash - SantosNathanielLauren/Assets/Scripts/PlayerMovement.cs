using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 StartTouchPosition;
    private Vector2 EndTouchPosition;

    public static PlayerData Data;
    public List<GameObject> EnemyList = new List<GameObject>();
    public int EnemyCounter = 0;
    public Slider DashGauge;
    public Camera MainCamera;
    private bool InDash;
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerData.Instance.PlayerSprite;
    }
    // Update is called once per frame
    void Update()
    {
        //This Moves the player Up Continously
        this.transform.position = new Vector2(1, this.transform.position.y + PlayerData.Instance.MvmentSpeed);

        //This Block of Code is for the Swiping and checks if there is an anemy to swipe for
        if (EnemyList.Count > 0)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                StartTouchPosition = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                EndTouchPosition = Input.GetTouch(0).position;
                if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenColor == new Color(0, 255, 0))
                {
                    if (EndTouchPosition.x < StartTouchPosition.x)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Left")
                        {
                            KillEnemy();
                        }
                        
                    }
                    if (EndTouchPosition.x > StartTouchPosition.x)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Right")
                        {
                            KillEnemy();
                        }
                        
                    }
                    if (EndTouchPosition.y > StartTouchPosition.y)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Up")
                        {
                            KillEnemy();
                        }
                       
                    }
                    if (EndTouchPosition.y < StartTouchPosition.y)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Down")
                        {
                            KillEnemy();
                        }
                        
                    }
                }

                else if (EnemyList[0].GetComponent<EnemyBaseScript>().ChosenColor == new Color(255, 0, 0))
                {
                    if (EndTouchPosition.x < StartTouchPosition.x)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Right")
                        {
                            KillEnemy();
                        }
                       
                    }
                    if (EndTouchPosition.x > StartTouchPosition.x)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Left")
                        {
                            KillEnemy();
                        }
                        
                    }
                    if (EndTouchPosition.y < StartTouchPosition.y)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Up")
                        {
                            KillEnemy();
                        }
                    }
                    if (EndTouchPosition.y > StartTouchPosition.y)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Down")
                        {
                            KillEnemy();
                        }
                        
                    }
                }
                else if (EnemyList[0].GetComponent<EnemyBaseScript>().ChosenColor == new Color(255, 255, 0))
                {
                    if (EndTouchPosition.x < StartTouchPosition.x)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Left")
                        {
                            KillEnemy();
                        }
                        
                    }
                    if (EndTouchPosition.x > StartTouchPosition.x)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Right")
                        {
                            KillEnemy();
                        }
                        
                    }
                    if (EndTouchPosition.y > StartTouchPosition.y)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Up")
                        {
                            KillEnemy();
                        }
                    }
                    if (EndTouchPosition.y < StartTouchPosition.y)
                    {
                        if (EnemyList[EnemyCounter].GetComponent<EnemyBaseScript>().ChosenArrow == "Down")
                        {
                            KillEnemy();
                        }
                        
                    }
                }
            }
        }
        else 
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (DashGauge.value < DashGauge.maxValue) 
                {
                    StartCoroutine(DashTap());
                }
                
            }
        }
        
    }

    private void KillEnemy() 
    {
        EnemyList[0].GetComponent<EnemyBaseScript>().EnemyKilled();
        //EnemyList.RemoveAt(0);
        // EnemyCounter--;
        int PowerupChance = Random.Range(1, 101);
        if (PowerupChance <= 3) 
        {
            PlayerData.Instance.CurrentHP++;
        }
        if (!InDash) 
        {
            DashGauge.value += PlayerData.Instance.DashMeterMod;
        }

        PlayerData.Instance.Points += 30;
        Debug.Log("Enemy Killed");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBaseScript>())
        {
            if (collision.gameObject.GetComponent<EnemyBaseScript>().ChosenColor == new Color(255,255,0)) {
            collision.gameObject.GetComponent<EnemyBaseScript>().StopRotation();
            }
            EnemyList.Add(collision.gameObject);
            //EnemyCounter++;
            Debug.Log("Enemy Seen");
        }
        if (collision.gameObject.GetComponent<FloorManager>()) 
        {
            collision.gameObject.GetComponent<FloorManager>().MoveFloor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBaseScript>())
        {
            if (collision.transform.position.y < this.transform.position.y) 
            {
                if (!InDash)
                {
                    PlayerData.Instance.CurrentHP--;
                    if (PlayerData.Instance.CurrentHP <= 0)
                    {
                        MoveScene();
                    }
                }
                else 
                {
                    KillEnemy();
                }
            }
            EnemyList.Remove(collision.gameObject);
            collision.gameObject.GetComponent<EnemyBaseScript>().EnemyKilled();
            Debug.Log("Enemy Left");
        }
    }

    IEnumerator DashTap() 
    {
        PlayerData.Instance.Points += 15;
        MainCamera.gameObject.GetComponent<CameraMovement>().enabled = false;
        PlayerData.Instance.MvmentSpeed = 1f;

        yield return new WaitForSeconds(0.1f);

        MainCamera.gameObject.GetComponent<CameraMovement>().enabled = true;
        PlayerData.Instance.MvmentSpeed = 0.1f;
    }

    public void DashGuageButton() 
    {
        StartCoroutine(FullDash());
    }

    IEnumerator FullDash() 
    {
        if (DashGauge.value == DashGauge.maxValue) 
        {
            float NormalMovement = PlayerData.Instance.MvmentSpeed;
            DashGauge.value = 0;
            PlayerData.Instance.MvmentSpeed = 5f;
            InDash = true;
            yield return new WaitForSecondsRealtime(3f);
            InDash = false;
            PlayerData.Instance.MvmentSpeed = NormalMovement;
        }
    }

    private void MoveScene() 
    {
        SceneManager.LoadScene("GameOver");
    }
}
