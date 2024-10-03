using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float speed = 10.0f;
    private float xInput;
    private float yInput;

    void Start()
    {
        
    }

    void LateUpdate()
    {

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector2.right * xInput * Time.deltaTime * speed);
        transform.Translate(Vector2.up * yInput * Time.deltaTime * speed);

    }
}
