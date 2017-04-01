using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : MonoBehaviour {

    public GUIText gameover;
	// Use this for initialization
	void Start () {
        gameover.text = "GAME OVER" + "\nYou score is: " + UnityStandardAssets._2D.Platformer2DUserControl.k;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
