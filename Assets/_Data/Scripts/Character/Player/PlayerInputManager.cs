using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;
    protected PlayerControls playerControls;

    [Header("Player Movement Input")]
    [SerializeField] private Vector2 movementInput;

    public float horizontalInput;
    public float verticalInput;

    public float moveAmount;

    [Header("Camera Movement Input")]

    [SerializeField] private Vector2 cameraInput;
    public float cameraHorizontalInput;
    public float cameraVerticalInput;
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

        private void OnEnable()
    {
        if (this.playerControls == null)
        {
            this.playerControls = new PlayerControls();
            this.playerControls.PlayerMovement.Movement.performed += i => this.movementInput = i.ReadValue<Vector2>();
            this.playerControls.PlayerCamera.Movement.performed += i => this.cameraInput = i.ReadValue<Vector2>();
            //this.playerControls.PlayerMovement.Movement.canceled += i => this.movementInput = Vector2.zero;
        }
        this.playerControls.Enable();
    }

 

    private void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
        //disable player controls at start, we will enable them when we load into the world scene
        instance.enabled = false;
    }
    private void Update()
    {
        this.HandlePlayerMovementInput();
        this.HandleCameraMovementInput();
    }


    protected virtual void HandlePlayerMovementInput()
    {
        this.horizontalInput = this.movementInput.x;
        this.verticalInput = this.movementInput.y;
        this.moveAmount = Mathf.Clamp01(Mathf.Abs(this.horizontalInput) + Mathf.Abs(this.verticalInput));

        if (this.moveAmount > 0 && this.moveAmount <= 0.5f)
        {
            this.moveAmount = 0.5f;
        }
        else if (this.moveAmount > 0.5f && this.moveAmount <= 1f)
        {
            this.moveAmount = 1f;
        }
    }

    protected virtual void HandleCameraMovementInput()
    {
        this.cameraHorizontalInput = this.cameraInput.x;
        this.cameraVerticalInput = this.cameraInput.y;
    }


    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        //if we are load into the world scene, enable out player controls
        if (newScene.buildIndex == WorldSaveGameManager.instance.WorldSceneIndex)
        {
            instance.enabled = true;
        }
        //otherwise we must be at the main menu, disable out player controls
        else
        {
            instance.enabled = false;
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (enabled)
        {
            if (focus)
            {
                this.playerControls.Enable();

            }
            else
            {
                this.playerControls.Disable();
            }
        }
    }

   private void OnDestroy()
    {
        //if destroyed, remove the event subscription
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }
}
