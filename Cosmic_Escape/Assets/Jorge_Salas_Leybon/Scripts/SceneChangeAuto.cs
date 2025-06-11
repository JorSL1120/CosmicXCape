using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeAuto : MonoBehaviour
{
    private float tiempoAntesDeCambio = 27f;
    private float tiempoTranscurrido = 0f;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoAntesDeCambio)
        {
            SceneManager.LoadScene("Nivel_1");
        }
    }
}
