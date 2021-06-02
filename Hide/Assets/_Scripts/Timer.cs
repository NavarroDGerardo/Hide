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
    }

    // Update is called once per frame
    void Update(){

        if(time > 0){
            time -= Time.deltaTime; 
        }else{
            time = 0;
        }

        displayTime(time);
    }

    void displayTime(float time){
        if(time < 0){
            time = 0; 
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
