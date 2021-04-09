using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
     CameraCon cameraCon;

    //カメラシェイク
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(DoShake(duration, magnitude));
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        if(cameraCon == null)
        {
            cameraCon = gameObject.GetComponent<CameraCon>();
            
        }
        cameraCon.enabled = false;

        Vector3 pos = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {

            float x = pos.x + Random.Range(-1f, 1f) * magnitude;
            float y = pos.y + Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;

            if(Time.timeScale == 0)//タイムスケールが止まった場合は処理を中止
            {
                yield break;
            }

            yield return null;
        }
        transform.localPosition = pos;
        cameraCon.enabled = true;

    }

    
}
