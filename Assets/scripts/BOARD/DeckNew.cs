using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckNew : MonoBehaviour
{
    private Queue<GameObject> deck;
    //dequeue first 4 cards to hand, so starting deck size is 36
    private int deckSize = 40;
    public GameObject cardObject;
    private GameObject Player;

    private HandNew hand;

    public void Activate()
    {
        deck = new Queue<GameObject>();
        System.Random r = new System.Random();
        deck = CreateCards(r);
        //canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        //canvas = canvasObject.GetComponent<Canvas>();
        hand = Player.GetComponent<HandNew>();
        hand.setDeck(this);
        hand.Activate();
    }

    Queue<GameObject> CreateCards(System.Random r)
    {
        Queue<GameObject> c = new Queue<GameObject>();
        for (int i = 0; i < deckSize; i++)
        {
            int rGen = r.Next(0, 3);
            GameObject obj = Instantiate(cardObject, new Vector3(0, 0, -1), Quaternion.identity);
            if(i < 4)
            {
                obj.transform.SetParent(this.transform, false);
            }
            
            c.Enqueue(obj);

            CardNew card = obj.GetComponent<CardNew>();

            card.setReference(Player);

            switch (rGen)
            {
                case 0: card.setType(TypeColor.fire); break;
                case 1: card.setType(TypeColor.grass); break;
                case 2: card.setType(TypeColor.water); break;
            }
            card.setX(5);
            card.setY(i);
            card.SETTEMPID(i);
            card.Activate();
            obj.SetActive(false);
        }
        return c;
    }

    public void setPlayer(GameObject player)
    {
        Player = player;
    }

    public Queue<GameObject> getDeckList()
    {
        return deck;
    }

    public void Draw(GameObject discardedCard)
    {

        GameObject toHand = deck.Peek();

        toHand.SetActive(true);
        toHand.transform.SetParent(this.transform, false);

        discardedCard.transform.SetParent(null);
        discardedCard.SetActive(false);
        

        toHand.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 10);
        /*
        int x = discardedCard.GetComponent<CardNew>().getX();
        int y = discardedCard.GetComponent<CardNew>().getY();
        RectTransform rect = discardedCard.GetComponent<CardNew>().getRectTransform();
        discardedCard.GetComponent<CardNew>().setX(toHand.GetComponent<CardNew>().getX());
        discardedCard.GetComponent<CardNew>().setY(toHand.GetComponent<CardNew>().getY());
        float rectX = discardedCard.GetComponent<CardNew>().getRectX();
        float rectY = discardedCard.GetComponent<CardNew>().getRectY();
        discardedCard.GetComponent<CardNew>().setRectXY(toHand.GetComponent<CardNew>().getRectX(), toHand.GetComponent<CardNew>().getRectY());
        discardedCard.GetComponent<CardNew>().setCardPosition(-1);
        discardedCard.SetActive(false);

        //deck[index] = deck[4];
        toHand.GetComponent<CardNew>().setX(x);
        toHand.GetComponent<CardNew>().setY(y);
        toHand.GetComponent<CardNew>().setRectXY(rectX, rectY);
        discardedCard.GetComponent<CardNew>().SetCoords();
        toHand.GetComponent<CardNew>().SetCoords();
        toHand.GetComponent<CardNew>().Activate();
        toHand.SetActive(true);
        */
        deck.Enqueue(discardedCard);
    }

    public void setHand(HandNew hand)
    {
        this.hand = hand;
    }

    public HandNew getHand()
    {
        return hand;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /**
     * turn our deck from a queue to an array, remove first card on draw, add discarded into first slot and shuffle
     */
    public void Shuffle()
    {

    }
}
