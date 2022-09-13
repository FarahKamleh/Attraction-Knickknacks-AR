using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFLighting : MonoBehaviour
{
    // EDIT: game object for tracking cube movement
    public GameObject GFCube;

    // EDIT: game object for turning on and off light
    public GameObject GFLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // EDIT: if the cube is turned up-side-down, change the lighting
        if (Vector3.Dot(GFCube.transform.up, Vector3.down) > 0) {
            
            // EDIT: if light is off, turn on
            if (GFLight.GetComponent<Light>().enabled == false) {
                GFLight.GetComponent<Light>().enabled = true;
            }
            // EDIT: if light is on, turn off
            else {
                GFLight.GetComponent<Light>().enabled = false;
            }
        }
    }
}
