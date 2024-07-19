using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    // TODO: public GameObject body;
    public GameObject image;
    public int numImage;
    Boolean initPlayer = false;
    public GameObject player;
    public Unit[] units;

    private Frame parent;
    private int numReady = 0;
    public void Start()
    {
    }

    public void initialize()
    {
        units = new Unit[numImage];
        StartCoroutine(delayedCreateImages());
    }

    private IEnumerator delayedCreateImages()
    {
        //ToDo: yield return new WaitForSeconds(1.0f);
        yield return null;  // wait one frame
        //System.Random random = new System.Random();
        for (int i = 0; i < numImage; i++)
        {
            // TODO: GameObject img = Instantiate(image, new Vector3(0, 0, -1), Quaternion.identity, body.transform);
            GameObject img = Instantiate(image, new Vector3(0, 0, -1), Quaternion.identity, this.transform);
            if (i == numImage / 2 && initPlayer)
            {
                img.GetComponent<Unit>().createPlayer();
            }
            units[i] = (img.GetComponent<Unit>());
            img.GetComponent<Unit>().setParent(this);
            img.GetComponent<Unit>().initialize();
            img.GetComponent<Unit>().setFrame(parent);
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
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        int balls = 5;
        //Debug.Log(rows + " " + cols);
        for(int i  = 0; i < numImage; i++)
        {
            grid[index, i] = units[i];
        }
    }

    public int numUnits()
    {
        return numImage;
    }

    public void setParent(Frame frame)
    {
        this.parent = frame;
    }

    public void incrementNumReady()
    {
        numReady++;
        if (numReady >= numImage)
        {
            numReady %= numImage;
            parent.incrementNumReady();
            if (parent.getNumReady() >= parent.numBody)
            {
                parent.createGrid();
            }
        }
    }
    public void DestroyMove()
    {
        for(int i = 0; i < units.Length; i++)
        {
            units[i].DestroyMove();
        }
    }
}