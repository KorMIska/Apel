using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeWallText : MonoBehaviour, IOnEventCallback
{
    public TextMeshPro wallText;
    int score = 0;

    void Start()
    {
        wallText = GetComponent<TextMeshPro>();
    }


    public void AddScore()
    {
        score++;
        wallText.text = score.ToString();

        string message = score.ToString();
        object[] data = new object[] { message };
        RaiseEventOptions options = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        SendOptions sendOptions = new SendOptions { Reliability = true };


        print("EVENTStart");

        PhotonNetwork.RaiseEvent(1, data, options,sendOptions);

    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnEvent(EventData photonEvent)
    {
        switch (photonEvent.Code)
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