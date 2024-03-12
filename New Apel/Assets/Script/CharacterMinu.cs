using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMinu : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Minu"))
        {
            SceneManager.LoadScene("Main");
        }
        
    }
}
