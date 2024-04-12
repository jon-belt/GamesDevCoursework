using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerInput.OnFootActions OnFoot;

    private PlayerInput playerInput;
    private PlayerMotor motor;
    private PlayerLook look;
    private float savedSensitivity;

    //called once when script is first loaded
    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        //pointers to the performed events
        OnFoot.Jump.performed += ctx => motor.Jump();
        OnFoot.Crouch.performed += ctx => motor.Crouch();
        OnFoot.Sprint.performed += ctx => motor.Sprint();
    }

    void Start()
    {
        savedSensitivity = PlayerPrefs.GetFloat("mouseSensitivity", 0.5f);
    }

    // called once per 'fixed' frame
    void FixedUpdate()
    {
        //tell playermotor to move using value from our movement action
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * savedSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * savedSensitivity;
    }

    //called last 
    void LateUpdate()
    {
        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        OnFoot.Enable();
    }
    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
