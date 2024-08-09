using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public TypeColor type;

    public Sprite unit;
    private static System.Random random = new System.Random();

    private bool playerMove = false;
    private bool playerValidMove = false;
    private bool playerAttack = false;

    int moveDirectionX = 0;
    int moveDirectionY = 0;

    public GameObject player;
    private bool playerInit = false;

    private BoardRow boardRow;

    public GameObject moveObject;
    public bool hasMove = false;
    public bool canMove = false;
    public bool hasPlayer = false;

    private Board board;

    private SpriteRenderer spriteRenderer;

    public void initialize(BoardRow boardrow, Board board, bool doCreatePlayer)
    {
        this.board = board;
        this.boardRow = boardrow;
        if (doCreatePlayer)
        {
            this.createPlayer();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unit;
        //System.Random r = new System.Random();
        int rand = random.Next(0, 10);
        if(rand < 3)
        {
            spriteRenderer.color = new Color(1, 0, 0, 1); this.type = TypeColor.fire;
        }
        else if(rand < 6)
        {
            spriteRenderer.color = new Color(0, 1, 0, 1); this.type = TypeColor.grass;
        }
        else if(rand < 9)
        {
            spriteRenderer.color = new Color(0, 0, 1, 1); this.type = TypeColor.water;
        }
        else
        {
            spriteRenderer.color = new Color(0.2f, .4f, .4f, 1); this.type = TypeColor.none;
        }
        
        if (playerInit)
        {
            spriteRenderer.color = new Color(0.2f, .4f, .4f, 1); this.type = TypeColor.none;
        }
        moveObject.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
        //initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createPlayer()
    {
        player = Instantiate(player, new Vector3(0, 0, -2), Quaternion.identity, this.transform);
        playerInit = true;
        player.GetComponent<Player>().Activate();
        player.GetComponent<Player>().setBoard(board);
        board.setPlayer(player);
        board.DeckHandCard.GetComponent<Deck>().setPlayer(player);
        board.DeckHandCard.GetComponent<Deck>().Activate();
        hasPlayer = true;
        boardRow.setHasPlayer(hasPlayer);
    }

    public void setBoardRow(BoardRow parent)
    {
        this.boardRow = parent;
    }

    public void setHasPlayer(bool hasPlayer)
    {
        this.hasPlayer = hasPlayer;
        boardRow.setHasPlayer(hasPlayer);
    }

    public void moveActive()
    {
        //moveObject = Instantiate(movePrefab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        //move.GetComponent<RectTransform>().localPosition = GetComponent<RectTransform>().localPosition;
        moveObject.SetActive(true);
        hasMove = true;
        canMove = false;
    }

    public void moveInactive()
    {
        if(hasMove)
        {
            moveObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            moveObject.SetActive(false);
        }
        hasMove = false;
        canMove = false;
    }

    public void validMove()
    {
        moveObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
        canMove = true;
    }

    public void updateMarkerColor(TypeColor playerType)
    {
        if(type == TypeColor.fire && playerType == TypeColor.water)
        {
            validMove();
        }
        else if (type == TypeColor.water && playerType == TypeColor.grass)
        {
            validMove();
        }
        else if (type == TypeColor.grass && playerType == TypeColor.fire)
        {
            validMove();
        }
        else if(type == TypeColor.none)
        {
            validMove();
        }
        else
        {
            moveObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            canMove = false;
        }
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }

    public void OnMouseUp()
    {
        if (canMove)
        {
            Debug.Log("click " + moveDirectionX + " " + moveDirectionY);
            board.movePlayer(this);
            setHasPlayer(true);
            spriteRenderer.color = new Color(0.2f, .4f, .4f, 1); this.type = TypeColor.none;
        }
    }

    public void setDirections(int x, int y)
    {
        moveDirectionX = x; moveDirectionY = y;
    }

    public int getDirectionX()
    {
        return moveDirectionX;
    }

    public int getDirectionY()
    {
        return moveDirectionY;
    }

    public void setFrame(Board frame)
    {
        board = frame;
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public TypeColor getTypeColor()
    {
        return type;
    }

    public void RefreshColors()
    {
        int rand = random.Next(0, 10);
        if (rand < 3)
        {
            spriteRenderer.color = new Color(1, 0, 0, 1); this.type = TypeColor.fire;
        }
        else if (rand < 6)
        {
            spriteRenderer.color = new Color(0, 1, 0, 1); this.type = TypeColor.grass;
        }
        else if (rand < 9)
        {
            spriteRenderer.color = new Color(0, 0, 1, 1); this.type = TypeColor.water;
        }
        else
        {
            spriteRenderer.color = new Color(0.2f, .4f, .4f, 1); this.type = TypeColor.none;
        }
    }
}
