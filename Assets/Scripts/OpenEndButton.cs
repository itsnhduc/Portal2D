using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEndButton : MonoBehaviour {

    public static int l=2;
    public GameObject endLevel;

    // Use this for initialization
    void Start () {
        endLevel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.transform.tag);
        if (other.transform.tag == "Player" || other.transform.tag == "Crate")
        {
            endLevel.SetActive(true);
            l = 0;
        }
    }
    void OnCollisionExit2D(Collision2D col) {
       endLevel.SetActive(false);
            l = 2;
    }
    }
