using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGround : MonoBehaviour {

    public float finishPosition = -10f;
    public float speed = 2f;
    float initialPosition;

    bool fall = false;


	// Use this for initialization
	void Start () {
        initialPosition = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {



        if (fall){
            if(transform.position.y>finishPosition){
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

        }
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Player" && !fall)
        {
            StartCoroutine("CorrutineFall");
        }
	}


    IEnumerator CorrutineFall(){

        transform.position = new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y-0.05f, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        yield return new WaitForSeconds(0.5f);
        fall = true;
    }




}
