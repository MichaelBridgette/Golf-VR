using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase.Unity;
using Firebase;

public class getFile : MonoBehaviour {


    // public string url = "http://www.gerrymoloney.com/golf/golfcourse.jpg";

    /// <summary>
    /// Runs this code as soon as script is executed
    /// </summary>
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Set a flag here indiciating that Firebase is ready to use by your
                // application.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

        //URL to Firebase Database
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://fir-web-login-f0757.firebaseio.com/");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        DownloadViaURL();
    }

    /// <summary>
    /// Creates a Firebase filestream to download
    /// a file from Firebase Cloud Storage
    /// </summary>
    void DownloadViaURL()
    {
        Debug.Log("Called DownloadViaURL");
        FirebaseDatabase.DefaultInstance
       .GetReference("golf_course")
       .GetValueAsync().ContinueWith(task => {
           Debug.Log("Default Instance entered");
           if (task.IsFaulted)
           {
               Debug.Log("Error retrieving data from server");
           }
           else if (task.IsCompleted)
           {
               DataSnapshot snapshot = task.Result;

               string data_URL = snapshot.GetValue(true).ToString();

               //Start coroutine to download image
               StartCoroutine(AccessURL(data_URL));
           }
       });
    }

    /// <summary>
    /// Pulls image from URL passed to function
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    IEnumerator AccessURL(string url)
    {
        // string tmp_url = "http://www.gerrymoloney.com/golf/golfcourse.jpg";


        //Debug.Log("Accessing texture URL in database");
        using (WWW www = new WWW(url))
        {
            yield return www;
            Renderer r = GetComponent<Renderer>();
            r.material.mainTexture = www.texture;
            //r.material.SetTexture("texture", www.texture);
            Debug.Log("Texture URL: " + www.url);
        }
    }
}
