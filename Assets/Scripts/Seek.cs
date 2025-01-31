using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    private static PlayerMovement player;
    private Rigidbody rb;
    private float distance;
    private Vector3 dir;
    private float curSpeed;

    public float maxSpeed = 5f;
    public float activateDistance;
    public bool flee;

    private void Start()
    {
        if(player == null) player = FindAnyObjectByType<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        SetDistance();
        SetSpeed();
        SetDir();
        LookDir();
        if (distance < activateDistance) {
            Move();
        }
    }

    private void SetDistance()
    {
        distance = (player.transform.position - transform.position).magnitude;
    }
    private void SetSpeed()
    {
        if (distance < activateDistance)
        {
            if (flee)
            {
                curSpeed = Mathf.Clamp(activateDistance * 3 / distance, 0f, maxSpeed);
            }
            else
            {
                curSpeed = Mathf.Clamp(activateDistance * 5 / distance, 0f, maxSpeed);
            }
        }
        else
        {
            curSpeed = 0;
        }
        if (flee)
        {
            curSpeed = -curSpeed;
        }
    }

    private void SetDir()
    {
        dir = player.transform.position - transform.position;
    }

    private void LookDir()
    {
        Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = rotation;
    }

    private void Move()
    {
        rb.velocity = transform.forward * curSpeed;
    }
}
