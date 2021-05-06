using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{

    public Text timer;
    public float  time;
    private float currentTime;

    // Start is called before the first frame update
    void Start(){
        currentTime = time * 60;
    }

    // Update is called once per frame
    void Update(){

        currentTime -= 1 * Time.deltaTime;
        timer.text = "Time: " + currentTime.ToString("0");

        if(currentTime <= 0){
            currentTime = 0;
        }

        
    }
}
