using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{

    public static GameMasterScript instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<GameMasterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void succesfulClick()
    {
        Debug.Log("Player clicked - Success event");
    }

    public void missedClick()
    {
        Debug.Log("Missed event");
    }
}
