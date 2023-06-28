using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SendToGoogle : MonoBehaviour
{
    // Start is called before the first frame update
    public string URL;
    private string deadtime;
    private string deadposition;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Send(DateTime deadtime, Vector2 deadposition)
    {
        Debug.Log("try to send to google form");

        StartCoroutine(Post(deadtime.ToString(), deadposition.ToString()));
    }

    private IEnumerator Post(string deadtime, string deadposition)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.2004368566", deadtime);
        form.AddField("entry.1825431539", deadposition);
        form.AddField("entry.1728689000", "bat");
        
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("google form failed");
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}