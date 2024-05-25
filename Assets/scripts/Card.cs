using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject controller;

    public GameObject Player;

    int boardX = -1;
    int boardY = -1;

    public string type; //fire grass water

    public Sprite card;


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

        this.GetComponent<SpriteRenderer>().sprite = card;
    }


    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (controller.GetComponent<Game>().selectedCardToDestroy == null && !controller.GetComponent<Game>().cardSelected)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            switch (this.type)
            {
                case "fire": Player.GetComponent<Balls>().setType("fire"); break;
                case "grass": Player.GetComponent<Balls>().setType("grass"); break;
                case "water": Player.GetComponent<Balls>().setType("water"); break;
            }

            controller.GetComponent<Game>().cardSelected = true;

            controller.GetComponent<Game>().selectedCardToDestroy = this;
        }
        else if(controller.GetComponent<Game>().selectedCardToDestroy == this)
        {
            switch (this.type)
            {
                case "fire": this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
                case "grass": this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
                case "water": this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
            }

            Player.GetComponent<Balls>().setType("");

            controller.GetComponent<Game>().cardSelected = false;
            controller.GetComponent<Game>().selectedCardToDestroy = null;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            Card pastTarget = controller.GetComponent<Game>().selectedCardToDestroy;

            switch (controller.GetComponent<Game>().selectedCardToDestroy.type)
            {
                case "fire": pastTarget.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
                case "grass": pastTarget.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
                case "water": pastTarget.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
            }

            Player.GetComponent<Balls>().setType(type);

            controller.GetComponent<Game>().cardSelected = true;

            controller.GetComponent<Game>().selectedCardToDestroy = this;
        }

    }


    public void SetCoords()
    {
        float x = boardX;
        float y = boardY;

        //x *= .66f;
        y *= 1.4f;

        x += -.5f;
        y += -2.1f;

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

    public void setReference(GameObject obj)
    {
        Player = obj;
    }
}
