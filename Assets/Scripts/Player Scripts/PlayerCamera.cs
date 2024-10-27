using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCamera : MonoBehaviour
{

    // Camera class for controlling player movement and thus camera movement
    // Manages any input from the player besides movement such as pausing/unpausing
    // the game or closing any menus

    // Pause status of game
    private bool isPaused;

    public GameObject gameCamera;

    // GUI container with all menus & buttons
    public PlayerUI playerUI;

    // EventSystem for button events
    public EventSystem eventSystem;

    public GameObject map;

    // Controls speed at which player controls the camera
    public float speed = 10.0f;

    private Vector3 offset = new Vector3(0, 0, -10);

    // 2D vector to store x and y input values
    private Vector3 movement;

    // Class containing Player input information and camera movement

    void Start()
    {

        Map gameMap = map.GetComponent<Map>();

        transform.position = gameMap.GetCenter();

    }

    void Update()
    {

        DetermineInput();

    }

    private void MoveCamera()
    {

        // Instantiates movement Vector2 as input axes of horizontal and vertical through InputManager
        // Normalize the vector to prevent faster speed when moving diagonally
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        transform.Translate(movement.normalized * Time.deltaTime * speed);

        gameCamera.transform.position = transform.position + offset;

    }

    // Helper method containing all various input methods
    private void DetermineInput()
    {

        MenuInput();
        MoveCamera();

    }

    private void Pause()
    {

        // Helper method for pausing game
        Debug.Log("Pause");
        isPaused = true;
        Time.timeScale = 0;
        playerUI.pauseMenu.SetActive(true);

    }

    private void Unpause()
    {

        // Helper method for unpausing game
        Debug.Log("Unpause");
        isPaused = false;
        Time.timeScale = 1.0f;
        playerUI.pauseMenu.SetActive(false);

    }

    private void MenuInput()
    {

        // Pauses game if player presses 'Escape' with no menus open
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused && !playerUI.IsInMenu())
        {

            Pause();

        }

        // Unpauses game if player presses 'Escape' and the game is currently paused
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused && !playerUI.IsInMenu())
        {

            Unpause();

        }

        // Closes any menu that is open if the player presses 'Escape'
        else if(Input.GetKeyDown(KeyCode.Escape) && !isPaused && playerUI.IsInMenu())
        {

            CloseMenu();

        }

        // Hides or shows GUI with 'H' if the game is not paused and no menu is open
        else if(Input.GetKeyDown(KeyCode.H) && !isPaused && !playerUI.IsInMenu())
            playerUI.ToggleUI();

    }

    // Helper method to close currently opened menu
    private void CloseMenu()
    {

        Debug.Log("Close Menu");
        playerUI.inventoryButton.interactable = true;
        playerUI.marketButton.interactable = true;
        playerUI.GetActiveMenu().SetActive(false);

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
