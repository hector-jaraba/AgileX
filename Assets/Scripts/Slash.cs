using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {

    // Use this for initialization
    public float waitBeforeDestroy;
    public Vector2 movimiento;
    public float speed;

	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(transform.position.x, transform.position.y, 0) * speed * Time.deltaTime;
		
	}

    IEnumerator OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.tag == "Object")
        {
            yield return new WaitForSeconds(waitBeforeDestroy);
            Destroy(gameObject);

        }
        else if (colision.tag != "Player" && colision.tag != "Attack")
            Destroy(gameObject);
    }
}
