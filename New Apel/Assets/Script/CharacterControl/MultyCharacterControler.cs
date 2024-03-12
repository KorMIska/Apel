using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class MultyCharacterControler : MonoBehaviour
{
    PhotonView photonView;

    private CharacterController characterController;
    private Animator animator;
    private float verticalVelocity = 0f;

    public float JumpS = 10f;
    public float movementSpeed = 20;
    protected Vector3 movementVector;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;

        movementVector = (transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward).normalized;

        // Установка анимации скорости передвижения
        if (movementVector.magnitude > 0.001f)
            animator.SetFloat("Speed", 6);
        else
            animator.SetFloat("Speed", 0);


        if (!characterController.isGrounded)
        {
            // Применяем гравитацию
            verticalVelocity -= 25f * Time.deltaTime; // Используйте значение гравитации, соответствующее вашей сцене
        }
        else
        {
            // Если персонаж на земле, сбрасываем вертикальную скорость
            verticalVelocity = 0f;
        }

        if (Input.GetButton("Jump") & characterController.isGrounded)
        {
            verticalVelocity = JumpS;
        }

        // Передвижение по земле
        characterController.Move((movementVector * movementSpeed + new Vector3(0, verticalVelocity, 0)) * Time.deltaTime);




    }
}
