using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange_1 : MonoBehaviour
{
    public string SceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
