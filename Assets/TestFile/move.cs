using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float moveSpeed = 5;
   
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;

        if(transform.position.x > 5)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
