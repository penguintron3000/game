using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNew : MonoBehaviour
{
    public HandNew Hand;

    public GameObject Player;

    int boardX = -1;
    int boardY = -1;

    //card data
    public string type; //fire grass water
    public List<int[]> movement;
    public List<int[]> coverage;
    public int draw;
    public int cost;
    public int id;
    public string name;

    //public Sprite card;

    public int CardPosition;

    private RectTransform rectTransform;
    private float rectX;
    private float rectY;

    public void Activate()
    {
        rectTransform = GetComponent<RectTransform>();

        Hand = Player.GetComponent<HandNew>();

        SetCoords();
        /**
        rectX = rectTransform.anchoredPosition.x;
        rectY = rectTransform.anchoredPosition.y;
        Debug.Log(rectTransform.anchoredPosition);
        */

        switch (this.type)
        {
            case "fire": this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
            case "grass": this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
            case "water": this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
        }

        //this.GetComponent<SpriteRenderer>().sprite = card;
    }

    public void setColor()
    {
        switch (this.type)
        {
            case "fire": this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
            case "grass": this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
            case "water": this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
        }
    }

    public void OnMouseUp()
    {

        if (Hand.selectedCardToDestroy == null && !Hand.cardSelected)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            switch (this.type)
            {
                case "fire": Player.GetComponent<Player>().setType("fire"); break;
                case "grass": Player.GetComponent<Player>().setType("grass"); break;
                case "water": Player.GetComponent<Player>().setType("water"); break;
            }

            Hand.cardSelected = true;

            Hand.selectedCardToDestroy = this;

            Player.GetComponent<Player>().InitiateMove();
        }
        else if (Hand.selectedCardToDestroy == this)
        {
            switch (this.type)
            {
                case "fire": this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
                case "grass": this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
                case "water": this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
            }

            Player.GetComponent<Player>().setType("");

            Hand.cardSelected = false;
            Hand.selectedCardToDestroy = null;
            Player.GetComponent<Player>().DestroyMove();
            Player.GetComponent<Player>().InitiateMove();
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            CardNew pastTarget = Hand.selectedCardToDestroy;

            switch (Hand.selectedCardToDestroy.type)
            {
                case "fire": pastTarget.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
                case "grass": pastTarget.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
                case "water": pastTarget.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
            }

            Player.GetComponent<Player>().setType(type);

            Hand.cardSelected = true;

            Hand.selectedCardToDestroy = this;
            Player.GetComponent<Player>().DestroyMove();
            Player.GetComponent<Player>().InitiateMove();
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

        /**
        rectX = rectTransform.anchoredPosition.x;
        rectY = rectTransform.anchoredPosition.y;
        rectTransform.anchoredPosition = new Vector2(rectX, rectY);
        */
    }

    public float getRectX()
    {
        return rectX;
    }
    public float getRectY()
    {
        return rectY;
    }

    public void setRectXY(float x, float y)
    {
        rectX = x;
        rectY = y;
    }
    public RectTransform getRectTransform()
    {
        return rectTransform;
    }

    public void setRectTransform(RectTransform rectTransform)
    {
        this.rectTransform = rectTransform;
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

    public int getCardPosition()
    {
        return CardPosition;
    }

    public void setCardPosition(int cardPosition)
    {
        this.CardPosition = cardPosition;
    }
}
