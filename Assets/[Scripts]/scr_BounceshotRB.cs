using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BounceshotRB : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private scr_Player playerScript;

    public float batteryPerBounce;

    //public float rightForce = 1;
    //public float upForce = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<scr_Player>();
        batteryPerBounce = playerScript.batteryPerBounce;
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //Launch(100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(float rightForce, float upForce)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(rightForce, upForce));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<scr_Enemy>() != null)
        {
            playerScript.shotBattery += batteryPerBounce;
        }
    }

    public void PrintHello()
    {
        Debug.Log("HELLO!!");
    }
}
