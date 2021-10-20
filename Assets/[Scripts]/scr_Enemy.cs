using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy : MonoBehaviour
{

    public int health;
    private Rigidbody2D rb;

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
