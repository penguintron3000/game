using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour {

	public GameObject controller;
	public GameObject move;

	private int x = -1;
	private int y = -1;

	string name = "Player";

	public Sprite Player;

	public bool cancel = false;

	public string type;

	public void Activate(){
		controller = GameObject.FindGameObjectWithTag("GameController");

		SetCoords ();

		this.GetComponent<SpriteRenderer> ().sprite = Player;
	}

    private void Update()
    {
		InitiateMove();
    }
    public void SetCoords(){
		float x = this.x;
		float y = this.y;

		x *= .66f;
		y *= .66f;

		x += -2.3f;
		y += -2.3f;

		this.transform.position = new Vector3 (x, y, -1.0f);

	}

	public void setType(string s)
	{
		type = s; 
	}

	public string getType()
	{
		return type; 
	}

	public void setX(int x){
		this.x = x;
	}

	public int getX(){
		return x;
	}

	public void setY(int y){
		this.y = y;
	}

	public int getY(){
		return y;
	}

    private void OnMouseUp()
    {
        DestroyMove();

		if (!cancel)
		{
            InitiateMove();
        }
		else
		{
			cancel = false;
		}
    }

    public void DestroyMove()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("Move");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMove()
    {
		InitiateMoveSurround();

    }

    public void InitiateMoveLine(int xLength, int yLength)
    {
        Game g = controller.GetComponent<Game>();

		int xD = this.x + xLength;
		int yD = this.y + yLength;

		while(g.PositionOnBoard(xD, yD) && g.GetPosition(xD, yD) == null)
		{
			MoveSpawn(xD, yD, true);
			xD += xLength;
			yD += yLength;
		}

		if(g.PositionOnBoard(xD, yD))
		{
			MoveAttackSpawn(xD, yD);
		}
    }

	public void InitiateMoveL()
	{
		PointMove(x + 1, y + 2);
        PointMove(x - 1, y + 2);
        PointMove(x + 2, y + 1);
        PointMove(x + 2, y - 1);
        PointMove(x + 1, y - 2);
        PointMove(x - 1, y - 2);
        PointMove(x - 2, y + 1);
        PointMove(x - 2, y - 1);
    }

	public void InitiateMoveSurround()
	{
		PointMove(x, y);
		PointMove(x, y + 1);
        PointMove(x, y - 1);
        PointMove(x + 1, y + 1);
        PointMove(x - 1, y + 1);
        PointMove(x + 1, y - 1);
        PointMove(x - 1, y - 1);
        PointMove(x + 1, y);
        PointMove(x - 1, y);
    }

	public void PointMove(int xL, int yL)
	{
		Game g = controller.GetComponent<Game>();
		if (g.PositionOnBoard(xL, yL))
		{
			GameObject obj = g.GetPosition(xL, yL);

			if (obj == null)
			{
				MoveSpawn(xL, yL, true);
			}
			else
			{
				string sqType = "";
				if (xL != x || yL != y)
				{
                    sqType = obj.GetComponent<Square>().getType();
					print(sqType + " enemy");
					print(type);
                }
				if((sqType.Equals("fire") && this.type.Equals("water")) || (sqType.Equals("grass") && this.type.Equals("fire")) || (sqType.Equals("water") && this.type.Equals("grass"))){
                    MoveAttackSpawn(xL, yL);
                }
				else
				{
					if(xL == x && yL == y)
					{
                        MoveSpawn(xL, yL, true);
                    }
					else
					{
                        MoveSpawn(xL, yL, false);
                    }
				}
			}
		}
	}

	public void MoveSpawn(int boardX, int boardY, bool valid)
	{
		float fX = boardX;
		float fY = boardY;

		fX *= .66f;
		fY *= .66f;

		fX += -2.3f;
		fY += -2.3f;

		GameObject mover = Instantiate(move, new Vector3(fX, fY, -3.0f), Quaternion.identity);

		Move movescript = mover.GetComponent<Move>();

		movescript.validMove = valid;

		movescript.SetReference(gameObject);
		movescript.SetCoords(boardX, boardY);
	}

    public void MoveAttackSpawn(int boardX, int boardY)
    {
        float fX = boardX;
        float fY = boardY;

        fX *= .66f;
        fY *= .66f;

        fX += -2.3f;
        fY += -2.3f;

        GameObject mover = Instantiate(move, new Vector3(fX, fY, -3.0f), Quaternion.identity);
		

        Move movescript = mover.GetComponent<Move>();

		movescript.attack = true;

        movescript.SetReference(gameObject);
        movescript.SetCoords(boardX, boardY);
    }
}
