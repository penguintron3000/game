using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Sprite unit;
    private static System.Random random = new System.Random();


    public void initialize()
    {
        this.GetComponent<SpriteRenderer>().sprite = unit;
        //System.Random r = new System.Random();
        int rand = random.Next(0, 3);
        switch (rand)
        {
            case 1: this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
            case 0: this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); break;
            case 2: this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); break;
            //default: this.GetComponent<SpriteRenderer>().color = new Color(.3f, .3f, .4f, 1); break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
