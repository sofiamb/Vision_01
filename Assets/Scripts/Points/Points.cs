using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Color Seen;
    public Color Missed;
    public bool itWasSeen = false;
    
    
    public float SecondsToSeen = 2;
    public TargetController targetController;
    void Start()
    {     
        targetController = GameObject.FindGameObjectWithTag("VisionController").GetComponent<TargetController>();       
    }

    void Update()
    {
        if (isEnter == true)
        {
            if (timer > 2)
            {
                PointSeen();
            }
        }
        

        timerToPoints();
    }
    public float timer = 0.0f;
    public bool isEnter = false;
    private void timerToPoints()
    {
        if (isEnter)
        {
            timer += Time.deltaTime; //Time.deltaTime will increase the value with 1 every second.
            targetController.TimeText.text = "Seen Time = " + timer;
        }
    }
    public void exitToPoint() {
        timer = 0.0f;
        isEnter = false;
    }

    
    public void enterToPoint() {
        timer = 0.0f;
        isEnter = true;        
    }

    public void ActivatePoint()
    {
        this.gameObject.SetActive(true);
    }

    public void PointSeen() { 
        this.changeColor(Seen);
        itWasSeen = true;
    }
    public void PointMissed() { changeColor(Missed);}
    public void PointReset() { changeColor(new Color(255,255,255)); }


    private void changeColor(Color Col) {
        this.GetComponent<Renderer>().material.color = Col;
    }
}

