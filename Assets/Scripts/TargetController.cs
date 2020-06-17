using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    public GameObject PointPrefab;
    private Vector3 pivot = new Vector3(0, 0, -1);
    Vector3 newPosition;

    // Spawn Are Radius (set by Scale)
    private float SpawnRadius = 10f;
    void Start()
    {
        spwanAllPointsNeeded();
    }

    private void spwanAllPointsNeeded() {

        for (int i = 0; i < 8; i++) {
            if (i > 8)
            {
                setPoint(newPosition);
            }
                
     }


    }

    private void setPoint(Vector3 newPos)
    {
        GameObject go = Instantiate(PointPrefab);
        
        go.transform.SetParent(this.transform);
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        // go.transform.localPosition = new Vector3(0, 0, -1);
        go.transform.localPosition = newPos;

    }
    // float dist = Vector3.Distance(other.position, transform.position);

    void Update()
    {
        SetRadius();
    }

    //---------
    // Array of Mobs
    public GameObject[] mobs;

    public int totalMobsPosible = 2;
    public int mobsInArea;
    public LayerMask groundLayer;

   //Color for Girmo Cyrcle
    private Color _gizmoColor = Color.red;





    // get a random position inside the Spawn Area
    public Vector3 GetPosition()
    {
        Vector2 posInCyrcle = Random.insideUnitCircle * SpawnRadius;
        Vector3 position = new Vector3(posInCyrcle.x + this.transform.position.x, 10000, posInCyrcle.y + this.transform.position.z);
        RaycastHit hit;

        if (Physics.Raycast(position, -Vector3.up, out hit, Mathf.Infinity, groundLayer))
        {
            position.y = hit.point.y;
        }
        else
            position.y = transform.position.y;
        return position;

    }

    // get a random Mob and returns it
    private GameObject GetRandomMob()
    {
        return mobs[Random.Range(0, mobs.Length)];
    }

    private void SetRadius()
    {
        SpawnRadius = (transform.localScale.x * transform.localScale.y * transform.localScale.z) / 3;
    }

    void OnDrawGizmos()
    {
       
        SetRadius();

        Vector3 currentWaypoint = transform.position;

        Debug.DrawLine(transform.position, currentWaypoint, _gizmoColor);

        Vector3 pP = currentWaypoint + SpawnRadius * new Vector3(1, 0, 0);
        for (float i = 0; i < 2 * System.Math.PI; i += 0.1F)
        {
            Vector3 cP = currentWaypoint + new Vector3((float)System.Math.Cos(i) * SpawnRadius, 0, (float)System.Math.Sin(i) * SpawnRadius);
            Debug.DrawLine(pP, cP, _gizmoColor);
            pP = cP;
        }
        Debug.DrawLine(pP, currentWaypoint + SpawnRadius * new Vector3(1, 0, 0), _gizmoColor);
    }
}
