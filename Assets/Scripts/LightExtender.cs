using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class LightExtender : MonoBehaviour {

        public GameObject lightBridgeHead;
        public GameObject lightBridgeTail;
        public GameObject lightBridgeBody;
        public GameObject lightFunnelHead;
        public GameObject lightFunnelTail;
        public GameObject lightFunnelBody;

        //public void process(Vector2 targetPos, bool otherPortalBlue, GameObject startWall)
        public void process()
        {
            // destroy old extended light object
            foreach (GameObject ext in GameObject.FindGameObjectsWithTag("Extended"))
            {
                Debug.Log("Removing " + ext.name);
                Destroy(ext);
            }

            // get blue and orange portals
            GameObject bluePortal = GameObject.FindGameObjectWithTag("Blue");
            GameObject orangePortal = GameObject.FindGameObjectWithTag("Orange");
            if (bluePortal != null && orangePortal != null)
            {
                Debug.Log("Processing potential extension of light object.");
                Debug.Log("Blue: " + bluePortal.transform.position);
                Debug.Log("Orange: " + orangePortal.transform.position);
                // get tails of light objects
                GameObject gameBridgeTail = GameObject.Find("_LightBridgeTail");
                GameObject gameFunnelTail = GameObject.Find("_LightFunnelTail");
                Debug.Log("gameBridgeTail: " + gameBridgeTail.transform.position);
                Debug.Log("gameFunnelTail: " + gameFunnelTail.transform.position);

                // decide whether to extend and what to extend
                GameObject extendPortal;
                GameObject lightHead;
                GameObject lightBody;
                GameObject lightTail;
                if (bluePortal.transform.position == gameBridgeTail.transform.position)
                {
                    extendPortal = orangePortal;
                    lightHead = lightBridgeHead;
                    lightBody = lightBridgeBody;
                    lightTail = lightBridgeTail;
                }
                else if (bluePortal.transform.position == gameFunnelTail.transform.position)
                {
                    extendPortal = orangePortal;
                    lightHead = lightFunnelHead;
                    lightBody = lightFunnelBody;
                    lightTail = lightFunnelTail;
                }
                else if (orangePortal.transform.position == gameBridgeTail.transform.position)
                {
                    extendPortal = bluePortal;
                    lightHead = lightBridgeHead;
                    lightBody = lightBridgeBody;
                    lightTail = lightBridgeTail;
                }
                else if (orangePortal.transform.position == gameFunnelTail.transform.position)
                {
                    extendPortal = bluePortal;
                    lightHead = lightFunnelHead;
                    lightBody = lightFunnelBody;
                    lightTail = lightFunnelTail;
                }
                else
                {
                    return;
                }


                // extend
                List<GameObject> walls = getWalls();
                GameObject startWall = walls.Find(wall => wall.transform.position == extendPortal.transform.position);
                Vector2 extDir = getExtendDirection(startWall);
                GameObject endWall = null;
                
                createExt(lightHead, startWall.transform.position, startWall);

                for (Vector2 tempPos = startWall.transform.position; endWall == null; tempPos += extDir)
                {
                    endWall = walls.Find(wall => 
                        (Vector2) wall.transform.position == tempPos &&
                        wall.transform.position != startWall.transform.position
                    );
                    if (tempPos != (Vector2) startWall.transform.position)
                    {
                        if (endWall == null || tempPos != (Vector2)endWall.transform.position)
                        {
                            createExt(lightBody, tempPos, startWall);
                        }
                    }
                }

                createExt(lightTail, endWall.transform.position, startWall);
                Debug.Log("Extended " + lightBody.name + " from " + extendPortal.name + " with dir " + extDir);
            }
        }

        private List<GameObject> getWalls()
        {
            List<GameObject> result = new List<GameObject>();
            foreach (Transform child in GameObject.Find("Tiles").transform)
            {
                result.Add(child.gameObject);
            }
            return result;
        }

        private void createExt(GameObject ext, Vector2 pos, GameObject startWall)
        {
            GameObject gameExt = Instantiate(ext, pos, Quaternion.Euler(0, 0, 0));
            gameExt.tag = "Extended";
            switch (startWall.tag)
            {
                case "RightWall": gameExt.transform.rotation = Quaternion.Euler(0, 0, 180); break;
                case "Ceiling": gameExt.transform.rotation = Quaternion.Euler(0, 0, -90); break;
                case "Floor": gameExt.transform.rotation = Quaternion.Euler(0, 0, 90); break;
            }
        }

        private Vector2 getExtendDirection(GameObject startWall)
        {
            switch (startWall.tag)
            {
                case "Floor":
                    return Vector2.up;
                case "Ceiling":
                    return Vector2.down;
                case "LeftWall":
                    return Vector2.right;
                case "RightWall":
                    return Vector2.left;
                default:
                    return Vector2.zero;
            }
        }

    }
}
