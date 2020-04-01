using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycleJourNuit : MonoBehaviour
{

    public float temps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, temps * Time.deltaTime);
        transform.LookAt(Vector3.zero);


    }
}
