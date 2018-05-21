using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsEnergy : MonoBehaviour {

    // Use this for initialization
    private BarManager barraEnergia;
    private int smallPotion = 20;
    private int bigPotion = 50;
 
    void Start () {
        barraEnergia = GameObject.Find("BarManager").GetComponent<BarManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (this.tag == "smallPotion")
                restoreSmallEnergy();
            else
                restoreBigEnergy();
            Destroy(this.gameObject);
        }
    }

  

    void restoreSmallEnergy()
    {
        int maxEnergy = 100;
        if (barraEnergia.getEnergy() <= maxEnergy - smallPotion)
        {
            barraEnergia.doEnergy(smallPotion);
        }
        else
        {
            barraEnergia.maxEnergy();
        }
    }

    void restoreBigEnergy()
    {
        int maxEnergy = 100;
        if (barraEnergia.getEnergy() <= maxEnergy - bigPotion)
        {
            barraEnergia.doEnergy(bigPotion);
        }
        else
        {
            barraEnergia.maxEnergy();
        }
    }
}
