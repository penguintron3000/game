using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject boardObject;

    private int numRows = 8;
    private int numCols = 8;

    private Row[] rows;

    [SerializeField] private GameObject Row;
    [SerializeField] private GameObject Col;

    private void Start()
    {
        rows = new Row[numRows];

    }

    private void CreateRows()
    {
        GameObject obj = Instantiate(Row, new Vector3(0, 0, -1), Quaternion.identity);
    }
}
