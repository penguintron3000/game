using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

public class Square : MonoBehaviour
{

    public GameObject controller;


    int boardX = -1;
    int boardY = -1;

    public string type; //fire grass water

    public Sprite square;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.type)
        {
            case "fire": this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
            case "grass": this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
            case "water": this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
        }

        this.GetComponent<SpriteRenderer>().sprite = square;
    }

    public void setType(string s)
    {
        type = s;
    }

    public string getType()
    {
        return type;
    }

    public void SetCoords()
    {
        float x = boardX;
        float y = boardY;

        x *= .66f;
        y *= .66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);

    }

    public void setX(int x)
    {
        boardX = x;
    }

    public int getX()
    {
        return boardX;
    }

    public void setY(int y)
    {
        boardY = y;
    }

    public int getY()
    {
        return boardY;
    }

}
