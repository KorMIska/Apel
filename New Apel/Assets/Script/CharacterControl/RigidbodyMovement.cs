using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovement : BaseCharacterMovement
{
    private new Rigidbody rigidbody;
    private Animator animator;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + movementVector * movementSpeed * Time.fixedDeltaTime);

        // ”становка анимации скорости передвижени€
        if (movementVector.magnitude > 0.001f)
            animator.SetFloat("Speed", 6);
        else
            animator.SetFloat("Speed", 0);

        print(movementVector);
    }
}
