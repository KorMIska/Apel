using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textSynchronization : MonoBehaviour , IPunObservable
{
    public TextMeshPro wallText;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            print("Данные отправленны" + wallText.GetComponent<TextMeshPro>().text);
            stream.SendNext(wallText.GetComponent<TextMeshPro>().text);

        }
        if(stream.IsReading)
        {

            wallText.GetComponent<TextMeshPro>().text =(string)stream.ReceiveNext();
        }
    }

}
