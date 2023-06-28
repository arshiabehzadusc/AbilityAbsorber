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
    private DateTime startTime;

    void Start()
    {
        this.startTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Send(DateTime deadtime, Vector2 deadposition, string enemy)
    {
        Debug.Log("try to send to google form");
        TimeSpan timePlayed = DateTime.Now - this.startTime;
        StartCoroutine(Post(deadtime.ToString(), deadposition.ToString(), enemy,timePlayed.ToString()));
    }

    private IEnumerator Post(string deadtime, string deadposition, string enemy,string timePlayed)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.2004368566", deadtime);
        form.AddField("entry.1825431539", deadposition);
        form.AddField("entry.1728689000", enemy);
        form.AddField("entry.370185319", timePlayed);

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