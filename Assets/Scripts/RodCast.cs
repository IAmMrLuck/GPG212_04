using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodCast : MonoBehaviour
{
    private Rigidbody castRB;
    private float directionY;
    private float castSpeed = 20f;

    private void Start()
    {
        castRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        directionY = Input.acceleration.y * castSpeed;
        transform.position = new Vector2 (Mathf.Clamp (transform.position.y, -7.5f, 7.5f), transform.position.x); 
    }

    private void FixedUpdate()
    {
        castRB.velocity = new Vector2 (directionY, castSpeed);
    }
}
