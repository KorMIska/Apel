using UnityEngine;
using Photon.Pun;

public class Roommaneger : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(800, 600, false);
        print("Conecting...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        print("Conected to server");

        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("test", null, null);
        print("We,re Conected");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("Join Room");
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlauerSetup>().IsLocalPlayer();
    }
}
