using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjects : MonoBehaviour
{
    [SerializeField] GameObject original;
    public void RemoveCopy()
    {
        gameObject.SetActive(false);
        Scenary.instrumentCount++;
        Debug.Log(Scenary.instrumentCount);
    }
    public void SpawnOriginal()
    {
        original.SetActive(true);
    }
}
