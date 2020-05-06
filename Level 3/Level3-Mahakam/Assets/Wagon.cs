using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target;
    public GameObject wagonObject;
    public GameObject characters;

    public bool left, right = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target.position);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //  Inclination
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            wagonObject.transform.eulerAngles =  new Vector3(wagonObject.transform.eulerAngles.x, wagonObject.transform.eulerAngles.y, 50);
            right = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            wagonObject.transform.eulerAngles = new Vector3(wagonObject.transform.eulerAngles.x, wagonObject.transform.eulerAngles.y, -50);
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            wagonObject.transform.eulerAngles = new Vector3(wagonObject.transform.eulerAngles.x, wagonObject.transform.eulerAngles.y, 0);
            right = left = false;
        }

        //  Crouch
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            characters.transform.position = new Vector3(characters.transform.position.x, characters.transform.position.y - 4, characters.transform.position.z);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            characters.transform.position = new Vector3(characters.transform.position.x, characters.transform.position.y + 4, characters.transform.position.z);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WayPoint")
        {
            target = other.gameObject.GetComponent<Waypoints>().nextPoint;
            transform.LookAt(target.position);
        }
        if (other.tag == "ChangePoint")
        {
            target = other.gameObject.GetComponent<ChangePoint>().nextPoint;
            transform.LookAt(target.position);
        }
    }
}
