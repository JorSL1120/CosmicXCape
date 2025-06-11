using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public Slider Slider;
    public GameObject Oxigeno;
    public GameObject ParticlesO2;
    public GameObject BebidaEnergetica;
    public float maxVida = 100f;
    public float decremento = 1f;
    public float incremento = 20f;

    public string SceneName;

    public GameObject TextO2;

    [HideInInspector] public float ShieldTime; //Tiempo de invulnerabilidad

    void Start()
    {
        Slider.maxValue = maxVida;
        Slider.value = maxVida;
        TextO2.SetActive(false);
        ParticlesO2.SetActive(false);
    }
    void Update()
    {
        decrementoVida();
        if (Slider.value <= 0)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Oxigeno oxigeno = other.GetComponent<Oxigeno>();
        if (oxigeno != null)
        {
            StartCoroutine(AppearAndDisappear());
            incrementoVida();
            oxigeno.Hide();
        }
    }

    void decrementoVida()
    {
        if (ShieldTime <= 0)
        {
            Slider.value -= decremento * Time.deltaTime;
        }
        ShieldTime -= Time.deltaTime;
    }

    public void incrementoVida()
    {
        Slider.value += incremento;
    }

    IEnumerator AppearAndDisappear()
    {
        // Hacer que la imagen sea visible
        TextO2.SetActive(true);
        ParticlesO2.SetActive(true);

        // Esperar 2 segundos
        yield return new WaitForSeconds(2f);

        // Hacer que la imagen sea invisible
        TextO2.SetActive(false);
        ParticlesO2.SetActive(false);
    }
}
