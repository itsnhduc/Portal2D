using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public GUIText endGame;

    public Button nextLevel;

	// Use this for initialization
	void Start () {
        endGame.text = "";
        nextLevel.interactable = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log(coll.transform.tag);
        if (coll.transform.tag == "Player") {
            endGame.text = "Level Complete. Portals used:" + UnityStandardAssets._2D.Platformer2DUserControl.k;
            nextLevel.interactable = true;
        } }
}
