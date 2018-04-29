using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public GameObject follow;
    public Vector2 minCamPosition, maxCamPosition;
    public float smoothTime;

    private Vector2 velocity;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref velocity.x, smoothTime);
        float posy = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPosition.x, maxCamPosition.x),
            Mathf.Clamp(posy, minCamPosition.y, maxCamPosition.y),
            transform.position.z
           );
	}
}
