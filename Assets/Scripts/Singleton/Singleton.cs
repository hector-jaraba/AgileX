using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

	public static Singleton Instance { get; private set; }

    public int puntosTotal = 40;

    private void Awake()
    {
        //We want to keep the first instance
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
