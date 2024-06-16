using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck: MonoBehaviour 
{
    private GameObject[] deck;
    private int deckSize = 40;
    public GameObject cardObject;
    [SerializeField] private GameObject canvasObject;
    private Canvas canvas;
    private GameObject Player;

    private Hand hand;

    public void Activate()
    {
        deck = new GameObject[deckSize];
        System.Random r = new System.Random();
        deck = CreateCards(r);
        canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        canvas = canvasObject.GetComponent<Canvas>();
        hand.setDeck(this);
        hand.Activate();
    }

    GameObject[] CreateCards(System.Random r)
    {
        GameObject[] c = new GameObject[deckSize];
        for (int i = 0; i < deckSize; i++)
        {
            int rGen = r.Next(0, 3);
            GameObject obj = Instantiate(cardObject, new Vector3(0, 0, -1), Quaternion.identity);
            obj.transform.SetParent(canvas.transform, false);

            c[i] = obj;

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

    public GameObject[] getDeckList()
    {
        return deck;
    }

    public void Draw(int index)
    {
        GameObject saveCard = deck[index];

        int x = saveCard.GetComponent<Card>().getX();
        int y = saveCard.GetComponent<Card>().getY();
        RectTransform rect = saveCard.GetComponent<Card>().getRectTransform();
        saveCard.GetComponent<Card>().setX(deck[4].GetComponent<Card>().getX());
        saveCard.GetComponent<Card>().setY(deck[4].GetComponent<Card>().getY());
        float rectX = saveCard.GetComponent<Card>().getRectX();
        float rectY = saveCard.GetComponent<Card>().getRectY();
        saveCard.GetComponent<Card>().setRectXY(deck[4].GetComponent<Card>().getRectX(), deck[4].GetComponent<Card>().getRectY());
        saveCard.GetComponent<Card>().setCardPosition(-1);
        saveCard.SetActive(false);

        //deck[index] = deck[4];
        deck[4].GetComponent<Card>().setX(x);
        deck[4].GetComponent<Card>().setY(y);
        deck[4].GetComponent<Card>().setRectXY(rectX, rectY);
        saveCard.GetComponent<Card>().SetCoords();
        deck[4].GetComponent <Card>().SetCoords();
        deck[4].GetComponent<Card>().Activate();
        deck[index] = deck[4];
        deck[index].SetActive(true);

        //Debug.Log(saveCard.GetComponent<Card>().getRectTransform().anchoredPosition);
        //Debug.Log(deck[index].GetComponent<Card>().getRectTransform().anchoredPosition);

        for (int i = 4; i < deckSize - 1; i++)
        {
            deck[i] = deck[i + 1];
        }
        deck[deckSize - 1] = saveCard;
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
}
