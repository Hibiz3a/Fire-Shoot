using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Pl_PlayerMotor))]
public class Pl_PlayerMouvement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Pl_PlayerMotor playerMotor;

    private void Start()
    {
        playerMotor = GetComponent<Pl_PlayerMotor>();
    }

    private void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * yMov;

        Vector3 velocity = (moveVertical + moveHorizontal).normalized * speed;

        playerMotor.Move(velocity);
    }
}
