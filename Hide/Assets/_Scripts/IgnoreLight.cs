using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLight : MonoBehaviour
{
    public new GameObject light;
    public bool cullLights = true;

    private void Start()
    {
        light = GameObject.Find("Directional Light");
    }

    void OnPreCull()
    {
        if (cullLights == true)
        {
            light.SetActive(false);
        }
    }

    void OnPostRender()
    {
        if (cullLights == true)
        {
            light.SetActive(true);
        }
    }
}