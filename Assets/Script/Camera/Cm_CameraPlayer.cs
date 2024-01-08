using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cm_CameraPlayer : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity;
    float cameraVerticalRotation = 0f;

    bool lockCursor = true;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        //Vertical Rotation Camera Player

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        //Horizontal Rotation Camera Player

        player.Rotate(Vector3.up * inputX);

    }
}
