using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {

    public GUIText gameover;
	// Use this for initialization
	void Start () {
        int portalCount = UnityStandardAssets._2D.Platformer2DUserControl.k;
        GameObject.Find("PortalCount").GetComponent<Text>().text += portalCount;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
