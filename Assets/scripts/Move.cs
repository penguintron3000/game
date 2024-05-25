using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public GameObject controller;

	GameObject reference = null;

	int boardX;
	int boardY;

	public bool attack = false;

	public bool validMove = true;

	public void Start(){
		if (attack) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0, 1);
		}
	}

	public void OnMouseUp(){
		controller = GameObject.FindGameObjectWithTag ("GameController");

		if (attack && !(boardX == reference.GetComponent<Balls>().getX() && boardY == reference.GetComponent<Balls>().getY())) {
			GameObject tileObject = controller.GetComponent<Game> ().GetPosition (boardX, boardY);
			Destroy (tileObject);
			Destroy(controller.GetComponent<Game>().ObjectCardToDestroy);
			controller.GetComponent<Game>().cardSelected = false;
			reference.GetComponent<Balls>().setType("");

        }

		if (validMove)
		{
            controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Balls>().getX(), reference.GetComponent<Balls>().getY());

            reference.GetComponent<Balls>().setX(boardX);
            reference.GetComponent<Balls>().setY(boardY);
            reference.GetComponent<Balls>().SetCoords();

            controller.GetComponent<Game>().SetPosition(reference);

            reference.GetComponent<Balls>().DestroyMove();
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
