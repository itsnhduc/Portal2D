using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameInput : MonoBehaviour {

    private InputField input;
	private bool allowEnter=false;
	private BackendAdapter ss = new BackendAdapter();
    void Start()
    {        
        input = gameObject.GetComponent<InputField>();
       
    }

    void Update() {
        if (/*input.isFocused*/ allowEnter && input.text != "" && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            //DoSomething
            Debug.Log("Update Scores");
			StartCoroutine(ss.UpdateDB(input.text, UnityStandardAssets._2D.Platformer2DUserControl.k));
            input.text = "";
            allowEnter=false;
        }
        else { allowEnter = input.isFocused; }
    }
}
