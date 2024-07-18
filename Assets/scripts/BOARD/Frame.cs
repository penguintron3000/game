using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Frame : MonoBehaviour
{
    int spacing = 0;
    int squareSize = 0;

    public GameObject frame;
    public GameObject body;
    public int numBody;
    RectTransform rectTransform;
    private int interval = 130;
    Vector3 anchor;

    int playerTrackerRow = 0;
    int playerTrackerCol = 0;

    public List<GameObject> rows;

    public Unit[,] grid;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        anchor = rectTransform.localPosition;

        int numUnitsPerRow = 0;

        for (int i = 0; i < numBody; i++)
        {
            GameObject img = Instantiate(body, new Vector3(0, 0, -1), Quaternion.identity, frame.transform);
            if (i == 1)
            {
                img.GetComponent<Body>().initializePlayer();
            }
            rows.Add(img);
            numUnitsPerRow = img.GetComponent<Body>().numUnits();
            //img.GetComponent<FlexGridRow>().parent = frame;
        }

        grid = new Unit[numBody, numUnitsPerRow];
        createGrid();

        StartCoroutine(updatePosition());
    }

    /*
    private IEnumerator updatePosition()
    {
        while (true)
        {
            rectTransform.localPosition += new Vector3(0, -1f, 0);
            if (rectTransform.localPosition.y < 10f)
            {
                rectTransform.localPosition = anchor;

                shiftRows();
            }
            yield return null;
        }
    }
    */
    public void shiftRows()
    {
        GameObject last = rows[rows.Count - 1];
        Vector3 lcl = last.transform.localPosition;
        for(int i = rows.Count - 2; i > -1; i--)
        {
            Vector3 slcl = rows[i].transform.localPosition;
            rows[i].transform.localPosition = lcl;
            lcl = slcl;
        }
        last.transform.localPosition = lcl;
    }

    private IEnumerator updatePosition()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "position", new Vector3(anchor.x, 1f, anchor.z),
            "islocal", true,
            "time", 2.0f,
            "oncomplete", "onMoveCompleteCallback",
            "oncompletetarget", gameObject,
            "easetype", iTween.EaseType.linear
        ));
        yield break;
    }


    private void onMoveCompleteCallback()
    {
        rectTransform.localPosition = anchor;
        shiftRows();
        StartCoroutine(updatePosition());
    }
    
    public void createGrid()
    {
        for(int i = 0; i < numBody; i++)
        {
            rows[i].GetComponent<Body>().buildGrid(grid, i);
        }
    }

    public void updateMoveTiles()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {

            }
        }
    }
}
