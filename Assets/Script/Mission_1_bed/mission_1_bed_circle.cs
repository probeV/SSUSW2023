using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission_1_bed_circle : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("circle script start");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetButtonDown(0))
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("circle check");
            audioSource.Play();
        }
    }
    private void OnMouseDown() //마우스 버튼
    {
        Debug.Log("circle check");
        audioSource.Play();
    }
}
