using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Material myMaterial;

    void Start()
    {
        float redX = Random.Range(0, 256);
        float greenX = Random.Range(0, 256);
        float blueX = Random.Range(0, 256);
        /* Debug.Log(redX);
        Debug.Log(greenX);
        Debug.Log(blueX); */
        float colourSum = redX + greenX + blueX;
        redX = redX / colourSum;
        greenX = greenX / colourSum;
        blueX = blueX / colourSum;

        myMaterial.color = new Color(redX, greenX, blueX, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
