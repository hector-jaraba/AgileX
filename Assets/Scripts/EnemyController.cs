using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speedEnemy = 1f;
    public float maxSpeedEnemy = 1f;
    private Rigidbody2D enemyRigidBody;

    // Use this for initialization
    void Start () {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        enemyRigidBody.AddForce(Vector2.right * speedEnemy);
        float limitedSpeed = Mathf.Clamp(enemyRigidBody.velocity.x, -maxSpeedEnemy, maxSpeedEnemy);
        enemyRigidBody.velocity = new Vector2(limitedSpeed, enemyRigidBody.velocity.y);

        if (enemyRigidBody.velocity.x > -0.01f && enemyRigidBody.velocity.x < 0.01f)
        {
            speedEnemy = -speedEnemy;
            enemyRigidBody.velocity = new Vector2(speedEnemy, enemyRigidBody.velocity.y);
        }

        if (speedEnemy < 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (speedEnemy > 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.SendMessage("EnemyKnockBack", transform.position.x);
            Debug.Log("A chocado contra la un enemigo");
        }
    }
}
