using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_bed_circle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("circle script start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("circle check");
        }
    }
}
