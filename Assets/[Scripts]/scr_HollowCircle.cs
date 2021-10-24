using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_HollowCircle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.zero, 200 * Time.deltaTime);
        Invoke("DestroySelf", 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 0.978f, gameObject.transform.localScale.y * 0.97f, 0);

    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
