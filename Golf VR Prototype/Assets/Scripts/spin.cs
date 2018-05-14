using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {
    public float spinValue=90.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * spinValue * Time.deltaTime);
	}

    public void Flip()
    {
        spinValue = -spinValue;
    }
}
