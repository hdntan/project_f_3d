using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public PlayerManager player;
    public static PlayerCamera instance;

    public Camera cameraObject;

    public Transform cameraPivot;

    [Header("Camera Settings")]


    public float cameraSmoothSpeed = 1f;
    [SerializeField] protected float leftAndRightRotationSpeed = 220f;
    [SerializeField] protected float upAndDownRotationSpeed = 220f;
    [SerializeField] protected float minPivot = -30f;
    [SerializeField] protected float maxPivot = 60f;
    [SerializeField] protected float cameraCollisionRadius = 0.2f;
    [SerializeField] protected LayerMask cameraCollisionLayer;



    [Header("Camera Values")]
    private Vector3 cameraVecocity;
    [SerializeField] protected Vector3 cameraObjectPosition; //used for camera collision
    [SerializeField] protected float leftAndRightLookAngle;
    [SerializeField] protected float upAndDownLookAngle;

    [SerializeField] protected float cameraZPosition; // values used for camera collision
    [SerializeField] protected float targetCameraZPosition; // values used for camera collision

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

    private void Start()
    {
        this.cameraZPosition = this.cameraObject.transform.localPosition.z;
    }

    public void HandleAllCameraAction()
    {
        if (this.player != null)
        {
            this.FollowTarger();
            this.HandleCameraRotation();
            this.HandleCollision();
        }
    }

    private void FollowTarger()
    {
        Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref this.cameraVecocity, this.cameraSmoothSpeed * Time.deltaTime);
        transform.position = targetCameraPosition;
    }

    private void HandleCameraRotation()
    {
        this.leftAndRightLookAngle += (PlayerInputManager.instance.cameraHorizontalInput * this.leftAndRightRotationSpeed) * Time.deltaTime;
        this.upAndDownLookAngle -= (PlayerInputManager.instance.cameraVerticalInput * this.upAndDownRotationSpeed) * Time.deltaTime;
        this.upAndDownLookAngle = Mathf.Clamp(this.upAndDownLookAngle, this.minPivot, this.maxPivot);

        Vector3 cameraRotation = Vector3.zero;
        Quaternion targetRotation;

        // rotate the player left and right
        cameraRotation.y = this.leftAndRightLookAngle;
        targetRotation = Quaternion.Euler(cameraRotation);
        transform.rotation = targetRotation;


        // rotate the camera up and down
        cameraRotation = Vector3.zero;
        cameraRotation.x = this.upAndDownLookAngle;
        targetRotation = Quaternion.Euler(cameraRotation);
        this.cameraPivot.localRotation = targetRotation;

    }

    protected virtual void HandleCollision()
    {
        this.targetCameraZPosition = this.cameraZPosition;
        RaycastHit hit;

        //direction for collision check
        Vector3 direction = this.cameraObject.transform.position - this.cameraPivot.position;
        direction.Normalize();
        //check if there is an obj in front of our desired direction
        if (Physics.SphereCast(this.cameraPivot.position, this.cameraCollisionRadius, direction, out hit, Mathf.Abs(this.targetCameraZPosition), this.cameraCollisionLayer))
        {
            //if there is, we get our distance from it
            float distanceFromHitObject = Vector3.Distance(this.cameraPivot.position, hit.point);
            //when equate our target z position to the following
            this.targetCameraZPosition = -(distanceFromHitObject - this.cameraCollisionRadius);
        }
        //if our target position is less than our collision radius, we subtract our collision radius 
        if (Mathf.Abs(this.targetCameraZPosition) < this.cameraCollisionRadius)
        {
            this.targetCameraZPosition = -this.cameraCollisionRadius;
        }
        //apply our new camera position
         this.cameraObjectPosition.z = Mathf.Lerp(this.cameraObject.transform.localPosition.z, this.targetCameraZPosition, 0.2f);
        this.cameraObject.transform.localPosition = this.cameraObjectPosition;
    }
}
