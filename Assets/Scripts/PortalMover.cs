using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMover : MonoBehaviour {

    public GameObject otherPortal;
    public static string Orange_portal_pos="";
    public static string Blue_portal_pos="";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ThroughPortal(float z, float h, PortalMover here, Collision2D there)
    {
        if (here.tag == "Orange")
        {
            there.transform.position = new Vector2(GameObject.FindWithTag("Blue").transform.position.x + z,
                GameObject.FindWithTag("Blue").transform.position.y + h);
        }
        else
        {
            there.transform.position = new Vector2(GameObject.FindWithTag("Orange").transform.position.x + z,
         GameObject.FindWithTag("Orange").transform.position.y + h);
        }
    }
    public static int t; 
    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Player") {
            if (this.transform.CompareTag("Blue")) {
                PortalLocation(Orange_portal_pos, this, other);
            }
            if (this.transform.CompareTag("Orange")){
                PortalLocation(Blue_portal_pos, this, other);
            }
        } }
    void PortalLocation(string t, PortalMover here, Collision2D other) {
        switch (t)
        {
            case "LeftWall":
                ThroughPortal(0.7F, 0, here, other);
                break;
            case "RightWall":
                ThroughPortal(-0.7F, 0, here, other);
                break;
            case "Ceiling":
                ThroughPortal(0, -1F, here, other);
                break;
            case "Floor":
                ThroughPortal(0, 1F, here, other);
                break;
            default: break;
        }
    }
}
