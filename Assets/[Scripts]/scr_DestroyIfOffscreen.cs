using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DestroyIfOffscreen : MonoBehaviour
{
    private float screenHeight = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > screenHeight || gameObject.transform.position.y < -screenHeight)
        {
            Destroy(gameObject);
        }
    }
}
