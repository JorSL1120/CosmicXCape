using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotSkip : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Nivel_1");
    }
}
