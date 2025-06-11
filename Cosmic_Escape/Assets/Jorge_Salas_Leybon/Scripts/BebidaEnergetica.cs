using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BebidaEnergetica : MonoBehaviour
{
    public float EnergeticaOn = 5;

    public void Show()
    {

    }

    public void Hide()
    {
        transform.gameObject.SetActive(false);
    }
}
