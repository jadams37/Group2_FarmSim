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

        DetermineInput();

    }

    void LateUpdate()
    {

        MoveCamera();

    }

    private void MoveCamera()
    {

        // Instantiates movement Vector2 as input axes of horizontal and vertical through InputManager
        // Normalize the vector to prevent faster speed when moving diagonally
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        transform.Translate(movement.normalized * Time.deltaTime * speed);

    }

    private void DetermineInput()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && !playerUI.IsInMenu())
        {

            Debug.Log("Pause");
            isPaused = true;

        }

        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && !playerUI.IsInMenu())
        {

            Debug.Log("Unpause");
            isPaused = false;

        }

        else if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && playerUI.IsInMenu())
        {

            Debug.Log("Close Menu");
            playerUI.inventoryButton.interactable = true;
            playerUI.marketButton.interactable = true;
            playerUI.GetActiveMenu().SetActive(false);

        }

    }

    public bool GetIsPaused()
    {
        return isPaused;
    }

    public PlayerUI GetPlayerUI()
    {
        return playerUI;
    }

    public EventSystem GetEventSystem()
    {
        return eventSystem;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public Vector2 GetMovement()
    {
        return movement;
    }

    public void SetIsPaused(bool isPaused)
    {
        this.isPaused = isPaused;
    }

    public void SetPlayerUI(PlayerUI playerUI)
    {
        this.playerUI = playerUI;
    }

    public void SetEventSystem(EventSystem eventSystem)
    {
        this.eventSystem = eventSystem;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetMovement(Vector2 movement)
    {
        this.movement = movement;
    }

}
