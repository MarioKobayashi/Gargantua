using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float duration = 0;

    void Update()
    {
        transform.position += transform.right * 1 * Time.deltaTime;

        
        duration += Time.deltaTime;

        if(duration > 2)
        {
            gameObject.SetActive(false);
            duration = 0;
        }
    }

    
}
