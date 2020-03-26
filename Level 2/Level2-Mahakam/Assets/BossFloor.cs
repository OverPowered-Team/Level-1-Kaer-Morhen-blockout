using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFloor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject playerDestinationPos;
    public GameObject myDestinationPos;
    public GameObject endFloor; 
    public float speed = 100;
    Vector3 speedVector;
    bool playerArrived, destinationReached;

    void Start()
    {
        speedVector = new Vector3(0, speed, 0);
        playerArrived = destinationReached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (destinationReached)
            return;

        if (playerArrived)
        {
            if (HasReachedDestination() == false)
                goUp(); 
            else
            {
                destinationReached = true;
                player.transform.position = playerDestinationPos.transform.position;
                endFloor.SetActive(true);
                Destroy(gameObject); 
            }
                
        }

    }

    bool HasReachedDestination() => transform.position.y >= myDestinationPos.transform.position.y;

    void goUp()
    {
        Debug.Log("Boss floor going UP!"); 
        transform.position += speedVector * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Boss floor collision!"); 

        if (collision.gameObject == player)
        {
            Debug.Log("Boss floor collision WITH PLAYER!");
            playerArrived = true;
        }
         
    }

}
