using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNew : MonoBehaviour
{
    public GameObject move;
    public GameObject moveObject;

    public void addMove(Unit unit)
    {
        moveObject = Instantiate(move, new Vector3(0, 0, 0), Quaternion.identity, unit.transform);
    }

    public void DestroyMove()
    {
        Destroy(moveObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
