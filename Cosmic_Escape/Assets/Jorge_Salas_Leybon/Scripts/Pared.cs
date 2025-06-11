using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    public int PiezasDesactivar;

    public GameObject InventoryGameObject;
    private Inventory inventoryScript;

    private void Start()
    {
        inventoryScript = InventoryGameObject.GetComponent<Inventory>();
    }

    private void Update()
    {
        if (inventoryScript.Agarrar >= PiezasDesactivar)
        {
            Hide();
        }
    }

    public void Show()
    {

    }

    public void Hide()
    {
        transform.gameObject.SetActive(false);
    }
}
