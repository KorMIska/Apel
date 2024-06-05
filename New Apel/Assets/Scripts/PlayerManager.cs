using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Random = UnityEngine.Random;
using System.IO;


public class PlayerManager : MonoBehaviourPunCallbacks
{

    [SerializeField] public GameObject canvas;
    [SerializeField] public GameObject canvasCameraRender;

    private PhotonView PV;
    private GameObject _character;

    private int kills;
    private int deaths;

    void Awake()
    {

        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            SetActiveChoiseMenu(true);
        }
        else
        {
            SetActiveChoiseMenu(false);
        }
    }

    public void SetCharacter(GameObject character)
    {
        _character = character;
        CreateController();
    }

    private void SetActiveChoiseMenu(bool f)
    {
        canvasCameraRender.SetActive(f);
        canvas.SetActive(f);
    }

    void CreateController()
    {
        if (!PV.IsMine)
            return;

        Transform spawnpoint = new GameObject().transform;
        try
        {
            spawnpoint = SpawnManager.Instance.GetSpawnpoint();
        }
        catch
        {
            spawnpoint.position = new Vector3(Random.Range(0f, 100f), 5f, Random.Range(0f, 100f));
            spawnpoint.rotation = Quaternion.identity;
            Debug.Log("Ќазначены случайные координаты дл€ точки спавна");
        }

        // Instantiate character on the network
        _character = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", _character.name), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
    }


    public void Die()
    {
        PhotonNetwork.Destroy(_character);

        SetActiveChoiseMenu(true);

        deaths++;

        Hashtable hash = new Hashtable();
        hash.Add("deaths", deaths);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public void GetKill()
    {
        PV.RPC(nameof(RPC_GetKill), PV.Owner);
    }

    [PunRPC]
    void RPC_GetKill()
    {
        kills++;

        Hashtable hash = new Hashtable();
        hash.Add("kills", kills);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    //public static PlayerManager Find(Player player)
    //{
    //    return FindObjectsOfType<PlayerManager>().SingleOrDefault(x => x.PV.Owner == player);
    //}
}