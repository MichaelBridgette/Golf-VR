using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour {
    public Text text;
    float alpha= 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (alpha >= 0)
        {
            alpha -= 0.01f;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

        if(Input.touches.Length > 0 && alpha<=0)
        {
            Application.LoadLevel("main");
        }
	}
}
