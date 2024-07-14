using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    // TODO: public GameObject body;
    public GameObject image;
    public int numImage;

    public void Start()
    {
        StartCoroutine(delayedCreateImages());
    }

    public void Update()
    {

    }

    private IEnumerator delayedCreateImages()
    {
        //ToDo: yield return new WaitForSeconds(1.0f);
        yield return null;  // wait one frame
        //System.Random random = new System.Random();
        for (int i = 0; i < numImage; i++)
        {
            // TODO: GameObject img = Instantiate(image, new Vector3(0, 0, -1), Quaternion.identity, body.transform);
            GameObject img = Instantiate(image, new Vector3(0, 0, -1), Quaternion.identity, this.transform);
            //img.GetComponent<Unit>().initialize(random);
        }

        // yield break;  // if this is the last statement, you do not have to put yield break here.
    }
}