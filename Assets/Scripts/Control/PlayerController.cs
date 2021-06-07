using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MA.Movement;
using MA.Util;
using System;

namespace MA.Control
{
    public class PlayerController : MonoBehaviour
    {

        Mover mover;
        Vector2 scale;

        // input 
        short x = 0;
        bool jump = false;
        bool crouch = false;
        bool dash = false;

        private void Awake()
        {
            mover = GetComponent<Mover>();

        }

        // Update is called once per frame
        void Update()
        {
            GetInput();
            mover.Move(x, jump, crouch, dash);
        }


        public void GetInput()
        {
            if (Input.GetKey(Tags.Keybinds.Left)) x = -1;
            else if (Input.GetKey(Tags.Keybinds.Right)) x = 1;
            else x = 0;

            crouch = Input.GetKey(Tags.Keybinds.Crouch) ? true : false;
            jump = Input.GetKey(Tags.Keybinds.Jump) ? true : false;
            dash = Input.GetKeyDown(Tags.Keybinds.Dash) ? true : false;
        }

    }

}