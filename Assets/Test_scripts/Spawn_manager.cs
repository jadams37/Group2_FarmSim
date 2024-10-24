using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{
    public GameObject dotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            Vector3 spawn_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject g = Instantiate(dotPrefab, (Vector2)spawn_position, Quaternion.identity);
        }
    }
}
