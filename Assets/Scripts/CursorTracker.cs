using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTracker : MonoBehaviour
{

    void Update()
    {
        try
        {

            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 playerScaleRight = new Vector3(1, 1, 1);
            Vector3 playerScaleLeft = new Vector3(-1, 1, 1);

            if (cursorPos.x < playerPos.x)
            {
                // look to the left
                GameObject.FindGameObjectWithTag("Player").transform.localScale = playerScaleLeft;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").transform.localScale = playerScaleRight;
            }
        }
        catch (Exception e)
        {

        }
    }
}
