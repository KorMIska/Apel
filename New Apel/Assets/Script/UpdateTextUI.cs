using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Updat : MonoBehaviour
{
    public Player player; // �����������, ��� � ��� ���� ��������� Player �� ������ ������� �������
    public Text text; // �����������, ��� � ��� ���� ��������� Text �� ������ ������� �������

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>(); // ����������� FindObjectOfType ��� ������ ������� � ����������� Player � �����
        text = GetComponent<Text>(); // ����� ������ ���� �������� � ���������� ��� ������ ����������, ���� �� ��������� �� ������ �������
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && text != null) // ���������, ��� player � text �� �������� null ����� ���������� � ���
        {
            text.text = player.HP.ToString(); // ���������� ������
        }
         else
        {
            print("Noy");
        }
    }
}