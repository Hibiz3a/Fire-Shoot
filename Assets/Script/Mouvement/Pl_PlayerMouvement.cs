using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Pl_PlayerMotor))]
public class Pl_PlayerMouvement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    private float speedBase;
    [SerializeField]
    private float speedSprint = 6f;

    [SerializeField]
    [Range(0f, 100f)]
    private float mouseSensitivityX = 3f;

    [SerializeField]
    [Range(0f, 100f)]
    private float mouseSensitivityY = 3f;


    private Pl_PlayerMotor playerMotor;

    bool sprintInput = false;

    private void Start()
    {
        speedBase = speed;
        playerMotor = GetComponent<Pl_PlayerMotor>();
    }

    private void Update()
    {
        MouvementPlayer();
        RotatePlayer();
    }
    private void MouvementPlayer()
    {
        //player mouvement 
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * yMov;

        Vector3 velocity = (moveVertical + moveHorizontal).normalized * speed;



        playerMotor.Move(velocity);

    }
    private void RotatePlayer()
    {

        // rotation personnage
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivityX;

        playerMotor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * mouseSensitivityY;

        playerMotor.RotateCamera(cameraRotation);
    }

    public void GetInput(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            speed = speedSprint;
        }
        else
        {
            speed = speedBase;
        }
    }
}
