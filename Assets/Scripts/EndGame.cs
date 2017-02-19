using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public GUIText endGame;

	// Use this for initialization
	void Start () {
        endGame.text = "";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log(coll.transform.tag);
        if (coll.transform.tag == "Player") {
            endGame.text = "Level Complete. Portals used:" + UnityStandardAssets._2D.Platformer2DUserControl.k;
        } }
}
