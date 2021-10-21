using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy : MonoBehaviour
{

    public int health;
    public float shotCooldown = 2;
    public GameObject enemyShotPrefab;

    private Rigidbody2D rb;
    private float timeUntilNextShot;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(100, -600));
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ShotTimer();
    }


    void Movement()
    {
        if (rb.velocity.magnitude <= 0.1f)
        {
            float randomHorizontal = Random.Range(-500f, 500f);
            float randomVertical = Random.Range(-500f, 500f);

            rb.AddForce(new Vector2(randomHorizontal, randomVertical));

        }

    }

    void ShotTimer()
    {
        if (Time.time > timeUntilNextShot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject shot = Instantiate(enemyShotPrefab, transform.position, Quaternion.identity);
        shot.transform.localScale = new Vector3(2, -2, 1);
        timeUntilNextShot = Time.time + shotCooldown;
    }

    private void FixedUpdate()
    {
        rb.velocity *= 0.99f;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<scr_BounceshotRB>() != null)
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
