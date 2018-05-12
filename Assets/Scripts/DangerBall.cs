using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBall : MonoBehaviour
{

    public float distanceMovement;
    public float speed;
    public float rotationSpeed;
    Vector3 startPosition;
    float finishPosition;
    bool up;

    // Use this for initialization
    void Start()
    {
        
        distanceMovement = 6f;
        //speed = 2.5f;
        up = true;
        startPosition = GetComponent<Transform>().position;
        finishPosition = startPosition.y + distanceMovement;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.World);
        if ((transform.position.y <= finishPosition) && up)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else {
            up = false;
        }

        if ((transform.position.y >= startPosition.y) && !up)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            

        }
        else {
            up = true;
        }
        

        // if (!startPosition.Equals(finishPosition)) {

        // }

    }
}