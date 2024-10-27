using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    private int rows = 10;
    private int cols = 10;

    public GameObject plot;

    // Start is called before the first frame update
    void Start()
    {

        GenerateMap();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateMap()
    {

        Vector3 curPos = transform.position;

        for (int row = 0; row < rows; row++)
        {

            for (int col = 0; col < cols; col++)
            {

                Instantiate(plot, curPos, transform.rotation, transform);
                curPos.x += 1;

            }

            curPos.x = 0;
            curPos.y += 1;

        }

    }

    public Vector2 GetCenter()
    {

        return new Vector3(cols / 2, rows / 2);

    }

}
