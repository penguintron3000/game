using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public GameObject Player;

	public GameObject[,] positions = new GameObject[8, 8];

	public GameObject[,] tiles = new GameObject[8, 8];

	public GameObject Square;

	public GameObject Card;

    public GameObject[] cards = new GameObject[4];

	private Hand hand;

	public Deck deck;
	
	private bool gameOver = false;

	public Canvas canvas;

	[SerializeField]
	private Transform squareParant;


	// Use this for initialization
	void Start () {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                SetPositionEmpty(i, j);
            }
        }

        Player = Create ("Player", 0, 0); //also creates deck here
		Player.GetComponent<Deck>().setPlayer(Player);
		Player.GetComponent<Deck>().cardObject = Card;
        Player.GetComponent<Deck>().setCanvas(canvas);
        Player.GetComponent<Deck>().setHand(Player.GetComponent<Hand>());
        Player.GetComponent<Deck>().Activate();

        System.Random r  = new System.Random ();
		tiles = CreateTiles(r);


		SetPosition (Player);
		SetPositionTiles (tiles);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(selectedCardToDestroy != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (cards[i].GetComponent<Card>().Equals(selectedCardToDestroy))
				{
					ObjectCardToDestroy = cards[i];
				}
			}
		}


		System.Random r = new System.Random();
        for (int i = 0; i < 4; i++)
        {
			if (cards[i] == null)
			{
                int rGen = r.Next(0, 3);
                GameObject obj = Instantiate(Card, new Vector3(0, 0, -1), Quaternion.identity);

                cards[i] = obj;

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
            }
        }*/
		
    }

	GameObject[,] CreateTiles(System.Random r)
	{
		GameObject[,] t = new GameObject[8,8];
		for(int i = 0; i < 8; i++) //change for board size
		{
			for(int j = 0; j < 8; j++)
			{
				if(i == 0 && j == 0)
				{
					continue;
				}
				else
				{
                    int rGen = r.Next(0, 4);
					GameObject obj = null;
					if(rGen != 0)
					{
                       obj = Instantiate(Square, new Vector3(0, 0, -1), Quaternion.identity, squareParant);
                        //obj = Instantiate(Square, new Vector3(0, 0, -1), Quaternion.identity);
                    }
					t[i, j] = obj;

					if(rGen != 0)
					{
                        Square s = obj.GetComponent<Square>();
						rGen = r.Next(0, 3);
						switch (rGen)
						{
							case 0: s.type = "fire"; break;
							case 1: s.type = "grass";  break;
							case 2: s.type = "water"; break;
						}

						s.setX(i);
						s.setY(j);
						s.Activate();
                    }
                    
                }
			}
		}
		return t;
	}

	GameObject Create(string name, int x, int y){
		GameObject obj = Instantiate (Player, new Vector3 (0, 0, -1), Quaternion.identity);
		Balls handler = obj.GetComponent<Balls> ();
		obj.AddComponent<Deck>();
		deck = obj.GetComponent<Deck> ();
        obj.AddComponent<Hand>();
        handler.name = name;
		handler.setX (x);
		handler.setY (y);
		handler.Activate ();
		return obj;
	}

	public void SetPosition(GameObject obj){

		Balls handler = obj.GetComponent<Balls> ();
		
		positions [handler.getX (), handler.getY ()] = obj;

	}

	public void SetPositionTiles(GameObject[,] obj)
	{
		foreach(GameObject g in obj)
		{
			if(g != null)
			{
                Square s = g.GetComponent<Square>();

                positions[s.getX(), s.getY()] = g;
            }
		}
	}

	public GameObject GetPosition(int x, int y){
		return positions [x, y];
	}

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public bool PositionOnBoard(int x, int y){
		if (x < 0 || y < 0 || x >= positions.GetLength (0) || y >= positions.GetLength (1)) {
			return false;
		}
		return true;
	}



}
