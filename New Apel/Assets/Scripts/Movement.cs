
using UnityEngine;
using Photon.Pun;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PhotonTransformView))]


public class Movement : MonoBehaviourPunCallbacks
{
    GameObject cameraHolder;
    Transform tr;

    [SerializeField]
    float  sprintSpeed, walkSpeed, jumpForce, spurtForce;

    [SerializeField, Range(0, 10)] float spurtDuration, spurtCooldown, jumpCooldown, smoothTime, mouseSensitivity;

    [SerializeField] PhotonView PV;

    [SerializeField] public GameObject cameraPrefab;

    //[SerializeField] GameObject timerSpurt, timerJump;

    private bool isSpurtNow = false;
    private float sprutTimer, jumpTimer;

    [SerializeField] Rigidbody rb;
    //Animator animator;
    float verticalLookRotation;
    bool grounded = true;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;
    private PlayerManager playerManager;

    public void Awake()
    {
        // Проверка на наличие PhotonView и уничтожение ненужных компонентов для других игроков
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            Destroy(this);
            return;
        }

        // Инициализация камеры, если это наш игрок
        if (PV.IsMine && cameraHolder == null)
        {
            cameraHolder = Instantiate(cameraPrefab);
            Transform cameraPoint = transform.Find("CameraPoint");

            if (cameraPoint == null)
            {
                Debug.LogError("CameraPoint не найден!");
                return;
            }

            cameraHolder.transform.SetParent(cameraPoint);
            cameraHolder.transform.localPosition = Vector3.zero;
            cameraHolder.transform.localRotation = Quaternion.identity;
        }

        // Проверка на наличие InstantiationData и получение PlayerManager
        if (PV.InstantiationData != null && PV.InstantiationData.Length > 0)
        {
            int playerManagerID = (int)PV.InstantiationData[0];
            Debug.Log("Received PlayerManager ID: " + playerManagerID);
            PhotonView playerManagerPV = PhotonView.Find(playerManagerID);

            if (playerManagerPV != null)
            {
                Debug.Log("PlayerManager PhotonView found!");
                playerManager = playerManagerPV.GetComponent<PlayerManager>();

                if (playerManager == null)
                {
                    Debug.LogError("PlayerManager компонент не найден!");
                }
            }
            else
            {
                Debug.LogError("PlayerManager PhotonView not found!");
            }
        }
        else
        {
            Debug.LogError("InstantiationData is null or empty!");
        }

        Cursor.lockState = CursorLockMode.None;
        tr = gameObject.GetComponent<Transform>();
    }




    public void Update()
    {
        if (!PV.IsMine) return;

        Look();
        CalculationOfMove();
        //Rise();
        if (Input.GetKeyDown(KeyCode.Q) && sprutTimer <= 0)
        {
            isSpurtNow = true;
            sprutTimer = spurtDuration;
        }
        if (sprutTimer <= 0 && jumpTimer <= 0)
        {
            Jump();

        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            playerManager.Die();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Launcher.Instance.LeaveRoom();
            PhotonNetwork.LoadLevel(0);
        }



    }

    //private void Rise()
    //{
    //    if (Input.GetKeyDown(KeyCode.Tab))
    //    {

    //        animator.ResetTrigger("On your knees");
    //        animator.ResetTrigger("Rise");

    //        var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

    //        animator.SetTrigger(!animatorStateInfo.IsName("Kneeling Idle") ? "On your knees" : "Rise");

    //    }
    //}

    void Look()
    {
        tr.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void CalculationOfMove()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(tr.up * jumpForce);
            jumpTimer = jumpCooldown;
        }
    }

    void FixedUpdate()
    {
        if (!PV.IsMine) return;

        if (tr.position.y < -100 || tr.position.y > 1000)
        {
            playerManager.Die();
        }

        if (isSpurtNow)
        {
            isSpurtNow = false;
            rb.AddForce(tr.forward * spurtForce);
        }

        sprutTimer -= sprutTimer > 0 ? Time.fixedDeltaTime : 0;
        jumpTimer -= jumpTimer > 0 ? Time.fixedDeltaTime : 0;



        if (sprutTimer <= 0)
        {
            moveAmount.y = rb.velocity.y;
            rb.velocity = transform.TransformDirection(moveAmount);
            //animator.SetFloat("speed", moveAmount.magnitude);
        }
    }
}
