using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController_NOFADE : MonoBehaviour
{
    [SerializeField]
    public GameObject GameOverText;

    private void Update()
    {
        GameOverText.SetActive(!UFO.ufo.gameObject.activeSelf && SceneController.zanki < 0);
    }
}
