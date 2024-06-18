using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck: MonoBehaviour 
{
    private Queue<GameObject> deck;
    //dequeue first 4 cards to hand, so starting deck size is 36
    private int deckSize = 40;
    public GameObject cardObject;
    [SerializeField] private GameObject canvasObject;
    private Canvas canvas;
    private GameObject Player;

    private Hand hand;

    public void Activate()
    {
        deck = new Queue<GameObject>();
        System.Random r = new System.Random();
        deck = CreateCards(r);
        canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        canvas = canvasObject.GetComponent<Canvas>();
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
            obj.transform.SetParent(canvas.transform, false);

            c.Enqueue(obj);

            Card card = obj.GetComponent<Card>();

            card.setReference(Player);

            switch (rGen)
            {
                case 0: card.type = "fire"; break;
                case 1: card.type = "grass"; break;
                case 2: card.type = "water"; break;
            }
            card.setX(5);
            card.setY(i);
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

        int x = discardedCard.GetComponent<Card>().getX();
        int y = discardedCard.GetComponent<Card>().getY();
        RectTransform rect = discardedCard.GetComponent<Card>().getRectTransform();
        discardedCard.GetComponent<Card>().setX(toHand.GetComponent<Card>().getX());
        discardedCard.GetComponent<Card>().setY(toHand.GetComponent<Card>().getY());
        float rectX = discardedCard.GetComponent<Card>().getRectX();
        float rectY = discardedCard.GetComponent<Card>().getRectY();
        discardedCard.GetComponent<Card>().setRectXY(toHand.GetComponent<Card>().getRectX(), toHand.GetComponent<Card>().getRectY());
        discardedCard.GetComponent<Card>().setCardPosition(-1);
        discardedCard.SetActive(false);

        //deck[index] = deck[4];
        toHand.GetComponent<Card>().setX(x);
        toHand.GetComponent<Card>().setY(y);
        toHand.GetComponent<Card>().setRectXY(rectX, rectY);
        discardedCard.GetComponent<Card>().SetCoords();
        toHand.GetComponent <Card>().SetCoords();
        toHand.GetComponent<Card>().Activate();
        toHand.SetActive(true);

        deck.Enqueue(discardedCard);
    }

    public void setHand(Hand hand)
    {
        this.hand = hand;
    }

    public void setCanvas(Canvas canvas)
    {
        this.canvas = canvas;
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
