using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodCast : MonoBehaviour
{
    private Rigidbody2D castRB;
    private float directionY;
    private float castSpeed = 20f;
    
    private void Start()
    {
        castRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        directionY = Input.acceleration.y * castSpeed;
        transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -7.5f, 7.5f), transform.position.y); 
    }

    private void FixedUpdate()
    {
        castRB.velocity = new Vector2 (directionY, 0f);
    }
}
