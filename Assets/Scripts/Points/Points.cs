using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public Color Seen;
    public Color Missed;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void ActivatePoint() {
        this.gameObject.SetActive(true);
    }

    private void timeToBeSeen() { 
    
    }
    public void PointSeen() { changeColor(Seen); }
    public void PointMissed() { changeColor(Missed);}


    private void changeColor(Color Col) {
        this.GetComponent<Renderer>().material.color = Col;
    }
}

