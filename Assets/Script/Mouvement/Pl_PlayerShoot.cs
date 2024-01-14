using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class Pl_PlayerShoot : MonoBehaviour
{
    float nextTimeToFire;
    [SerializeField]
    private float range;

    [SerializeField]
    private float fireRate;   
    [SerializeField]
    private float damage;

    [SerializeField]

    Camera mainCam;

    public InputManager inputManager;

    private void Start()
    {
        inputManager.inputMaster.Movement.fire.started += _ => shoot();
        mainCam = Camera.main;
    }


    private void shoot()
    {

        Vector3 rayOrigin = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, mainCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Zombie"))
            {
                Zm_ZombieStats zombieStats = hit.transform.GetComponent<Zm_ZombieStats>();
                Debug.Log("Zombie is Hit");
                zombieStats.TakeDamage(damage);
            }
        }
    }
}
