using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    int boardX = -1;
    int boardY = -1;

    public void SetCoords()
    {
        float x = boardX;
        float y = boardY;

        x *= .66f;
        y *= .66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);

    }
}
