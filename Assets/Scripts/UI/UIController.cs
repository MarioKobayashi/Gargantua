using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject GameOverText;

    public Text zankiText;

    string zanki;

    private void Awake()
    {
        this.zanki = SceneController.zanki.ToString();
    }

    void Start()
    {
        zankiText.text = "× " + zanki;
    }
}
