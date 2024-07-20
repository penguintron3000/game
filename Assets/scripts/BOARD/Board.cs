using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    int spacing = 0;
    int squareSize = 0;

    public GameObject frame;
    public GameObject body;
    public int numBody;
    public int numUnitsPerBody;
    RectTransform rectTransform;
    private int interval = 130;
    Vector3 anchor;

    int playerRow = 1;
    int playerCol = 4;

    public List<GameObject> rows;

    public Unit[,] grid;
    private int numReady = 0;

    private int removeMove = 0;

    private GameObject player;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        anchor = rectTransform.localPosition;


        grid = new Unit[numBody, numUnitsPerBody];
        removeMove = numBody;

        for (int i = 0; i < numBody; i++)
        {
            GameObject img = Instantiate(body, new Vector3(0, 0, -1), Quaternion.identity, frame.transform);
            BoardRow boardRow = img.GetComponent<BoardRow>();
            if (i == 1)
            {
                boardRow.initializePlayer();
            }
            rows.Add(img);
            boardRow.setParent(this);
            boardRow.initialize();
            //img.GetComponent<FlexGridRow>().parent = frame;
        }
        //createGrid();

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
        removeMove -= 1;
        if(removeMove < 0)
        {
            removeMove = numBody - 1;
        }
        GameObject remove = rows[removeMove];
        remove.GetComponent<BoardRow>().DestroyMove();
        last.transform.localPosition = lcl;
    }

    public void DestroyAllMove(int row, int col)
    {
        int minRow = row - 1;
        if (minRow < 0)
        {
            minRow = 0;
        }
        int maxRow = row + 1;
        if (maxRow > numBody)
        {
            maxRow = numBody;
        }
        int minCol = col - 1;
        if (minCol < 0)
        {
            minCol = 0;
        }
        int maxCol = col + 1;
        if (maxCol > numUnitsPerBody)
        {
            maxCol = numUnitsPerBody;
        }
        for (int i = minRow; i < maxRow + 1; i++)
        {
            for (int j = minCol; j < maxCol + 1; j++)
            {
                if (i == row && j == col)
                {
                    continue;
                }
                grid[i, j].DestroyMove();
            }
        }
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
            rows[i].GetComponent<BoardRow>().buildGrid(grid, i);
        }
        playerCol = numUnitsPerBody / 2;
        createMove(playerRow, playerCol);
        Debug.Log(playerRow + " " + playerCol);
    }

    public void createMove(int row, int col)
    {
        int minRow = row - 1;
        if(minRow < 0)
        {
            minRow = 0;
        }
        int maxRow = row + 1;
        if(maxRow > numBody)
        {
            maxRow = numBody;
        }
        int minCol = col - 1;
        if(minCol < 0)
        {
            minCol = 0;
        }
        int maxCol = col + 1;
        if(maxCol > numUnitsPerBody)
        {
            maxCol = numUnitsPerBody;
        }
        for(int i = minRow; i < maxRow + 1; i++)
        {
            int moveX = 0;
            if (i == row - 1)
            {
                moveX = -1;
            }
            if (i == row + 1)
            {
                moveX = 1;
            }

            for (int j = minCol; j < maxCol + 1; j++)
            {
                if(i == row && j == col)
                {
                    continue;
                }
                grid[i, j].addMove();
                int moveY = 0;
               
                if(j == col - 1)
                {
                    moveY = -1;
                }
                if(j == col + 1)
                {
                    moveY = 1;
                }
                grid[i, j].setDirections(moveX, moveY);
            }
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
    HashSet<Unit> checkSet = new HashSet<Unit>();

    public void CheckNumReady(Unit temp)
    {
        checkSet.Add(temp);
        if(checkSet.Count == numBody * numUnitsPerBody)
        {
            createGrid();
        }
    }

    public int getNumReady()
    {
        return numReady;
    }

    int newTrackRow = 1;
    int newTrackCol = 4;

    public void movePlayer(Unit target)
    {
        DestroyAllMove(playerRow, playerCol);
        target.setPlayer(player);
        player.transform.SetParent(target.transform);
        player.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, -2);
        playerRow = (playerRow + target.getDirectionX());
        playerCol = (playerCol + target.getDirectionY());
        Debug.Log(playerRow + " " + playerCol);
        //grid[playerRow, playerCol].setPlayer(null);
        createMove(playerRow, playerCol);
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }
}
