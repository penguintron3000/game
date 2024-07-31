using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandNew : MonoBehaviour
{
    private DeckNew deck;
    private Queue<GameObject> deckList;

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

    public void Draw()
    {
        hand[handIndex].GetComponent<CardNew>().setCardPosition(-1);
        hand[handIndex].GetComponent<CardNew>().setColor();
        deck.Draw(hand[handIndex]); //CHANGE TO HAND[INDEX] 6/16/2024
        hand[handIndex] = deckList.Dequeue();
        hand[handIndex].GetComponent<CardNew>().setCardPosition(handIndex);
        Debug.Log("index " + handIndex);
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
                if (hand[i].GetComponent<CardNew>().Equals(selectedCardToDestroy))
                {
                    ObjectCardToDestroy = hand[i];
                    handIndex = i;
                    //Debug.Log(handIndex);
                }
            }
        }
    }

}
