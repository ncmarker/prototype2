using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    private BulletPower bulletPower;
    private RadiusPower radiusPower;

    public bool isPlayer2 = false;
    private float screenWidth;
    private float screenHeight;
    public AudioSource backgroundMusicSource;

    private void Awake()
    {
        bulletPower = GetComponent<BulletPower>();
        radiusPower = GetComponent<RadiusPower>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Getting the screen bounds
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        screenHeight = Camera.main.orthographicSize;

        // play background music 
        if (backgroundMusicSource != null) {
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement() 
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        if (isPlayer2) 
        {
            // Player 2 WASD
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                moveInput.x = -1;
            }
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                moveInput.x = 1;
            }
            else moveInput.x = 0;

            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                moveInput.y = 1;
            }
            else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                moveInput.y = -1;
            }
            else moveInput.y = 0;
        }
        else 
        {
            // Player 1 Arrow Keys
            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                moveInput.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                moveInput.x = 1;
            }
            else moveInput.x = 0;

            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                moveInput.y = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
            {
                moveInput.y = -1;
            }
            else moveInput.y = 0;
        }

        // bound in screen
        Vector3 pos = transform.position + (moveInput.normalized * moveSpeed * Time.deltaTime);
        pos.x = Mathf.Clamp(pos.x, -screenWidth, screenWidth);
        pos.y = Mathf.Clamp(pos.y, -screenHeight, screenHeight);
        transform.position = pos;
    }

    // Methods to activate powers
    public void ActivateBulletPower()
    {
        if (radiusPower != null) radiusPower.DeactivatePower(); 
        if (bulletPower != null) bulletPower.ActivatePower();
    }

    public void ActivateRadiusPower()
    {
        if (bulletPower != null) bulletPower.DeactivatePower(); 
        if (radiusPower != null) radiusPower.ActivatePower();
    }
}
