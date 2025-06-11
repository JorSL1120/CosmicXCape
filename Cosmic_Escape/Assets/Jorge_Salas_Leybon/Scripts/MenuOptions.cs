using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private GameObject botonOptions;
    [SerializeField] private GameObject menuOptions;
    public void Options()
    {
        botonOptions.SetActive(false);
        menuOptions.SetActive(true);
    }
    public void Return()
    {
        botonOptions.SetActive(true);
        menuOptions.SetActive(false);
    }
}
