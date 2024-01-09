using UnityEngine;
using UnityEngine.Animations;

[RequireComponent (typeof(Rigidbody))]
public class Pl_PlayerMotor : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 rotationCamera;

    [SerializeField]
    private Camera cam;


    private Rigidbody rb;

    [SerializeField] Animator walk;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        performRotation();

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

    private void performRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        cam.transform.Rotate(-rotationCamera);
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _rotationCamera)
    {
        rotationCamera = _rotationCamera;
    }
}
