using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Sprite PlayerSprite;

    private int count = 0;

    public TypeColor type;

    public Board board;

    public void Activate()
    {

        this.GetComponent<SpriteRenderer>().sprite = PlayerSprite;
        type = TypeColor.none;
    }

    public void setType(TypeColor type)
    {
        this.type = type;
    }

    public TypeColor getTypeColor()
    {
        return type;
    }

    public Board getBoard()
    {
        return board;
    }

    public void setBoard(Board board)
    {
        this.board = board;
    }
}
