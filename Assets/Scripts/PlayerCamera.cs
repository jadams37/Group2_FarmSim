using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    // Controls speed at which player controls the camera
    public float speed = 10.0f;

    // 2D vector to store x and y input values
    private Vector2 movement;

    void Start()
    {
        
    }

    void LateUpdate()
    {

        // Instantiates movement Vector2 as input axes of horizontal and vertical through InputManager
        // Normalize the vector to prevent faster speed when moving diagonal
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        transform.Translate(movement * Time.deltaTime * speed);

    }
}
