using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PointofIntrest : MonoBehaviour {

    int CurrentIndex;
    public PointManager pm;
    public NavMeshAgent nvma;
    public GameObject NPC;
    public bool AmAtPoint = false;
    public float lastEntered;
    // Use this for initialization
    void Start()
    {
        nvma = GetComponent<NavMeshAgent>();
        CurrentIndex = pm.NewPosition();
        lastEntered = Time.time;
        MoveToPoint(true);
    }

    void MoveToPoint(bool first)
    {
        Vector3 point;

        if(!first)
        {
          pm.FreePosition(CurrentIndex);
        }
        nvma.updateRotation = true;
        nvma.updatePosition = true;
        CurrentIndex = pm.NewPosition();
        point = pm.points[CurrentIndex].transform.position;
        nvma.SetDestination(point);
        AmAtPoint = false;

    }
    IEnumerator AtPoint()
    {

        yield return new WaitForSeconds(.5f);
        MoveToPoint(false);

    }



    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("NPC")&& other.name==NPC.name && AmAtPoint == true)
        {
            Debug.Log(other.tag);

                StartCoroutine(AtPoint());
                lastEntered = Time.time;
            
        }
        if (other.gameObject == pm.points[CurrentIndex])
        {
            Debug.Log("At Point ");
            AmAtPoint = true;
            //nvma.updateRotation = false;
            //nvma.updatePosition = false;
        }
    }




}
