using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.Demo.SlotRacer;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour, IOnEventCallback
{
    public int HP;
    public int MaxHP = 100;

    public string Name;


    public void Damage(int damage)
    {
        HP -= damage;

        RaiseEventOptions options = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        SendOptions sendOptions = new SendOptions { Reliability = true };


        print("EVENTStart");

        PhotonNetwork.RaiseEvent(2, HP, options, sendOptions);

    }

    private void Update()
    {
        if (HP <= 0)
        {
            Dether();
        }
    }

    public void Dether()
    {
        HP = MaxHP;
        transform.position = GameObject.FindWithTag("SpawnPoin").transform.position;
    }

    public void OnEvent(EventData photonEvent)
    {
        switch (photonEvent.Code)
        {
            case 2:
                {
                    HP = (int)photonEvent.CustomData;
                    break;
                }
        }
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }



}
