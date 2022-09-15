using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFLighting : MonoBehaviour
{
    // EDIT: game object for tracking cube movement
    public GameObject GFCube;

    // EDIT: game object for turning on and off light
    public GameObject GFLight;

    // EDIT: use a bool value to determine if cube is right-side-up or up-side-down
    bool prev;

    // Start is called before the first frame update
    void Start()
    {
        // EDIT: false means up, true means down; initial state is up, so initial value false
        prev = false;
    }

    // Update is called once per frame
    void Update()
    {
        // EDIT: if the cube is turned up-side-down, change the lighting
        if ((Vector3.Dot(GFCube.transform.up, Vector3.down) > 0) && (prev == false)) {
            
            // EDIT: if light is off, turn on
            if (GFLight.GetComponent<Light>().enabled == false) {

                // EDIT: turn on light
                GFLight.GetComponent<Light>().enabled = true;

                // EDIT: set prev to true
                prev = true;
            }
            // EDIT: if light is on, turn off
            else {
                // EDIT: turn light off
                GFLight.GetComponent<Light>().enabled = false;

                // EDIT: set prev to true
                prev = true;
            }
        }

        // EDIT: if the cube is right-side-up, change the value of prev to false
        else if (!(Vector3.Dot(GFCube.transform.up, Vector3.down) > 0) && (prev == true)) {

            // EDIT: set to false
            prev = false;
        }
    }
}
