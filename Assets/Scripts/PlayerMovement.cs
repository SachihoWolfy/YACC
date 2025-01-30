using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum Direction
    {
        Left = -1, Right = 1
    }

    public Rigidbody rb;
    public PlayerCollision pc;
    public float forwardForce = 4000f;
    public float sideForce = 70f;
    public bool _isTurboOn;
    public float turboFowardMultiplier = 1.1f;
    public float turboTurnMultiplier = 1.1f;

    public float curTurboF = 1f;
    public float curTurboT = 1f;

    private void Start()
    {
        pc = gameObject.AddComponent<PlayerCollision>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if(rb.position.y < -1f)
        {
            pc.Die();
        }
    }
    public void Turn(Direction direction)
    {
        if (enabled)
        {
            if (direction == Direction.Left)
                rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if (direction == Direction.Right)
                rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

    }
    public void ResetPosition()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        transform.rotation = Quaternion.identity;
        enabled = true;
    }
    public void ToggleTurbo()
    {
        _isTurboOn = !_isTurboOn;
        Debug.Log("Turbo Active: " + _isTurboOn.ToString());
    }


}
