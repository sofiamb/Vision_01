using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    public GameObject PointPrefab;
    private Vector3 pivot = new Vector3(0, 0, -1);
    public int PointsNeeded;
    Vector3 newPosition;

    // Spawn Are Radius (set by Scale)
    private float SpawnRadius = 10f;
    void Start()
    {
      
      
    }


    //------- not needed ----
    private void spwanAllPointsNeeded() {

        for (int i = 0; i < PointsNeeded; i++) {
          //  if (i < 8)
           // {
                setPoint(newPosition);
                Debug.Log("point_"+i);
            //}                
     }
    }

    private void setPoint(Vector3 newPos)
    {
        GameObject go = Instantiate(PointPrefab);
        
        go.transform.SetParent(this.transform);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        // go.transform.localPosition = new Vector3(0, 0, -1);
      //  go.transform.localPosition = GetPosition();

    }
  
}
