using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TargetController : MonoBehaviour
{

    public GameObject PointPrefab;

    public GameObject[] Areas;
    public List<Points> PointsNeeded = new List<Points>();
    
    public Text TimeText;
    public Text ActualTimeText;
    
    public float TimeLapseTimer = 0.0f;

    //---Appereance behaviour
    public float TimeLapse;
    public int pointToSeePerTime;
    public float firstTimeToShow = 3;
    public int ciclesCounter = 1;

//    private int lastAreaScanned;

    private Vector3 pivot = new Vector3(0, 0, -1);
    
   
    
    // Spawn Are Radius (set by Scale)
    private float SpawnRadius = 10f;
    void Start()
    {
        SetPointsList();
    }

    void Update()
    {
        
        TimeLapseToAppear();
        
    }

   

    void SetPointsList() {
        Transform[] ParentToScan;

        for (int i = 0; i < Areas.Length; i++)
        {
            ParentToScan = Areas[i].GetComponentsInChildren<Transform>();
            int e = 0;
            foreach (Transform go in ParentToScan)
            {
               if (e != 0)
               {
                  PointsNeeded.Add(go.GetComponent<Points>());
                   go.gameObject.SetActive(false);
               }
                e++;
            }
        }
    
    }

   
  
    //--Set time to appear
    private void TimeLapseToAppear() {
      
        TimeLapseTimer += Time.deltaTime;
        ActualTimeText.text = "Actual Time: " + TimeLapseTimer;

        //First Appear 
        if (TimeLapseTimer > firstTimeToShow) {//Seconds before start exam

            //Start To Show at n time            
            if (TimeLapseTimer >= TimeLapse * ciclesCounter)
            {
                if (ciclesCounter - 2 >= 0)
                {
                    if (PointsNeeded[ciclesCounter - 2].itWasSeen == false)
                        PointsNeeded[ciclesCounter - 2].PointMissed();

                    PointsNeeded[ciclesCounter - 2].gameObject.SetActive(false);

                }
                if (ciclesCounter < PointsNeeded.Count)
                {
                    PointsNeeded[ciclesCounter - 1].gameObject.SetActive(true);
                    ciclesCounter++;
                }

            }
            if (TimeLapseTimer >= TimeLapse * PointsNeeded.Count) {
                Debug.Log("Finish!!");
                for (int i = 0; i < PointsNeeded.Count; i++) {
                    PointsNeeded[i].gameObject.SetActive(true);
                }
            }

        }

        
        

    }


    private IEnumerator ShowAndHide(GameObject go, float time) {
        go.SetActive(true);
        yield return new WaitForSeconds(time);
        go.SetActive(false);

    }


    //--Active elements by order



   
}
