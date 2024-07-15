using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Frame : MonoBehaviour
{
    int spacing = 0;
    int squareSize = 0;

    public GameObject frame;
    public GameObject body;
    public int numBody;
    RectTransform rectTransform;
    private int interval = 130;
    Vector3 anchor;

    public List<GameObject> rows;
    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        anchor = rectTransform.localPosition;
        for (int i = 0; i < numBody; i++)
        {
            GameObject img = Instantiate(body, new Vector3(0, 0, -1), Quaternion.identity, frame.transform);
            rows.Add(img);
            //img.GetComponent<FlexGridRow>().parent = frame;
        }

        StartCoroutine(updatePosition());
    }

    public void FixedUpdate()
    {

    }

    private IEnumerator updatePosition()
    {
        while (true)
        {
            rectTransform.localPosition += new Vector3(0, -1f, 0);
            if (rectTransform.localPosition.y < 10f)
            {
                rectTransform.localPosition = anchor;

                shiftRows();
            }
            yield return null;
        }
    }

    public void shiftRows()
    {
        GameObject last = rows[rows.Count - 1];
        Vector3 lcl = last.transform.localPosition;
        for(int i = rows.Count - 2; i > -1; i--)
        {
            Vector3 slcl = rows[i].transform.localPosition;
            rows[i].transform.localPosition = lcl;
            lcl = slcl;
        }
        last.transform.localPosition = lcl;
    }
}
