using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Estado : MonoBehaviour {

    public int mejoraArma { get; set; }
    public string username;
    public GameObject name;
    
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
        username = name.GetComponent<InputField>().text;
    }

}
