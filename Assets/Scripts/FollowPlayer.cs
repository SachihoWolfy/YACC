using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameHasEnded == false)
        {
            transform.position = player.position + offset;
        } else
        {
            transform.LookAt(new Vector3(player.position.x, offset.y + 1, player.position.z));
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - Time.deltaTime * Camera.main.fieldOfView/40 * 20f, 30f, 70f);
        }
    }
}
