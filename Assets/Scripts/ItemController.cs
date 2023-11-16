using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -0.03f;
   
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(0.0f, this.dropSpeed, 0.0f);

        if (transform.position.y <= -1.0f)
        {
            Destroy(gameObject);
        }
    }
}
