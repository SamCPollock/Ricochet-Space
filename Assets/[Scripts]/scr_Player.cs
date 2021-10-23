using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour
{

    [Header("Movement")]
    public float movementSpeed;
    public float chargingMovementSpeed;
    public float normalMovementSpeed;
    public float shotAngle = 30.0f;

    [Header("Powershots")]
    public float powerShotChargeTime;

    [Header("BatteryShots")]
    public float shotBattery;
    public float shotBatteryMax;
    public float shotCost;
    public float batteryRechargeRate;
    public float batteryPerBounce;

    [Header("Prefabs")]
    public GameObject bounceShotRBPrefab;
    public GameObject bounceShotPrefab;
    public GameObject powerShotPrefab;


    private float horBounds = 2f;
    private float verBounds = 4.6f;
    private int lives = 3;
    private Vector3 shotOffsetLeft = new Vector3(-0.3f, 0f, 0f);
    private Vector3 shotOffsetRight = new Vector3(0.3f, 0f, 0f);

    //private Vector2 touchStartPos = new Vector2(0, 0);
    //private Vector2 touchMovePos = new Vector2(0, 0);
    private Vector3 moveTarget;


    void Start()
    {
        moveTarget = gameObject.transform.position;
    }

    void Update()
    {
        TouchMovement();
        KeyboardMovement();
        CheckBounds();
        GenerateBattery();

    }


    void KeyboardMovement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        transform.position += new Vector3(hInput * movementSpeed * Time.deltaTime, vInput * movementSpeed * Time.deltaTime, 0f);


        if (Input.GetKeyDown("space"))
        {
            StartCharging();
        }

        if (Input.GetKeyUp("space"))
        {
            ReleaseCharging();
        }

    }

    //void TouchMovement()
    //{
    //    foreach (var touch in Input.touches)
    //    {
    //        var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

    //        if (worldTouch.y > transform.position.y)
    //        {
    //            // direction is positive
    //            direction = 1.0f;
    //        }

    //        if (worldTouch.y < transform.position.y)
    //        {
    //            // direction is negative
    //            direction = -1.0f;
    //        }

    //        m_touchesEnded = worldTouch;

    //    }
    //}

    void TouchMovement()
    {
        if (Input.touchCount > 0)
        {
            moveTarget = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            Debug.Log(moveTarget);

            float xDistance = gameObject.transform.position.x - moveTarget.x;
            float yDistance = gameObject.transform.position.y - moveTarget.y;


            float step = movementSpeed * Time.deltaTime;

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, moveTarget, step);
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            //if (xDistance > 0)
            //{
            //    {
            //        gameObject.transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0f, 0f));
            //    }
            //    gameObject.transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0f, 0f));
            //}
            //else if (xDistance < 0)
            //{
            //    gameObject.transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0f, 0f));

            //    gameObject.transform.
            //}


            //if (yDistance > 0)
            //{
            //    gameObject.transform.Translate(new Vector3(0f, -movementSpeed* Time.deltaTime, 0f));
            //}
            //else if (yDistance < 0)
            //{
            //    gameObject.transform.Translate(new Vector3(0.0f, movementSpeed * Time.deltaTime, 0f));
            //}
        }

  



        #region Virtual Joystick
        ////Virtual Joystick -- RETIRED DUE TO JANKINESS, preserved for reference.
        //float horizontalInput = 0;
        //float verticalInput = 0;

        //if (Input.touchCount > 0)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        touchStartPos = Input.touches[0].position;
        //        Debug.Log("TouchSTARTPOS: " + touchStartPos);
        //    }

        //    if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //    {
        //        touchMovePos = Input.touches[0].position;
        //        Debug.Log("TouchMOVEPOS: " + touchMovePos);

        //            horizontalInput = (touchMovePos.x - touchStartPos.x ) * 0.01f;
        //            Debug.Log(touchMovePos.x + " - " + touchStartPos.x + " = " + (touchMovePos.x - touchStartPos.x));
        //        if (horizontalInput > 10)
        //            horizontalInput = 10;
        //        else if (horizontalInput < -10)
        //            horizontalInput = -10;
        //        transform.position += new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0f);

        //    }

        //}
        #endregion




    }


    void CheckBounds()
    {
        // Check horizontal bounds
        if (transform.position.x > horBounds)
        {
            transform.position = new Vector3(horBounds, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -horBounds)
        {
            transform.position = new Vector3(-horBounds, transform.position.y, transform.position.z);
        }

        // Check vertical bounds
        if (transform.position.y > verBounds)
        {
            transform.position = new Vector3(transform.position.x, verBounds, transform.position.z);
        }
        else if (transform.position.y < -verBounds)
        {
            transform.position = new Vector3(transform.position.x, -verBounds, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bounce shot caught
        if (collision.gameObject.GetComponent<scr_BounceshotRB>() != null)
        {
            Destroy(collision.gameObject);
            PowerShot();
        }
        // Hit by enemy projectile 
        if (collision.gameObject.GetComponent<scr_EnemyShot>() != null)
        {
            Destroy(collision.gameObject);
            lives--;
            Debug.Log("LIVES REMAINING: " + lives);
        }
    }

    void StartCharging()
    {
        movementSpeed = chargingMovementSpeed;
    }

    void ReleaseCharging()
    {
        movementSpeed = normalMovementSpeed;

        if (shotBattery >= shotCost)
        {
            //Instantiate(bounceShotPrefab, gameObject.transform.position + shotOffsetLeft, Quaternion.Euler(0f, 0f, shotAngle));
            //Instantiate(bounceShotPrefab, gameObject.transform.position + shotOffsetRight, Quaternion.Euler(0f, 0f, -shotAngle));
            GameObject rightShot = Instantiate(bounceShotRBPrefab, gameObject.transform.position + shotOffsetLeft, Quaternion.identity) as GameObject;
            GameObject leftShot = Instantiate(bounceShotRBPrefab, gameObject.transform.position + shotOffsetRight, Quaternion.identity) as GameObject;

            leftShot.GetComponent<scr_BounceshotRB>().Launch(200, 200);
            rightShot.GetComponent<scr_BounceshotRB>().Launch(-200, 200);
            shotBattery -= shotCost;
        }
    }

    void PowerShot()
    {
        Invoke("LaunchPowerShot", powerShotChargeTime);
    }

    void LaunchPowerShot()
    {
        GameObject powerShot = Instantiate(powerShotPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
    }

    void GenerateBattery()
    {
        if (shotBattery < shotBatteryMax)
        {
            shotBattery += batteryRechargeRate * Time.deltaTime;
        }

        if (shotBattery > shotBatteryMax)
        {
            shotBattery = shotBatteryMax;
        }
    }


}
