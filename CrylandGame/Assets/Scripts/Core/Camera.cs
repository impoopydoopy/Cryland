using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float damping = 1.5f; 
    [SerializeField]
    private float offsetx;

    private Transform player;

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
            Vector3 target = new Vector3(player.position.x + offsetx, player.position.y, transform.position.z);
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
        else
        {
            Debug.Log("No player has been found.");
        }
    }
}
