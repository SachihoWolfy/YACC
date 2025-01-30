using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurnLeft : Command
{
    private PlayerMovement _controller;
    public TurnLeft(PlayerMovement controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        GameObject.FindAnyObjectByType<PlayerMovement>().Turn(PlayerMovement.Direction.Left);
    }
}

