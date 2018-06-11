using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Unity;
using Firebase.Unity.Editor;
using Firebase;
using Firebase.Database;

public class DownloadCourses : MonoBehaviour {

	// On start, pull list of tier 1 elements from Firebases
	void Start () {

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

        //Datasnapshot to store query
        DataSnapshot _data;

        //Query entire database and store in variable;
        reference.OrderByKey().LimitToFirst(100).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                //Handle error
            }
            else if (task.IsCompleted)
            {
                Debug.Log("Result: " + task.Result);

                //Data snapshot of database
                _data = task.Result;
                //Create an iterator and assign IEnumberator for children of snapshot
                IEnumerable<DataSnapshot> course_iterator = _data.Children;
                //List to store all the course name elements
                List<string> course_names = new List<string>();

                foreach (DataSnapshot ds in course_iterator)
                {
                    course_names.Add(ds.GetValue(true).ToString());
                    foreach (string name in course_names)
                    {
                        Debug.Log("Course name: " + name.ToString());
                    }
                }

            }
        });      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
