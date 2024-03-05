using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        SetCanvasFocus();
    }

    public void PlayScenaLes()
    {
        SceneManager.LoadScene("Test");
        SetCanvasFocus();
    }

    public void PlayScenaLager()
    {
        SceneManager.LoadScene("treningLager");
        SetCanvasFocus();
    }

    private void SetCanvasFocus()
    {
        GameObject canvasObject = GameObject.Find("Canvas"); // Замените "Canvas" на имя вашего объекта Canvas
        if (canvasObject != null)
        {
            canvasObject.GetComponent<Canvas>().worldCamera = Camera.main;
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            UnityEngine.EventSystems.EventSystem.current.firstSelectedGameObject = canvasObject;
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(canvasObject);
        }
    }
}
