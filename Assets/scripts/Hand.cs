using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Deck deck;
    private GameObject[] deckList;
    private int deckSize;
    private GameObject controller;

    public Card selectedCardToDestroy;
    public GameObject ObjectCardToDestroy;
    public bool cardSelected = false;

    private GameObject[] hand;
    private int handSize = 4;

    private int handIndex;

    public void Activate()
    {
        deckList = deck.getDeckList();
        hand = new GameObject[handSize];
        deckSize = deckList.Length;
        //initial draw
        for(int i = 0; i < hand.Length; i++)
        {
            hand[i] = deckList[i];
            hand[i].GetComponent<Card>().setCardPosition(i);
            hand[i].SetActive(true);
        }
    }

    public void Draw(int index)
    {
        hand[index].GetComponent<Card>().setCardPosition(-1);
        hand[index].GetComponent<Card>().setColor();
        deck.Draw(index);
        hand[index] = deckList[index];
        hand[index].GetComponent<Card>().setCardPosition(index);
        Debug.Log("index " + index);
    } 

    public void setDeck(Deck deck)
    {
        this.deck = deck;
    }

    public int getIndex()
    {
        return handIndex;
    }

    private void Update()
    {
        if (selectedCardToDestroy != null)
        {
            for (int i = 0; i < 4; i++)
            {
                if (hand[i].GetComponent<Card>().Equals(selectedCardToDestroy))
                {
                    ObjectCardToDestroy = hand[i];
                    handIndex = i;
                    Debug.Log(handIndex);
                }
            }
        }
    }

}
