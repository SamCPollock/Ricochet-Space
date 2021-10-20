using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BounceshotRB : MonoBehaviour
{
    private Rigidbody2D rb;

    //public float rightForce = 1;
    //public float upForce = 1;
    // Start is called before the first frame update
    void Start()
    {
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

    public void PrintHello()
    {
        Debug.Log("HELLO!!");
    }
}
