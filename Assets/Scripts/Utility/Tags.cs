using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MA.Util
{
    public class Tags
    {
        public class Layers
        {
            public string Env = "env";
        }
        public class Keybinds
        {
            public const KeyCode Left = KeyCode.A;
            public const KeyCode Right = KeyCode.D;
            public const KeyCode Jump = KeyCode.J;
            public const KeyCode Crouch = KeyCode.I;
            public const KeyCode Dash = KeyCode.U;
            // attack
        }
        public class Anim {
            public const string Crouch = "crouch";
            public const string Idle = "idle";
            public const string Run = "run";
            public const string Jump = "jump";
            public const string Dash = "dash";
            public const string Fall = "fall";
            public const string Attack = "attack";
        }
    }
}