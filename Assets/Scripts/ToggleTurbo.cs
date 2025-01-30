using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class ToggleTurbo : Command
    {
        private PlayerMovement _controller;

        public ToggleTurbo(PlayerMovement controller)
        {
            _controller = controller;
        }
        public override void Execute()
        {
            _controller.ToggleTurbo();
        }
    }
