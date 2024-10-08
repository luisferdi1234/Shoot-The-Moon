using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Rocket : MonoBehaviour
{
    //Variables
    Rigidbody2D rb;
    private float minX, maxX, minY, maxY;
    private float fuelLossFromHit = .75f;
    private float shotCooldown = 0;
    private float maxShotCooldown = 1f;

    //Editable Variables
    [SerializeField]
    [Tooltip("How fast the ship moves")]
    float moveSpeed = 5f;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private AudioSource gameSoundEffects;
    [SerializeField]
    private AudioClip bulletSound;
    public AudioClip playerHealthUp;

    //Input System Variables
    private PlayerControls playerControls;
    private InputAction move;
    private InputAction fire;
    Vector2 moveDirection = Vector2.zero;

    //Accessors
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float MaxShotCooldown { get => maxShotCooldown; set => maxShotCooldown = value; }
    public float FuelLossFromHit { get => fuelLossFromHit; set => fuelLossFromHit = value; }

    private void Awake()
    {
        //Input System
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        //Input System
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.performed += Fire;
        fire.Enable();
    }

    private void OnDisable()
    {
        //Input System
        move.Disable();
        fire.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculate the screen boundaries based on the camera
        Camera camera = Camera.main;
        Vector3 screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));

        // Set the boundaries for clamping
        minX = -screenBounds.x;
        maxX = screenBounds.x;
        minY = -screenBounds.y;
        maxY = screenBounds.y;

        //When shop is fully implemented add code below this to set how much fuel the player loses from hits
        //fuelLossFromHit = PlayerPrefs.
    }

    private void Update()
    {
        //Reads input from the input system
        moveDirection = move.ReadValue<Vector2>();
        shotCooldown += Time.deltaTime;
    }

    void FixedUpdate()
    {
        //Updates player velocity based on read input
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime;

        // Clamp the player's position to the screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Apply the clamped position
        transform.position = newPosition;
    }

    /// <summary>
    /// Creates a bullet after the fire button is pressed
    /// </summary>
    /// <param name="context"></param>
    private void Fire(InputAction.CallbackContext context)
    {
        if (shotCooldown >= maxShotCooldown)
        {
            shotCooldown = 0;
            gameSoundEffects.PlayOneShot(bulletSound);
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks collision with enemies and lowers health
        if (collision.gameObject.tag == "Enemy")
        {
            float fuelLoss = DistanceCounter.Instance.MaxFuelAmount * fuelLossFromHit;
            DistanceCounter.Instance.DecreaseFuel(fuelLoss);
            Destroy(collision.gameObject);
            if (DistanceCounter.Instance.FuelAmount <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.name.Contains("FuelPickUp"))
        {
            float fuelGained = collision.gameObject.GetComponent<FuelPickUp>().fuelGained;
            DistanceCounter.Instance.IncreaseFuel(DistanceCounter.Instance.MaxFuelAmount * fuelGained);
            gameSoundEffects.PlayOneShot(playerHealthUp);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name.Contains("GoldPickUp"))
        {
            ScoreManager.Instance.AddGold(10);
            gameSoundEffects.PlayOneShot(playerHealthUp);
            Destroy(collision.gameObject);
        }
    }
}
