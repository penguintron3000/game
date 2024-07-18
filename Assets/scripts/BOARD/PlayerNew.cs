using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNew : MonoBehaviour
{

    public GameObject move;

    public Sprite PlayerSprite;

    public string type;

    private int count = 0;

    public void Activate()
    {

        this.GetComponent<SpriteRenderer>().sprite = PlayerSprite;

    }

}
