using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Board : MonoBehaviour
{
    int spacing = 0;
    int squareSize = 0;

    public GameObject frame;
    public GameObject body;
    public int numBody;
    public int numUnitsPerRow;
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

    public GameObject DeckHandCard;
    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        anchor = rectTransform.localPosition;


        grid = new Unit[numBody, numUnitsPerRow];
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
            boardRow.initialize(this);
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
        remove.GetComponent<BoardRow>().moveInactiveRow();
        last.transform.localPosition = lcl;
    }

    private IEnumerator updatePosition()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "position", new Vector3(anchor.x, -1f, anchor.z),
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
        playerCol = numUnitsPerRow / 2;
        createMove(playerRow, playerCol);
        Debug.Log(playerRow + " " + playerCol);
    }

    List<Unit> markedUnits = new List<Unit>();
    public void createMove(int row, int col)
    {
        Debug.Log(playerRow + " " + playerCol);
        int minCol = col - 1;
        if(minCol < 0)
        {
            minCol = 0;
        }
        int maxCol = col + 1;
        if(maxCol > numUnitsPerRow - 1)
        {
            maxCol = numUnitsPerRow - 1;
        }
        for(int i = 0; i < 3; i++)
        {
            int rowPlacement = row;

            int moveX = 0;
            if (i == 0)
            {
                moveX = -1;
            }
            if (i == 2)
            {
                moveX = 1;
            }
            rowPlacement += moveX + numBody;
            rowPlacement %= numBody;

            for (int j = minCol; j < maxCol + 1; j++)
            {
                if(i == 1 && j == col)
                {
                    continue;
                }
                Unit unit = grid[rowPlacement, j];
                unit.moveActive();
                markedUnits.Add(unit);
                int moveY = 0;
               
                if(j == col - 1)
                {
                    moveY = -1;
                }
                if(j == col + 1)
                {
                    moveY = 1;
                }
                unit.setDirections(moveX, moveY);
            }
        }
    }

    public void moveInactiveAll(int row, int col)
    {
        int numSquares = markedUnits.Count;
        for (int i = 0; i < numSquares; i++)
        {
            markedUnits[0].moveInactive();
            markedUnits.Remove(markedUnits[0]);
        }
    }

    HashSet<Unit> checkSet = new HashSet<Unit>();
    public void ReportGridReady(Unit temp)
    {
        if(temp != null)
        {
            checkSet.Add(temp);
        }
        if(checkSet.Count == numBody * numUnitsPerRow)
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
        moveInactiveAll(playerRow, playerCol);
        target.setPlayer(player);
        player.transform.SetParent(target.transform);
        player.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, -2);
        playerRow = (playerRow + target.getDirectionX() + numBody) % numBody;
        playerCol = (playerCol + target.getDirectionY() + numUnitsPerRow) % numUnitsPerRow;
        //grid[playerRow, playerCol].setPlayer(null);
        createMove(playerRow, playerCol);
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }
}
