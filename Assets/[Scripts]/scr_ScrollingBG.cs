using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ScrollingBG : MonoBehaviour
{

    public float scrollSpeed; 


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector3(0, -scrollSpeed, 0f));

        if (transform.position.y <= -7.6f)
        {
            transform.position = new Vector3(transform.position.x, 7.6f, 1f);
        }
    }
}
