using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum treeState { AWAIT, FALLING, FLOOR}
public class TreeFall : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public float close;
    public Vector3 force;
    bool fell = false;
    public float stopTime;
    float currentTime; 
    treeState state; 

    void Start()
    {
        currentTime = 0f; 
        state = treeState.AWAIT; 
    }

    // Update is called once per frame
    void Update()
    {

        if (state == treeState.FLOOR)
            return; 

        else if (state == treeState.FALLING)
        {
   
            if ((currentTime += Time.deltaTime) >= stopTime)
            {
                Debug.Log("Fallen tree!!"); 
                state = treeState.FLOOR;
                Destroy(gameObject.GetComponent<Rigidbody>());
            }

        }
        else
        {
            float dist = (player.transform.position - transform.position).magnitude;
            if ((player) && (dist <= close))
            {
                state = treeState.FALLING;
                gameObject.AddComponent<Rigidbody>().AddForce(force);
            }
        }
    
        
    }
}
