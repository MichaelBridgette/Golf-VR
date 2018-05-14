using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTexture : MonoBehaviour {

    public string url = "http://www.gerrymoloney.com/golf/golfcourse.jpg";

    IEnumerator Start()
    {
        // Start a download of the given URL
        using (WWW www = new WWW(url))
        {
            // Wait for download to complete
            yield return www;

            // assign texture
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = www.texture;
        }
    }
}
