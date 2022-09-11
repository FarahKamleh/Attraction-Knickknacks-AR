using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class EmeryvilleCaliforniaTime : MonoBehaviour
{
    public GameObject timeTextObject;

    // EDIT: use WorldTimeAPI to get the current local time of Reedsport, Oregan in AM/PM
    string url = "http://worldtimeapi.org/api/timezone/America/Los_Angeles";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetDataFromWeb", 0f, 10f);
    }

    void GetDataFromWeb()
    {
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.result ==  UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the time data to make sure it makes sense
                // Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

                // this code will NOT fail gracefully, so make sure you have
                // your API key before running or you will get an error

            	// grab the current time and simplify it if needed
                int startTime = webRequest.downloadHandler.text.IndexOf("datetime", 0);
                int endTime = webRequest.downloadHandler.text.IndexOf(",", startTime);
                string twentyFourTime = webRequest.downloadHandler.text.Substring(startTime + 22, (endTime - startTime - 36));
                Debug.Log("twentyFourTime is " + twentyFourTime);

                timeTextObject.GetComponent<TextMeshPro>().text = "" + twentyFourTime;

            }
        }
    }
}