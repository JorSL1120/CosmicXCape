using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaMuestras : MonoBehaviour
{ 
    public int PiezasActivar;

    public GameObject InventoryGameObject;
    private Inventory inventoryScript;
    public GameObject FaltanMuestrasText;

    public string SceneName;

    private void Start()
    {
        inventoryScript = InventoryGameObject.GetComponent<Inventory>();
        FaltanMuestrasText.SetActive(false);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            if (inventoryScript.Agarrar >= PiezasActivar)
            {
                SceneManager.LoadScene(SceneName);
            }
            else
            {
                StartCoroutine(AppearAndDisappearFaltanMuestras());
            }
        }
    }

    IEnumerator AppearAndDisappearFaltanMuestras()
    {
        // Hacer que la imagen sea visible
        FaltanMuestrasText.SetActive(true);

        // Esperar 0.5 segundos
        yield return new WaitForSeconds(2f);

        // Hacer que la imagen sea invisible
        FaltanMuestrasText.SetActive(false);
    }
}
