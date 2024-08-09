using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Card : MonoBehaviour
{
    public Hand Hand;
    public GameObject board;
    public GameObject Player;

    int boardX = -1;
    int boardY = -1;

    //card data
    public TypeColor type;

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

    public int TEMPID;

    public void Activate()
    {
        rectTransform = GetComponent<RectTransform>();

        Hand = Player.GetComponent<Hand>();
        
        SetCoords();
        /**
        rectX = rectTransform.anchoredPosition.x;
        rectY = rectTransform.anchoredPosition.y;
        Debug.Log(rectTransform.anchoredPosition);
        */

        switch (this.type)
        {
            case TypeColor.fire: this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
            case TypeColor.water: this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
            case TypeColor.grass: this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
        }

        //this.GetComponent<SpriteRenderer>().sprite = card;
    }

    public void setColor()
    {
        switch (this.type)
        {
            case TypeColor.fire: this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
            case TypeColor.water: this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
            case TypeColor.grass: this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
        }
    }

    public void OnMouseUp()
    {
        Debug.Log("context");

        if (Hand.selectedCardToDestroy == null && !Hand.cardSelected)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            switch (this.type)
            {
                case TypeColor.fire: Player.GetComponent<Player>().setType(TypeColor.fire); break;
                case TypeColor.grass: Player.GetComponent<Player>().setType(TypeColor.grass); break;
                case TypeColor.water: Player.GetComponent<Player>().setType(TypeColor.water); break;
            }

            Hand.cardSelected = true;

            Hand.selectedCardToDestroy = this;
            
            //Player.GetComponent<Player>().InitiateMove();
        }
        else if (Hand.selectedCardToDestroy == this)
        {
            switch (this.type)
            {
                case TypeColor.fire: this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
                case TypeColor.water: this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
                case TypeColor.grass: this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
            }

            Player.GetComponent<Player>().setType(TypeColor.none);

            Hand.cardSelected = false;
            Hand.selectedCardToDestroy = null;
            //Player.GetComponent<Player>().DestroyMove();
            //Player.GetComponent<Player>().InitiateMove();
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            Card pastCard = Hand.selectedCardToDestroy;
            TypeColor pastTarget = Hand.selectedCardToDestroy.type;

            switch (pastTarget)
            {
                case TypeColor.fire: pastCard.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
                case TypeColor.water: pastCard.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
                case TypeColor.grass: pastCard.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
            }

            Player.GetComponent<Player>().setType(type);

            Hand.cardSelected = true;

            Hand.selectedCardToDestroy = this;
            //Player.GetComponent<PlayerNew>().DestroyMove();
            //Player.GetComponent<PlayerNew>().InitiateMove();
        }
        Player.GetComponent<Player>().getBoard().updateMarkerColor();
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

    public void setType(TypeColor type)
    {
        this.type = type;
    }

    int count = 0;
    public void SETTEMPID(int t){
        TEMPID = t;
        //Debug.Log("called " + count);
        count++;
    }
}
