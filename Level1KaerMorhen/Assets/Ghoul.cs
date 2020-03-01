using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GhoulState { AWAIT, MOVE, STOP}

public class Ghoul : MonoBehaviour
{
    // Start is called before the first frame update
    public float travel = 3.5f;
    public float detection = 8f;
    public GameObject player; 
    Vector3 startPos;
    float speed = 5f; 
    GhoulState state; 

    void Start()
    {
        startPos = new Vector3();
        startPos = gameObject.transform.position;
        state = GhoulState.AWAIT;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GhoulState.STOP)
            return; 
        else if (state == GhoulState.MOVE)
        {
            Vector3 targPos = transform.position + transform.forward * Time.deltaTime * speed;
            if ((targPos - startPos).magnitude >= travel)
                state = GhoulState.STOP;
            
            transform.position = targPos; 
        }
        else if (state == GhoulState.AWAIT)
        {
            if ((player) && ((player.transform.position - transform.position).magnitude <= detection))
                state = GhoulState.MOVE; 
        }

    }
}
