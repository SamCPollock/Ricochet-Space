using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Rocket : MonoBehaviour
{

    public float movementSpeed;
    public int remainingLaps;
    public int scoreValue;

    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(currentSpeed * Time.deltaTime, 0f, 0f);

        if (transform.position.x > 4)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(4, transform.position.y, transform.position.z);
            currentSpeed = -movementSpeed;
            remainingLaps--;
        }

        if (transform.position.x < -4)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(-4, transform.position.y, transform.position.z);
            currentSpeed = movementSpeed;
            remainingLaps--;
        }

        if (remainingLaps <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<scr_PowerShot>() != null)
        {
            GameObject.Find("Player").GetComponent<scr_Player>().AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
