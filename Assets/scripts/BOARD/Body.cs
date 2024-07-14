using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject body;
    public GameObject image;
    public int numImage;

    public void Start()
    {
        for (int i = 0; i < numImage; i++)
        {
            GameObject img = Instantiate(image, new Vector3(0, 0, -1), Quaternion.identity, body.transform);
            img.GetComponent<Unit>().initialize();
        }
    }

    public void Update()
    {
        
    }
}
