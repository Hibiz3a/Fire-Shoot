using UnityEngine;
using UnityEngine.Animations;

[RequireComponent (typeof(Rigidbody))]
public class Pl_PlayerMotor : MonoBehaviour
{
    public Vector3 velocity;
    private Rigidbody rb;

    [SerializeField] Animator walk;

    private void Start()
    {
        walk = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    private void FixedUpdate()
    {
        performMouvement();

        walk.SetFloat("walk", Input.GetAxisRaw("Vertical"));
        walk.SetFloat("side", Input.GetAxisRaw("Horizontal"));
    }

    private void performMouvement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}
