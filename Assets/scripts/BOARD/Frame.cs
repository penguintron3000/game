using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    int spacing = 0;
    int squareSize = 0;

    public GameObject frame;
    public GameObject body;
    public int numBody;
    RectTransform rectTransform;
    private int interval = 1;
    Vector3 anchor;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        anchor = rectTransform.localPosition;
        for (int i = 0; i < numBody; i++)
        {
            GameObject img = Instantiate(body, new Vector3(0, 0, -1), Quaternion.identity, frame.transform);
            //img.GetComponent<FlexGridRow>().parent = frame;
        }
    }

    public void Update()
    {
        rectTransform.localPosition += new Vector3(0, -1, 0);
        if (Time.time >= interval)
        {
            interval = Mathf.FloorToInt(Time.time) + 1;
            rectTransform.localPosition = anchor;
        }
    }
}
