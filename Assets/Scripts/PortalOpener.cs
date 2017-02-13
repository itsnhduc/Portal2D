using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOpener : MonoBehaviour {

    public GameObject portal;
    public GameObject portal2;
    

    void openPortal(float rot, Collision2D other) {
        if (UnityStandardAssets._2D.Platformer2DUserControl.k % 2 == 0)
        {
            Instantiate(portal, new Vector2(this.transform.position.x,
            this.transform.position.y), Quaternion.Euler(0, 0, rot));
            PortalMover.Blue_portal_pos = other.transform.tag;
        }
        else
        {
            Instantiate(portal2, new Vector2(this.transform.position.x,
          this.transform.position.y), Quaternion.Euler(0, 0, rot));
            PortalMover.Orange_portal_pos = other.transform.tag;
        }
     
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.transform.tag != "Player")
        {
            Destroy(gameObject);
            Debug.Log(coll.transform.name);
            if (coll.transform.tag== "LeftWall" || coll.transform.tag== "RightWall") {
                openPortal(0, coll);
                if (coll.transform.tag == "LeftWall")
                {
                    PortalMover.t = 1;
                }
                else { PortalMover.t = 2; }
            }
            if (coll.transform.tag == "Ceiling" || coll.transform.tag == "Floor") {
                openPortal(90, coll);
                if (coll.transform.tag == "Ceiling") {
                     PortalMover.t = 3; }
                else { PortalMover.t = 4; }
            }
            
        }
    } 
    }
