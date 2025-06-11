using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelCreditos : MonoBehaviour
{
    private float tiempoAntesDeCambio = 20f;
    private float tiempoTranscurrido = 0f;
    public GameObject Panel;

    void Start()
    {
        Panel.SetActive(true);
    }
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoAntesDeCambio)
        {
            Panel.SetActive(false);
        }
    }
}
