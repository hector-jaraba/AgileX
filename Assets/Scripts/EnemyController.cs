using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speedEnemy = 1f;
    public int life = 3;
    public float maxSpeedEnemy = 1f;
    private Rigidbody2D enemyRigidBody;
    bool attacking = false;
    bool jump = false;

    // Use this for initialization
    void Start () {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (life <=0) {
            Destroy(this.gameObject);
        }  

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

        if(jump){
            enemyRigidBody.AddForce(Vector2.up * 25 * 2, ForceMode2D.Impulse);
            jump = false;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.SendMessage("EnemyKnockBack", transform.position.x);
            Debug.Log("A chocado contra la un enemigo");
        }

        if (collision.tag == "Attack" && !attacking) {
            life -= 1;
            jump = true;
            attacking = true;
            Debug.Log(life);
        }
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        if(collision.tag == "Attack"){
            attacking = false;
            
        }
	}




}
