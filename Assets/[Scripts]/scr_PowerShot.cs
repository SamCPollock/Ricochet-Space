using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PowerShot : MonoBehaviour
{
    public float speed;
    public int damage; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<scr_Enemy>() != null)
        {
            collision.gameObject.GetComponent<scr_Enemy>().health -= damage;
            Explode();
        }
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}

