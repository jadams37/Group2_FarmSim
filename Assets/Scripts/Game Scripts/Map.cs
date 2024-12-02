using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Map : MonoBehaviour
{

    private int rows = 25;
    private int cols = 50;
    private int maxRows = 50;
    private int maxCols = 100;
    private int curMapExpansion = 1;

    public int[] xBounds;
    public int[] yBounds;

    public GameObject plot;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(GenerateMap());
        xBounds = new int[]{0, cols};
        yBounds = new int[]{0, rows};
        StartCoroutine(LockPlots());


    }

    // Update is called once per frame
    void Update()
    {



    }

    private void UnlockPlots()
    {

        for (int curPlot = 0; curPlot < transform.childCount; curPlot++)
        {

            GameObject plot = transform.GetChild(curPlot).gameObject;
            if(plot.transform.position.x <= xBounds[1] || plot.transform.position.y <= yBounds[1])
                plot.GetComponent<Plot>().SetIsCultivable(true);

        }

    }

    IEnumerator GenerateMap()
    {

        yield return new WaitForEndOfFrame();

        Vector3 curPos = transform.position;

        for (int row = 0; row < maxRows; row++)
        {

            for (int col = 0; col < maxCols; col++)
            {

                Instantiate(plot, curPos, transform.rotation, transform);
                curPos.x += 1;

            }

            curPos.x = 0;
            curPos.y += 1;

        }

    }

    IEnumerator LockPlots()
    {

        yield return new WaitForEndOfFrame();
        int unlockedPlots = 0;
        for(int curPlot = 0; curPlot < transform.childCount; curPlot++)
        {

            GameObject plot = transform.GetChild(curPlot).gameObject;
            if (plot.transform.position.x >= xBounds[1] || plot.transform.position.y >= yBounds[1])
                plot.GetComponent<Plot>().SetIsCultivable(false);
            else
                unlockedPlots++;

        }

        Debug.Log("Unlocked plots: " + unlockedPlots);
        
    }

    public Vector2 GetCenter()
    {

        return new Vector2(cols / 2, rows / 2);

    }

}
