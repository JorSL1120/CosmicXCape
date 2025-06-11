using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonNivel1 : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene("Nivel_1");
    }
}
