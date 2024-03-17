using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventTextSyn : MonoBehaviour
{
    public TextMeshPro wallText;

    public void OnEvent(EventData photonEvent)
    {
        switch(photonEvent.Code)
        {
            case 1: 
            {
                    object[] data = (object[])photonEvent.CustomData;
                    string text = (string)data[0];
                    wallText.text = text;
                    print(text);
                    break;
            }
        }
        
    }

}