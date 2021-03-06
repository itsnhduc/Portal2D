using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public GameObject shot;
        public Transform shotSpawn;
        public static int k=0; 


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {

                if (BoxController.grabbed == false && BoxController.hit.collider == null)
                {
                    k++;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    if (k % 2 == 0)
                    {
                        Destroy(GameObject.FindWithTag("Blue"));
                    }
                    else
                    {
                        Destroy(GameObject.FindWithTag("Orange"));
                    }
                }
                else
                {
                    Debug.Log(BoxController.hit.collider);
                    Debug.Log(BoxController.hit.transform.tag);
                }

            }
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

        }

        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
