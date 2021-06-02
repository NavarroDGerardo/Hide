using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLPosition : MonoBehaviour
{
    // Use this for initialization

    private Vector3 mousePosition = new Vector3(0, 0, 0); 
    public GameObject Flashlight;

    void Start()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Update is called once per frame
    void Update()
    {
        moveFlashlight();
    }
    void moveFlashlight()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
        Flashlight.transform.position = new Vector3(mousePosition.x, mousePosition.y, mousePosition.z);
    }
}
