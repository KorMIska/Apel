using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayScenaLes()
    {
        SceneManager.LoadScene("Test");

    }

    public void PlayScenaLager()
    {
        SceneManager.LoadScene("treningLager");
    }
}
