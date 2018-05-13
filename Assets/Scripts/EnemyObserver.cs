using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObserver : MonoBehaviour {

    public float visionRadius = 2.5f;
    public float explosionRadius = 1.25f;
    public float speed = 2.5f;
    GameObject player;
    Animator anim;
    Rigidbody2D rigidBody2D;
    SpriteRenderer spriteRenderer;
    AnimatorStateInfo stateInfo;
    bool explote = false;
    bool die = false;
    bool run = false;
    bool sleeping = true;
    bool blastWave = true;
    bool isExploding;
    bool idle = false;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        isExploding = stateInfo.IsName("EnemyObserver_explode");
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if ((dist < visionRadius) && !explote && !die)
        {
            idle = true;

            if (sleeping)
            {
                StartCoroutine(EnemyAwake(0.3f));
                sleeping = false;
            }

            if (run)
            {
                Transform targetToFollow = player.transform;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetToFollow.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
                spriteRenderer.flipX = (targetToFollow.position.x >= transform.position.x) ? true : false;
            }



        }
        else if (explote && !die)
        {
            StartCoroutine(EnemyExplote(1f));
            die = true;

        }
        else if((dist >= visionRadius) && !explote && !die) {
            if (idle)
            {
                StartCoroutine(EnemySleep(1f));
                sleeping = true;
            }           
        }

        if (isExploding)
        {
            float playbackTime = stateInfo.normalizedTime;
            if ((playbackTime > 0.33 && playbackTime<0.99) && (dist < explosionRadius))
            {
                if (blastWave) {
                    player.SendMessage("SimpleDamage", this.transform.position.x);
                    blastWave = false;
                }
                
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player") {
            explote = true;
        }
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }

    IEnumerator EnemyAwake(float awakeTime) {
        anim.SetBool("Awake", true);
        yield return new WaitForSeconds(awakeTime);
        anim.SetBool("Run", true);
        run = true;
    }

    IEnumerator EnemyExplote(float exploteTime)
    {
        run = false;
        anim.SetTrigger("Explote");
        anim.SetBool("Awake", false);
        anim.SetBool("Run", false);
        yield return new WaitForSeconds(exploteTime);
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
        yield return new WaitForSeconds(exploteTime);
        Destroy(this.gameObject);
        
    }

    IEnumerator EnemySleep(float sleepTime)
    {
        anim.SetBool("Awake", true);
        anim.SetBool("Run", false);
        yield return new WaitForSeconds(sleepTime);
        anim.SetBool("Awake", false);
        anim.SetBool("Run", false);
        idle = false;

    }
}
