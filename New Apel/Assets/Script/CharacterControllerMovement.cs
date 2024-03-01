using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMovement : BaseCharacterMovement
{
    private CharacterController characterController;
    private Animator animator;
    private float verticalVelocity = 0f;

    public float JumpS = 10f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent <Animator>();
    }

    private new void Update()
    {
        base.Update();

        ApplyGravity();
        Jamp();

        // ������������ �� �����
        characterController.Move((movementVector * movementSpeed + new Vector3(0, verticalVelocity, 0)) * Time.deltaTime);



        // ��������� �������� �������� ������������
        if (movementVector.magnitude > 0.001f)
            animator.SetFloat("Speed", 6);
        else
            animator.SetFloat("Speed", 0);



        print(movementVector);
    }

    private void Jamp()
    {
        if (Input.GetButton("Jump") & characterController.isGrounded)
        {
            verticalVelocity = JumpS;
        }
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            // ��������� ����������
            verticalVelocity -= 25f * Time.deltaTime; // ����������� �������� ����������, ��������������� ����� �����
        }
        else
        {
            // ���� �������� �� �����, ���������� ������������ ��������
            verticalVelocity = 0f;
        }
    }
}