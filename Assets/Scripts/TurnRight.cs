using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TurnRight : Command
    {
        private PlayerMovement _controller;
        public TurnRight(PlayerMovement controller)
        {
            _controller = controller;
        }
        public override void Execute()
        {
            GameObject.FindAnyObjectByType<PlayerMovement>().Turn(PlayerMovement.Direction.Right);
        }
    }
