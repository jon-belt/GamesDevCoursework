using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMotor : MonoBehaviour, IDataPersistence
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector3 playerPosition;
    private PlayerStamina playerStamina;
    private bool isGrounded;

    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float RegenRate = 0.5f;
    public bool canMove = true;
    [SerializeField] public float stamina;
    [SerializeField] public float maxStamina;
    

    bool crouching = false;
    float crouchTimer = 1;
    bool lerpCrouch = false;
    private bool newGame = true;
    [SerializeField] bool sprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerStamina = FindObjectOfType<PlayerStamina>();
        //stamina = playerStamina.maxStamina;       //NEW GAME

        if (newGame == true)
        {
            stamina = 100f;
            RegenRate = 0.5f;
            newGame = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMoving = input.sqrMagnitude > 0.01f;

        //enables crouching
        if(lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if(crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);
        
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0;
            }
        }

        //The following if statements are to optimise movement and stamina, the aim of these are to ensure the movement system...
        //... is working as intended.

        //this ensures the user cannot start sprinting whilst crouched
        if (!sprinting && !crouching)
        {
            speed = 5;
        }

        //while sprinting, stamina decreases
        if (sprinting && stamina > 5 && isMoving)
        {
            stamina -= 2 * Time.deltaTime; // Decrease stamina over time, making it frame-rate independent
            speed = 10; // Assuming you have a higher speed value for sprinting
        }

        //checks if user is not performing a stamina action, then increases stamina at the base regen rate
        else if (!sprinting && stamina < maxStamina)
        {
            if (!sprinting && isGrounded)
            {
            //stamina regenerates at a lower rate than it decreases while sprinting, so the user cannot permanently sprint
            stamina += RegenRate * Time.deltaTime;   //regenerate stamina over time, making it frame-rate independent
            }
        }

        //if user is sprinting and stamina runs out, toggle off
        else if (sprinting && stamina < 5){
            sprinting = !sprinting;
        }
        
        //if user is not moving, toggle off
        else if (!isMoving){
            sprinting = !sprinting;
        }

        //limit stamina to 0-100 so that negative values are eliminated
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }

    //recieve inputs from input manager script and apply to controller
    public void ProcessMove(Vector2 input)
    {
        if (!canMove) return;   //skips all code if the player can't move

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    //methods for unique movements
    public void Jump()
    {   
        // player can only jump when on the ground WITH enough stamina
        if (isGrounded && stamina >= 10)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            stamina -= 10;
        }
    }
    
    public void Crouch()
    {
        crouching = !crouching;     //toggles crouching
        crouchTimer = 0;
        lerpCrouch = true;

        if(crouching){
            speed = 3.5f;
        }

        if(!crouching){
            speed = 5;
        }
    }

    public void Sprint()
    {
        // Toggle sprinting only if not crouching
        if (!crouching)
        {
            // If trying to start sprinting
            if (!sprinting && stamina >= 5)
            {
                sprinting = true;
                speed = 9;
            }
            // If already sprinting, toggle off without additional conditions
            else if (sprinting)
            {
                sprinting = false;
                speed = 5; // Reset to walk speed
            }
        }
    }
    public void IncreaseMaxStamina(float num)
    {
        maxStamina += num;
    }

    public void IncreaseRegenRate(float num)
    {
        RegenRate += num;
    }

    public void LoadData(GameData data)
    {
        this.RegenRate = data.staminaRegenRate;
        this.stamina = data.stamina;
        this.newGame = data.staminaNewGame;
    }

    public void SaveData(ref GameData data)
    {
        //get users position in vector 3
        //saves vector3 as array of 3 values (x,y,z)
        data.staminaRegenRate = this.RegenRate;
        data.stamina = this.stamina;
        data.staminaNewGame = this.newGame;

        //cant get the player position to save, will go back later if i have time

        //data.playerPosition = this.transform.position;

        // Vector3 currentPosition = transform.position;
        // data.playerPosition = new float[3] { currentPosition.x, currentPosition.y, currentPosition.z };

        // data.staminaRegenRate = this.RegenRate;
        // data.stamina = this.stamina;
        // data.staminaNewGame = this.newGame;
    }
}
