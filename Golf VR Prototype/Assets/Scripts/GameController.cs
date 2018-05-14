using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToNextScene()
    {
        Application.LoadLevel("scene2");
    }
    public void GoToScene3()
    {
        Application.LoadLevel("scene3");
    }
    public void GoToTeeBox()
    {
        Application.LoadLevel("scene4");
    }
}
