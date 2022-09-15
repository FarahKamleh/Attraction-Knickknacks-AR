using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuxoJrLighting : MonoBehaviour
{
    // EDIT: game object for tracking cube movement
    public GameObject pixarCube;

    // EDIT: game object for turning on and off light
    public GameObject luxoLight;

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
        // EDIT: if the cube has been turned up-side-down, change the lighting
        if ((Vector3.Dot(pixarCube.transform.up, Vector3.down) > 0) && (prev == false)) {
            
            // EDIT: if light is off, turn on
            if (luxoLight.GetComponent<Light>().enabled == false) {

                // EDIT: turn on light
                luxoLight.GetComponent<Light>().enabled = true;

                // EDIT: set prev to true
                prev = true;
            }
            // EDIT: if light is on, turn off
            else {

                // EDIT: turn light off
                luxoLight.GetComponent<Light>().enabled = false;

                // EDIT: set prev to true
                prev = true;
            }
        }

        // EDIT: if the cube is right-side-up, change the value of prev to false
        else if (!(Vector3.Dot(pixarCube.transform.up, Vector3.down) > 0) && (prev == true)) {

            // EDIT: set to false
            prev = false;
        }
    }
}
