using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Updat : MonoBehaviour
{
    public Player player; // Предположим, что у вас есть компонент Player на другом игровом объекте
    public Text text; // Предположим, что у вас есть компонент Text на другом игровом объекте

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>(); // Используйте FindObjectOfType для поиска объекта с компонентом Player в сцене
        text = GetComponent<Text>(); // Текст должен быть присвоен в инспекторе или найден программно, если он находится на другом объекте
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && text != null) // Убедитесь, что player и text не являются null перед обращением к ним
        {
            text.text = player.HP.ToString(); // Обновление текста
        }
         else
        {
            print("Noy");
        }
    }
}