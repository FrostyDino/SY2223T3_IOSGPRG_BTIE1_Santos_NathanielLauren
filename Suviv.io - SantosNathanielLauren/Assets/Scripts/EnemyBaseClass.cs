using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Waypoints;
    public int WaypointIndex;
    public float movementSpeed;
    void Start()
    {
        transform.position = Waypoints[WaypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() 
    {
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[WaypointIndex].transform.position, movementSpeed * Time.deltaTime);
         
        if (transform.position == Waypoints[WaypointIndex].transform.position) 
        {
            WaypointIndex+=1;
        }
        if (WaypointIndex == Waypoints.Length) 
        {
            WaypointIndex = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerData>()) 
        {
            Debug.Log("Player Seen");
        }
    }
}
