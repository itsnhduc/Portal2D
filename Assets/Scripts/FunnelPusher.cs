using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelPusher : MonoBehaviour {

    private const float SPEED = 0.02f;
    
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Player entered light funnel");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            int rotation = (int)transform.rotation.eulerAngles.z;
            Vector3 pushOffset = getPushOffset(rotation);
            Vector3 slideOffset = getSlideOffset(player, rotation);
            Debug.Log("pushOffset = " + pushOffset);
            Debug.Log("slideOffset = " + slideOffset);
            player.transform.position += pushOffset + slideOffset;
        }
    }

    private Vector3 getPushOffset(int rotation)
    {
        switch (rotation)
        {
            case 0:
                Debug.Log("Pushing right");
                return SPEED * Vector2.right;
            case 180:
                Debug.Log("Pushing left");
                return SPEED * Vector2.left;
            case 90:
                Debug.Log("Pushing up");
                return SPEED * Vector2.up;
            case -90:
                Debug.Log("Pushing down");
                return SPEED * Vector2.down;
            default:
                Debug.Log("ERR: Angle unrecognized");
                return new Vector3();
        }
    }

    private Vector3 getSlideOffset(GameObject player, int rotation)
    {
        switch (rotation)
        {
            case 0:
            case 180:
                Debug.Log("Sliding vertically");
                return new Vector3(0, -player.transform.position.y + transform.position.y, 0);
            case 90:
            case -90:
                Debug.Log("Sliding horizontally");
                return new Vector3(-player.transform.position.x + transform.position.x, 0, 0);
            default:
                return new Vector3();
        }
        //Vector3 rawDiff = player.transform.position - transform.position;
        //Vector3 diff = new Vector3();
        //switch (rotation)
        //{
        //    case 0:
        //    case 180:
        //        Debug.Log("Sliding vertically");
        //        diff = new Vector3(0, rawDiff.y, 0);
        //        break;
        //    case 90:
        //    case -90:
        //        Debug.Log("Sliding horizontally");
        //        diff = new Vector3(rawDiff.x, 0, 0);
        //        break;
        //}
        //return new Vector3(
        //    diff.x == 0 ? 0 : SPEED * diff.x / Mathf.Abs(diff.x),
        //    diff.y == 0 ? 0 : SPEED * diff.y / Mathf.Abs(diff.y),
        //    0
        //);
    }
}
