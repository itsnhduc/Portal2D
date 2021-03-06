﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{

    public GUIText endGame;

    public Button nextLevel;

    // Use this for initialization
    void Start()
    {
        endGame.text = "";
        nextLevel.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            print("Level completed");
            Destroy(coll.gameObject);
            endGame.text = "Level Complete. Portals used:" + UnityStandardAssets._2D.Platformer2DUserControl.k;
            nextLevel.interactable = true;
            GameObject.Find("Button_NextLevel").GetComponent<Image>().enabled = true;
        }
    }
}
