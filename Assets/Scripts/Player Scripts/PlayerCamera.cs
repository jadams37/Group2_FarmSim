using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCamera : MonoBehaviour
{

    // Camera class for controlling player movement and thus camera movement
    // Manages any input from the player besides movement such as pausing/unpausing
    // the game or closing any menus

    public GameObject gameCamera;
    private Camera camera;

    // GUI container with all menus & buttons
    public PlayerUI playerUI;

    private PlayerData playerData;

    // EventSystem for button events
    public EventSystem eventSystem;

    public GameObject map;

    private GameManager gameManager;

    private Map gameMap;

    private DayNightCycle dayNightCycle;

    // Controls speed at which player controls the camera
    private float minSpeed = 10.0f;
    private float speed;
    private float maxSpeed = 20.0f;

    private Vector3 offset = new Vector3(0, 0, -10);

    // 2D vector to store x and y input values
    private Vector3 movement;

    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 5f;
    private float maxZoom = 10f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    // Class containing Player input information and camera movement

    void Start()
    {

        gameMap = map.GetComponent<Map>();

        transform.position = gameMap.GetCenter();

        camera = gameCamera.GetComponent<Camera>();

        zoom = camera.orthographicSize;

        speed = minSpeed;

        playerData = transform.GetComponent<PlayerData>();

        dayNightCycle = GameObject.Find("Main Camera").GetComponent<DayNightCycle>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {

        DetermineInput();

    }

    private void SetCameraSpeed()
    {

        if(Input.GetKeyDown(KeyCode.LeftShift))
            speed = maxSpeed;

        if(Input.GetKeyUp(KeyCode.LeftShift))
            speed = minSpeed;

    }

    private void MoveCamera()
    {

        // Instantiates movement Vector2 as input axes of horizontal and vertical through InputManager
        // Normalize the vector to prevent faster speed when moving diagonally

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        ConstrainCamera();

        transform.Translate(movement.normalized * Time.unscaledDeltaTime * speed);
        gameCamera.transform.position = transform.position + offset;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);

        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, zoom, ref velocity, smoothTime);

        SetCameraSpeed();

    }

    private void ConstrainCamera()
    {

        if(movement.x < 0 && transform.position.x <= gameMap.xBounds[0])
            movement.x = 0;

        if(movement.x > 0 && transform.position.x >= gameMap.xBounds[1])
            movement.x = 0;

        if(movement.y < 0 && transform.position.y <= gameMap.yBounds[0])
            movement.y = 0;

        if(movement.y > 0 && transform.position.y >= gameMap.yBounds[1])
            movement.y = 0;

    }

    // Helper method containing all various input methods
    private void DetermineInput()
    {

        if(gameManager.isGameOver)
            return;
        
        MenuInput();

        if(!(gameManager.isPaused || playerUI.isInPauseMenu() || playerUI.IsInMenu()))
        {

            MoveCamera();
            EquipTool();
            SetTimeSpeed();
            GodMode();

        }

    }

    private void GodMode()
    {

        if(Input.GetKeyDown(KeyCode.G) && !gameManager.isInGodMode)
        {

            gameManager.isInGodMode = true;

        }

        else if(Input.GetKeyDown(KeyCode.G) && gameManager.isInGodMode)
        {

            gameManager.isInGodMode = false;

        }

    }

    private void EquipTool()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1) && !playerData.GetHasToolEquipped() && !playerUI.seedsMenu.activeInHierarchy)
        {

            playerData.SetToolEquipped(playerData.tools[0]);
            playerData.SetHasToolEquipped(true);
            playerUI.ToolIcon.GetComponent<UnityEngine.UI.Image>().sprite = playerUI.toolIcons[0];

        }

        else if(Input.GetKeyDown(KeyCode.Alpha1) && playerData.GetHasToolEquipped())
        {

            playerData.SetHasToolEquipped(false);
            playerData.SetToolEquipped(null);

        }

        else if(Input.GetKeyDown(KeyCode.Alpha2) && !playerData.GetHasToolEquipped() && !playerUI.seedsMenu.activeInHierarchy)
        {

            playerData.SetToolEquipped(playerData.tools[1]);
            playerData.SetHasToolEquipped(true);
            playerUI.ToolIcon.GetComponent<UnityEngine.UI.Image>().sprite = playerUI.toolIcons[1];

        }

        else if(Input.GetKeyDown(KeyCode.Alpha2) && playerData.GetHasToolEquipped())
        {

            playerData.SetToolEquipped(null);
            playerData.SetHasToolEquipped(false);

        }

        else if(Input.GetKeyDown(KeyCode.Alpha3) && !playerData.GetHasToolEquipped() && !playerUI.seedsMenu.activeInHierarchy)
        {

            playerData.SetToolEquipped(playerData.tools[2]);
            playerData.SetHasToolEquipped(true);
            playerUI.ToolIcon.GetComponent<UnityEngine.UI.Image>().sprite = playerUI.toolIcons[2];

        }

        else if(Input.GetKeyDown(KeyCode.Alpha3) && playerData.GetHasToolEquipped())
        {

            playerData.SetToolEquipped(null);
            playerData.SetHasToolEquipped(false);

        }

        else if(Input.GetKeyDown(KeyCode.Alpha4) && !playerData.GetHasToolEquipped() && !playerUI.seedsMenu.activeInHierarchy)
        {

            playerUI.seedsMenu.SetActive(true);

        }

        else if(Input.GetKeyDown(KeyCode.Alpha4) && playerUI.seedsMenu.activeInHierarchy)
        {

            playerUI.seedsMenu.SetActive(false);

        }

    }

    private void SetTimeSpeed()
    {

        if(Input.GetKeyDown(KeyCode.F) && !gameManager.fastForward)
        {

            gameManager.FastForward();

        }

        else if(Input.GetKeyDown(KeyCode.F) && gameManager.fastForward)
        {

            gameManager.FastForward();

        }

    }

    private void Pause()
    {

        // Helper method for pausing game

        gameManager.PauseGame();

        if(playerUI.GetShowUI())
            playerUI.ToggleUI();

        playerUI.pauseMenu.SetActive(true);

    }

    private void Unpause()
    {

        // Helper method for unpausing game
        gameManager.PauseGame();

        playerUI.ToggleUI();
        playerUI.pauseMenu.SetActive(false);

    }

    private void MenuInput()
    {

        // Pauses game if player presses 'Escape' with no menus open
        if(Input.GetKeyDown(KeyCode.Escape) && !gameManager.isPaused && !playerUI.IsInMenu())
        {

            Pause();

        }

        // Unpauses game if player presses 'Escape' and the game is currently paused
        else if(Input.GetKeyDown(KeyCode.Escape) && gameManager.isPaused && !playerUI.IsInMenu())
        {

            Unpause();

        }

        // Closes any menu that is open if the player presses 'Escape'
        else if(Input.GetKeyDown(KeyCode.Escape) && !gameManager.isPaused && playerUI.IsInMenu())
        {

            CloseMenu();

        }

        // Hides or shows GUI with 'H' if the game is not paused and no menu is open
        else if(Input.GetKeyDown(KeyCode.H) && !gameManager.isPaused && !playerUI.IsInMenu())
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
