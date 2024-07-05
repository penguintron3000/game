using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public GameObject controller;

	public GameObject mana;
	public ManaManager manaManager;

	public Hand hand;

	GameObject reference = null;

	int boardX;
	int boardY;

	public bool attack = false;

	public bool validMove = false;

	public void Start(){
		mana = GameObject.FindGameObjectWithTag("Mana");
		manaManager = mana.GetComponent<ManaManager>();
		if (attack || validMove) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0, 1);
		}
	}

	public void OnMouseUp(){
		controller = GameObject.FindGameObjectWithTag ("GameController");
		hand = reference.GetComponent<Hand>();

		if (attack && !(boardX == reference.GetComponent<Balls>().getX() && boardY == reference.GetComponent<Balls>().getY())) {
			GameObject tileObject = controller.GetComponent<Game> ().GetPosition (boardX, boardY);
			Destroy (tileObject);
			hand.Draw(hand.getIndex());
			hand.cardSelected = false;
			reference.GetComponent<Balls>().setType("");
			//reference.GetComponent<Balls>().InitiateMove();
			manaManager.spend(5);
        }

		if (validMove)
		{
            controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Balls>().getX(), reference.GetComponent<Balls>().getY());

            reference.GetComponent<Balls>().setX(boardX);
            reference.GetComponent<Balls>().setY(boardY);
            reference.GetComponent<Balls>().SetCoords();

            controller.GetComponent<Game>().SetPosition(reference);

            reference.GetComponent<Balls>().DestroyMove();

            reference.GetComponent<Balls>().InitiateMove();
        }

    }

	public void SetCoords(int x, int y)
	{
		boardX = x;
		boardY = y;
	}

	public void SetReference(GameObject obj)
	{
		reference = obj;
	}

	public GameObject GetReference()
	{
		return reference;
	}

}
