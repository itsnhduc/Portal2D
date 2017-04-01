using Assets.Scripts;
using UnityEngine;

public class PortalOpener : MonoBehaviour {

    public GameObject bluePortal;
    public GameObject orangePortal;

    void openPortal(float rot, Collision2D coll) {
        Vector2 realPosition = new Vector2(
            Mathf.Round(this.transform.position.x), 
            Mathf.Round(this.transform.position.y));

        if (UnityStandardAssets._2D.Platformer2DUserControl.k % 2 == 0)
        {
            Instantiate(bluePortal, realPosition, Quaternion.Euler(0, 0, rot));
            PortalMover.Blue_portal_pos = coll.transform.tag;
            Debug.Log("Blue Portal created at " + realPosition);
            //GameObject.Find("LightExtender")
            //    .GetComponent<LightExtender>()
            //    .process(coll.transform.position, false, coll.gameObject);
        }
        else
        {
            Instantiate(orangePortal, realPosition, Quaternion.Euler(0, 0, rot));
            PortalMover.Orange_portal_pos = coll.transform.tag;
            orangePortal = coll.gameObject;
            Debug.Log("Orange Portal created at " + realPosition);
            //GameObject.Find("LightExtender")
            //    .GetComponent<LightExtender>()
            //    .process(coll.transform.position, true, coll.gameObject);
        }
       // GameObject.Find("LightExtender").GetComponent<LightExtender>().process();

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag != "Player")
        {
            Destroy(gameObject);
        }
        if (coll.transform.name.Contains("Edge") || coll.transform.name.Contains("Corner"))
        {
            Debug.Log(coll.transform.name);
            switch (coll.transform.tag)
            {
                case "LeftWall": openPortal(0, coll); PortalMover.t = 1; break;
                case "RightWall": openPortal(0, coll); PortalMover.t = 2; break;
                case "Ceiling": openPortal(90, coll); PortalMover.t = 3; break;
                case "Floor": openPortal(90, coll); PortalMover.t = 4; break;
            }
        }
    } 
}
