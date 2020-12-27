using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public CameraCon CameraCon;

    //カメラシェイク
    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(DoShake(duration, magnitude));
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        CameraCon.enabled = false;

        Vector3 pos = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = pos.x + Random.Range(-1f, 1f) * magnitude;
            float y = pos.y + Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = pos;
        CameraCon.enabled = true;

    }
}
