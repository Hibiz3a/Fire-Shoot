using UnityEngine;
using UnityEngine.Animations;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    [Range(0f, 100f)]
    public float jumpStrength;
    public event System.Action Jumped;


    public Animator playerAnim;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;


    void Reset()
    {
        // Try to get groundCheck.
        playerAnim = GetComponent<Animator>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        playerAnim.SetBool("crouch", !groundCheck.isGrounded);
        // Jump when the Jump button is pressed and we are on the ground.
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
        {
            rigidbody.AddForce(Vector3.up * jumpStrength * 10);
            Jumped?.Invoke();
        }
    }
}
