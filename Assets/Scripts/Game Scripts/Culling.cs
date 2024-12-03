using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culling : MonoBehaviour
{

    // Class relating to Performance Optimizations

    // Method to show all plots in camera view
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("MainCamera"))
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("Uncull");

        }

    }

    // Method to hide all plots out of camera view
    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.CompareTag("MainCamera"))
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("Cull");

        }

    }

}
