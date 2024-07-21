using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    enum Type{
        fire,
        grass,
        water,
        none
    }

    Type type;

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

    public GameObject movePrefab;
    public bool hasMove = false;

    private Board board;

    public GameObject moveObject;

    private SpriteRenderer spriteRenderer;

    public void initialize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unit;
        //System.Random r = new System.Random();
        int rand = random.Next(0, 4);
        switch (rand)
        {
            case 0: spriteRenderer.color = new Color(1, 0, 0, 1); this.type = Type.fire; break;
            case 1: spriteRenderer.color = new Color(0, 1, 0, 1); this.type = Type.grass; break;
            case 2: spriteRenderer.color = new Color(0, 0, 1, 1); this.type = Type.water; break;
            default: spriteRenderer.color = new Color(0.2f, .4f, .4f, 1); this.type = Type.none; break;
        }
        if (playerInit)
        {
            spriteRenderer.color = new Color(0.2f, .4f, .4f, 1); this.type = Type.none;
        }
        boardRow.ReportNumReady(this);
        movePrefab.SetActive(false);

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
        board.setPlayer(player);
    }

    public void setParent(BoardRow parent)
    {
        this.boardRow = parent;
    }

    public void addMove()
    {
        //moveObject = Instantiate(movePrefab, new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        //move.GetComponent<RectTransform>().localPosition = GetComponent<RectTransform>().localPosition;
        movePrefab.SetActive(true);
        hasMove = true;
    }

    public void DestroyMove()
    {
        if(hasMove)
        {
            movePrefab.SetActive(false);
        }
        hasMove = false;
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }

    public void OnMouseUp()
    {
        if (hasMove)
        {
            Debug.Log("click " + moveDirectionX + " " + moveDirectionY);
            board.movePlayer(this);
            spriteRenderer.color = new Color(0.2f, .4f, .4f, 1); this.type = Type.none;
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
}
