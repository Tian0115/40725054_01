using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tian
{
    public class PlayController : MonoBehaviour
    {
        #region Data

        Rigidbody2D playerRig2D;
        public GameObject player;

        public Animator animator;
        //public Rigidbody2D rig;

        public SpriteRenderer sP;

        [Header("Player Force")]
        public float Forcespeed;

        [Header("Animator")]

        public Animator an;
        public string idle = "idle";


        #endregion

        #region
        void Start()
        {
            playerRig2D = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerRig2D.AddForce(new Vector2(Forcespeed, 0));

                if(sP.flipX == false)
                {
                    sP.flipX = true;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                playerRig2D.AddForce(new Vector2(-Forcespeed, 0));

                if(sP.flipX == true)
                {
                    sP.flipX = false;
                }
            }
            else if (Input.GetKey(KeyCode.W))
            {
                playerRig2D.AddForce(new Vector2(0, Forcespeed));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                playerRig2D.AddForce(new Vector2(0, -Forcespeed));
            }
        }
        #endregion
    }
}


