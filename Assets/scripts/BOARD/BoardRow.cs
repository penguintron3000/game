using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRow : MonoBehaviour
{
    // TODO: public GameObject body;
    public GameObject unitPrefab;
    public int numUnits;
    Boolean initPlayer = false;
    public GameObject player;
    public Unit[] units;

    private Board board;
    private int numReady = 0;

    public bool hasPlayer = false;
    public void Start()
    {
    }

    public void initialize(Board board)
    {
        this.board = board;
        units = new Unit[numUnits];
        StartCoroutine(delayedCreateImages());
    }

    private IEnumerator delayedCreateImages()
    {
        //ToDo: yield return new WaitForSeconds(1.0f);
        yield return null;  // wait one frame
        //System.Random random = new System.Random();
        for (int i = 0; i < numUnits; i++)
        {
            // TODO: GameObject img = Instantiate(image, new Vector3(0, 0, -1), Quaternion.identity, body.transform);
            bool createPlayer = false;
            GameObject unit = Instantiate(unitPrefab, new Vector3(0, 0, -1), Quaternion.identity, this.transform);
            Unit unitObject = unit.GetComponent<Unit>();
            unitObject.setBoardRow(this);
            if (i == numUnits / 2 && initPlayer)
            {
                createPlayer = true;
                board.setFirstUnit(unitObject);
            }
            units[i] = (unitObject);
            ReportGridReady(unitObject);
            unitObject.initialize(this, board, createPlayer);
            //img.GetComponent<Unit>().initialize(random);

        }
        // yield break;  // if this is the last statement, you do not have to put yield break here.
    }

    public void initializePlayer()
    {
        initPlayer = true;
    }

    public void buildGrid(Unit[,] grid, int index)
    {
        //Debug.Log(rows + " " + cols);
        for(int i  = 0; i < numUnits; i++)
        {
            grid[index, i] = units[i];
        }
    }

    public int getNumUnits()
    {
        return numUnits;
    }

    public void ReportGridReady(Unit temp)
    {
        board.ReportGridReady(temp);
    }
    public void moveInactiveRow()
    {
        for(int i = 0; i < units.Length; i++)
        {
            units[i].moveInactive();
        }
    }

    public void setHasPlayer(bool hasPlayer)
    {
        this.hasPlayer = hasPlayer;
    }

    public bool getHasPlayer()
    {
        return hasPlayer;
    }

    public void RefreshColors()
    {
        for (int i = 0; i < units.Length; i++)
        {
            units[i].RefreshColors();
        }
    }
}