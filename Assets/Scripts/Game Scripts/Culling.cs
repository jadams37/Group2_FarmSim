using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culling : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("MainCamera"))
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("Uncull");

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.CompareTag("MainCamera"))
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("Cull");

        }

    }

}
