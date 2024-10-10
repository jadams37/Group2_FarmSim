using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCamera : MonoBehaviour
{

    private bool isPaused;

    public PlayerUI playerUI;
    public EventSystem eventSystem;

    // Controls speed at which player controls the camera
    public float speed = 10.0f;

    // 2D vector to store x and y input values
    private Vector2 movement;

    void Start()
    {
        
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused && !playerUI.isInMenu())
        {

            Debug.Log("Pause");
            isPaused = true;

        }

        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused && !playerUI.isInMenu())
        {

            Debug.Log("Unpause");
            isPaused = false;

        }

        else if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && playerUI.isInMenu())
        {

            Debug.Log("Close Menu");
            playerUI.inventoryButton.interactable = true;
            playerUI.marketButton.interactable = true;
            playerUI.GetActiveMenu().SetActive(false);

        }

    }

    void LateUpdate()
    {

        // Instantiates movement Vector2 as input axes of horizontal and vertical through InputManager
        // Normalize the vector to prevent faster speed when moving diagonally
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        transform.Translate(movement * Time.deltaTime * speed);

    }
}
