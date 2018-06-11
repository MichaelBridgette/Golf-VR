using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private int course = 0;
    public Dropdown dp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToNextScene()
    {
        //Deprecated
        //Application.LoadLevel("scene2");
        SceneManager.LoadScene("scene2");
    }
    public void GoToScene3()
    {
        //Deprecated
        //Application.LoadLevel("scene3");
        SceneManager.LoadScene("scene3");
    }
    public void GoToTeeBox()
    {
        //Deprecated
        //Application.LoadLevel("scene4");
        SceneManager.LoadScene("scene4");
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetCourse()
    {

        if (dp.value == 0)
        {
            course = 1;
        }
        else if (dp.value == 1)
        {
            course = 2;
        }
        else
        {
            course = 3;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetCourseTwo()
    {
        course = 2;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void SetCourseThree()
    {
        course = 3;
    }
}
