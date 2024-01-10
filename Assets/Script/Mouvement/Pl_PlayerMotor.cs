using UnityEngine;
using UnityEngine.Animations;

[RequireComponent (typeof(Rigidbody))]
public class Pl_PlayerMotor : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 rotation;
    private float rotationCameraX = 0f;
    private float currentCameraRotationX = -90f;

    [SerializeField] private float cameraAngle = 120f;
    

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }
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
        //on calcule la rotation de la camera 
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        currentCameraRotationX -= rotationCameraX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraAngle, -30);

        //on applique la rotation de la camera
        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 90f, 0f);
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(float _rotationCameraX)
    {
        rotationCameraX = _rotationCameraX;
    }
}
