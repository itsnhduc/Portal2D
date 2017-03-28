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

    IEnumerator Update(string name, int score)
    {
        // Supply it with a string representing the players name and the players score.
        string post_url = POST_ENDPOINT + "name=" + WWW.EscapeURL(name) + "&score=" + score;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
        else
        {
            print("response:" + hs_post.text);
        }

    }

//IEnumerator Update(string name, int score)
    //{

    //    // Create a form object for sending high score data to the server
    //    WWWForm form = new WWWForm();
    //    // The name of the player submitting the scores
    //    form.AddField("name", name);
    //    // The score
    //    form.AddField("score", score);

    //    // Create a download object
    //    WWW download = new WWW(GET_ENDPOINT, form);

    //    // Wait until the download is done
    //    yield return download;

    //    if (!string.IsNullOrEmpty(download.error))
    //    {
    //        print("Error downloading: " + download.error);
    //    }
    //    else
    //    {
    //        // show the highscores
    //        Debug.Log(download.text);
    //    }
    //}
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
