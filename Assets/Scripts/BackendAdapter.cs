using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackendAdapter : MonoBehaviour
{

    public const string GET_ENDPOINT = @"http://localhost:3000/api/entries";

    IEnumerator Start()
    {
        WWW req = new WWW(GET_ENDPOINT);
        yield return req;
        string jsonString = "{\"data\":" + req.text + "}";
        Response json = JsonUtility.FromJson<Response>(jsonString);

        // sort player data
        var sortedData = new List<Response.Model>(json.data);
        sortedData.Sort((p1, p2) =>
        {
            if (p1.score < p2.score) return 1;
            else if (p1.score > p2.score) return -1;
            else return 0;
        });

        // display player data
        string numCol = "" + Environment.NewLine;
        string nameCol = "Name" + Environment.NewLine;
        string scoreCol = "Score" + Environment.NewLine;
        int num = 0;
        sortedData.ForEach(player =>
        {
            num++;
            numCol += num + "." + Environment.NewLine;
            nameCol += player.name + Environment.NewLine;
            scoreCol += player.score + Environment.NewLine;
        });
        GameObject.Find("NumColumn").GetComponent<Text>().text = numCol;
        GameObject.Find("NameColumn").GetComponent<Text>().text = nameCol;
        GameObject.Find("ScoreColumn").GetComponent<Text>().text = scoreCol;
    }

    void Update()
    {

    }
}

[Serializable]
public struct Response
{
    [Serializable]
    public struct Model
    {
        public string id;
        public string name;
        public int score;
    }
    public Model[] data;
}
