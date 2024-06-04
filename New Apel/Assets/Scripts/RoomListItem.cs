using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public Launcher luc;
    public RoomInfo info;


    public string roomName;

    public void SetUp(RoomInfo _info)
    {
        info = _info;
        text.text = _info.Name;
        roomName = _info.Name;
        print(_info.Name);
    }

    public void Click()
    {
        try {
            Launcher.Instance.JoinRoom(info);
        }
        catch 
        {
            print("не найден лаунчер");
            if (Launcher.Instance == null)
            {
                print("mas");
            }
        }
    }
}
