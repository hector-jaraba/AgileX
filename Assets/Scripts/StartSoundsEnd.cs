using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSoundsEnd : MonoBehaviour {

    public AudioClip audioLaught;
    AudioSource audio;
    bool playOnce = false;
    GameObject mainCamera;


	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        mainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.tag == "Player" && !playOnce){
            StartCoroutine("CorrutineAudio");
            playOnce = true;
            
        }
	}

    IEnumerator CorrutineAudio(){

        audio.PlayOneShot(audioLaught);
        yield return new WaitForSeconds(1.3f);
        mainCamera.GetComponent<AudioSource>().Play();


    }
}
