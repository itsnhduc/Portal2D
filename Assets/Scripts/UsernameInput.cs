using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour {

    public InputField input;
    private bool allowEnter;
    public Canvas canvas;
    private SaveScores ss = new SaveScores();
    void Start()
    {        
        input = gameObject.GetComponent<InputField>();
        canvas = gameObject.GetComponent<Canvas>();
       
    }

    void Update() {
        if (/*input.isFocused*/ allowEnter && input.text != "" && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            //DoSomething
            Debug.Log("Update Scores");
            StartCoroutine(ss.PostScores(input.text, UnityStandardAssets._2D.Platformer2DUserControl.k));
            input.text = "";
            allowEnter=false;
        }
        else { allowEnter = input.isFocused; }
    }
}
