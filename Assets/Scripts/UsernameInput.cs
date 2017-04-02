using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour
{

    private InputField input;
    //public GUIText submitedScore;
    private bool allowEnter = false;
    private BackendAdapter ss = new BackendAdapter();
    void Start()
    {
        input = gameObject.GetComponent<InputField>();
        //submitedScore.enabled = false;
    }

    void Update()
    {
        if (/*input.isFocused*/ allowEnter && input.text != "" && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            UpdateScore();
        }
        else { allowEnter = input.isFocused; }

        GameObject.Find("Submit_Text").GetComponent<Text>();
        Text submitText = GameObject.Find("Submit_Text").GetComponent<Text>();
        if (BackendAdapter.scoresUpdated == true && !submitText.text.Contains("✓"))
        {
            //submitedScore.enabled = true;
            submitText.text += "✓";
        }
    }

    public void UpdateScore()
    {
        Debug.Log("Update Scores");
        StartCoroutine(ss.UpdateDB(input.text, UnityStandardAssets._2D.Platformer2DUserControl.k));
        input.text = "";
        allowEnter = false;
    }
}
