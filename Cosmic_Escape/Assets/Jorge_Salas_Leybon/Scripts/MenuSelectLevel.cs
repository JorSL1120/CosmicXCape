using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectLevel : MonoBehaviour
{
    [SerializeField] private GameObject botonLevels;
    [SerializeField] private GameObject panelLevels;

    public void LevelMenu()
    {
        botonLevels.SetActive(false);
        panelLevels.SetActive(true);
    }

    public void Return()
    {
        botonLevels.SetActive(true);
        panelLevels.SetActive(false);
    }
}
