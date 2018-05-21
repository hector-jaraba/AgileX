using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UIManager : MonoBehaviour {



	void Start () {
		
	}


    public void Launch(IScreenManager Screen)
    {
        Screen.Active();
    }

}
