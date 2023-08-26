using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveX, moveY, 0).normalized;
        transform.position += movement * (moveSpeed * Time.deltaTime);
    }
}
