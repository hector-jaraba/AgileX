using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour {


    public GameObject energiaVerde;
    public GameObject energiaNegra;

    public GameObject vida;
    public GameObject daño;

    public GameObject player;
    private PlayerController playerScript;

    private bool flag = true;



    public float energy = 100;
    public float damage = 100;




    float timer = 0.0f;
    float timeMax = 0.05f;
    float increment = 0.0f;

    int tiempo = 50;

    // Use this for initialization
    void Start () {
        energiaVerde = GameObject.Find("EnergiaVerde");
        energiaNegra = GameObject.Find("EnergiaNegra");

        vida = GameObject.Find("Vida");
        daño = GameObject.Find("Daño");

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();

        damage -= 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        ActualizarHealthLifeBar();
	}

    public void ActualizarHealthLifeBar()
    {

        timer += Time.deltaTime;
        increment = 0.2f;

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow)) && energy >= 0)
        {
            energy -= increment;
            flag = false;
        }
        else
        {
            if (energy < 100 && flag)
            {
                energy += 0.3f;
                flag = false;
            }
        }

        energiaVerde.transform.localScale = new Vector2(energy / 100f, 1);
        vida.transform.localScale = new Vector2(damage / 100f, 1);

        // flag para controlar que solo crezca la energia cada 5 segundos
        if (timer >= timeMax)
        {
            flag = true;
            timer = 0.0f;

        }


        // Si se queda sin energia o aparece alguna pantalla UI no se puede mover        
        if (energy <= 0)
        {
            player.SendMessage("DisableMovement");
        }
        else if (energy > 5 && !playerScript.screenUI)
        {
            player.SendMessage("EnableMovement");
        }
        
        
    }

    public void maxDamage()
    {
        damage = 0;
    }

    public void maxEnergy()
    {
        energy = 100;
    }

    public void doDamage(int value)
    {
        damage += value;
    }

    public void doEnergy(int num)
    {
        energy += num;
    }

    public float getDamage()
    {
        return damage;
    }

    public float getEnergy()
    {
        return energy;
    }

    public void setDamage(int value)
    {
        damage = value;
    }
}
