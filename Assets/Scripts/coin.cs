using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
    public int puntos = 5;

    private ContadorPuntosImplement contadorPuntos;
    private AudioSource audioSource;

    private void Awake()
    {
        contadorPuntos = GameObject.Find("ContadorPuntosText").GetComponent<ContadorPuntosImplement>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            contadorPuntos.SumarPuntos(puntos);
            audioSource.Play();
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Destroy(this.gameObject.GetComponent<SpriteRenderer>());
            Destroy(this.gameObject,1);
        }
    }


}
