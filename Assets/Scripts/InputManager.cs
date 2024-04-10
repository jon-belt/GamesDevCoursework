using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions OnFoot;

    private PlayerMotor motor;
    private PlayerLook look;

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

    // called once per 'fixed' frame
    void FixedUpdate()
    {
        //tell playermotor to move using value from our movement action
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
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
