using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EnemyShot : MonoBehaviour
{

    public float fallSpeed; 
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
        transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed, transform.position.z);
    }
}
