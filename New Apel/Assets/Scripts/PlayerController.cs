using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
{
    public float speed = 5f;
    public float lookSpeed = 2f;
    public Camera playerCamera;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        if (!photonView.IsMine)
        {
            if (playerCamera != null)
            {
                playerCamera.gameObject.SetActive(false);
            }
        }
        else
        {
            if (playerCamera == null)
            {
                Debug.LogError("PlayerCamera is not assigned!");
            }
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            Move();
            Look();

            if (Input.GetKeyDown(KeyCode.R))
            {
                PhotonNetwork.Destroy(gameObject);
                GameObject.Find("PlayerManager").GetComponent<PlayerManager>().canvas.SetActive(true);
            }
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, rb.velocity.y, moveVertical);
        rb.velocity = movement * speed;
    }

    void Look()
    {
        if (playerCamera == null)
        {
            Debug.LogError("PlayerCamera is not assigned!");
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        transform.Rotate(0, mouseX, 0);
        playerCamera.transform.Rotate(-mouseY, 0, 0);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(rb.position);
            stream.SendNext(rb.velocity);
        }
        else
        {
            // Network player, receive data
            rb.position = (Vector3)stream.ReceiveNext();
            rb.velocity = (Vector3)stream.ReceiveNext();
        }
    }
}
