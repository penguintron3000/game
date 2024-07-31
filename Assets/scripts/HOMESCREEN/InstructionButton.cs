using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionButton : MonoBehaviour
{
    public void OnMouseUp()
    {
        SceneManager.LoadScene("instructions");
        
    }
}
