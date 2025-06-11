using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotInicio : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TextoInicio");
    }
}
