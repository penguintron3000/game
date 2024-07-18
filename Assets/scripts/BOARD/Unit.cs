using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    enum Type{
        fire,
        grass,
        water,
        none
    }

    Type type;

    public Sprite unit;
    private static System.Random random = new System.Random();

    private bool playerMove = false;
    private bool playerValidMove = false;
    private bool playerAttack = false;

    int moveDirectionX = 0;
    int moveDirectionY = 0;

    public GameObject player;
    private bool playerInit = false;

    public void initialize()
    {
        this.GetComponent<SpriteRenderer>().sprite = unit;
        //System.Random r = new System.Random();
        int rand = random.Next(0, 4);
        switch (rand)
        {
            case 0: this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); this.type = Type.fire; break;
            case 1: this.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1); this.type = Type.grass; break;
            case 2: this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1); this.type = Type.water; break;
            default: this.GetComponent<SpriteRenderer>().color = new Color(0.2f, .4f, .4f, 1); this.type = Type.none; break;
        }
        if (playerInit)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.2f, .4f, .4f, 1); this.type = Type.none;
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

    public void createPlayer()
    {
        player = Instantiate(player, new Vector3(0, 0, -2), Quaternion.identity, this.transform);
        playerInit = true;
    }
}
