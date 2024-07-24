using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandNew : MonoBehaviour
{
    private DeckNew deck;
    private Queue<GameObject> deckList;
    private GameObject controller;

    public CardNew selectedCardToDestroy;
    public GameObject ObjectCardToDestroy;
    public bool cardSelected = false;

    private GameObject[] hand;
    private int handSize = 4;

    private int handIndex;

    public void Activate()
    {
        deckList = deck.getDeckList();
        hand = new GameObject[handSize];
        //initial draw
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i] = deckList.Dequeue();
            hand[i].GetComponent<CardNew>().setCardPosition(i);
            hand[i].SetActive(true);
        }
    }

    public void Draw(int index)
    {
        hand[index].GetComponent<Card>().setCardPosition(-1);
        hand[index].GetComponent<Card>().setColor();
        deck.Draw(hand[index]); //CHANGE TO HAND[INDEX] 6/16/2024
        hand[index] = deckList.Dequeue();
        hand[index].GetComponent<Card>().setCardPosition(index);
        Debug.Log("index " + index);
    }

    public void setDeck(DeckNew deck)
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
