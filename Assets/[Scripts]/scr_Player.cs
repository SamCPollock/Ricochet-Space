using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour
{
    public float movementSpeed;
    public GameObject bounceShotPrefab;

    public float chargingMovementSpeed;
    public float normalMovementSpeed;
    public float shotAngle = 30.0f;

    public GameObject bounceShotRBPrefab;


    private float horBounds = 2f;
    private float verBounds = 4.6f;
    private int lives = 3;
    private Vector3 shotOffsetLeft = new Vector3(-0.3f, 0f, 0f);
    private Vector3 shotOffsetRight = new Vector3(0.3f, 0f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardMovement();
        CheckBounds();
        //TouchMovement();
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
            ChargeShot();
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
        //Instantiate(bounceShotPrefab, gameObject.transform.position + shotOffsetLeft, Quaternion.Euler(0f, 0f, shotAngle));
        //Instantiate(bounceShotPrefab, gameObject.transform.position + shotOffsetRight, Quaternion.Euler(0f, 0f, -shotAngle));
        GameObject rightShot = Instantiate(bounceShotRBPrefab, gameObject.transform.position + shotOffsetLeft, Quaternion.identity) as GameObject;
        GameObject leftShot = Instantiate(bounceShotRBPrefab, gameObject.transform.position + shotOffsetRight, Quaternion.identity) as GameObject;

        leftShot.GetComponent<scr_BounceshotRB>().Launch(200, 200);
        rightShot.GetComponent<scr_BounceshotRB>().Launch(-200, 200);

    }

    void ChargeShot()
    {

    }
}
