using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public UnityEngine.UI.Image manaBar;
    public float manaAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spend(float amount)
    {
        if (manaAmount >= amount)
        {
            manaAmount -= amount;
            manaBar.fillAmount = manaAmount / 100f;
            Debug.Log("hit");
        }
    }
}
