using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePoint : MonoBehaviour
{
    GameObject Player;
    Wagon wagonScript;
    public Transform nextPointRight;
    public Transform nextPointLeft;
    public Transform nextPoint;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        wagonScript = Player.GetComponent<Wagon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wagonScript.right && nextPointRight!=null)
        {
            nextPoint = nextPointRight;
        }
        else if (wagonScript.left && nextPointLeft != null)
        {
            nextPoint = nextPointLeft;
        }

    }
}
