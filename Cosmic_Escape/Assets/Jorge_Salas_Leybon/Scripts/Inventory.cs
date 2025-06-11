using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int Agarrar;
    public TextMeshProUGUI textoInventario; // Variable para asignar el TextMeshPro en el Inspector
    public int nMuestras;

    public void AddPiezas(int amount)
    {
        Agarrar += amount;
        ActualizarTextoInventario();
    }

    void ActualizarTextoInventario()
    {
        if (textoInventario != null)
        {
            textoInventario.text = "Muestras " + Agarrar.ToString() + "/" + nMuestras.ToString(); // Actualizar el texto del TextMeshPro con el valor de Agarrar
        }
        else
        {
            Debug.LogWarning("No se asignó el componente TextMeshPro en el Inspector.");
        }
    }
}
