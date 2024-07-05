using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    List<Card> collection = new List<Card>();

    /**
    public string type; //fire grass water
    public List<int[]> movement;
    public List<int[]> coverage;
    public int draw;
    public int cost;
    public int id;
    public string name;
    */

    public void Start()
    {
        Card c0 = new Card();
        c0.type = "fire";
        
    }
}
