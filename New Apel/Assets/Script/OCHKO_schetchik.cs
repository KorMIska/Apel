using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeWallText : MonoBehaviour
{
    public TextMeshPro wallText;
    public int Ochki = 0;

    void Start()
    {
        // Находим компонент TextMeshPro на стене
        wallText = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        wallText.text = Ochki.ToString();

    }
}