using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cultivate_ground : MonoBehaviour
{
    public Material red, blue;
    private Material currentMaterial;
    public GameObject spawnPrefab;
    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        // Check if the clicked object is this game object
        Vector3 hitPosition = hit.point;
        Debug.Log("Hit Position: " + hitPosition);

        // Instantiate the prefab at the hit point (with optional rotation)
        Instantiate(spawnPrefab, hitPosition, Quaternion.identity);

        // Toggle between red and blue materials
        if (currentMaterial == red)
        {
            this.GetComponent<Renderer>().material = blue;
            currentMaterial = blue; // Update the reference
        }
        else
        {
            this.GetComponent<Renderer>().material = red;
            currentMaterial = red; // Update the reference
        }

    }
}