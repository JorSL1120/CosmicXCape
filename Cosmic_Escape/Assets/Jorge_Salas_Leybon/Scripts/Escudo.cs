using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public float ShieldTime = 5;
    public void Show()
    {

    }

    public void Hide()
    {
        transform.gameObject.SetActive(false);
    }
}
