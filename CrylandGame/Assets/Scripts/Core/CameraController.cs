using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Start ()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate () 
    {
        if(player)
        {
            Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);
            Vector3 currentPosition = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
            transform.position = currentPosition;
        }
        else
        {
            Debug.Log("No player has been found.");
        }
    }
}
