using UnityEngine;
using Mirror;
using UnityEngine.InputSystem;

public class Pl_PlayerShoot : NetworkBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    public Pl_PlayerWeapon weapon;


    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("Pas de camera referencer sur le Pl_Player Shoot");
            this.enabled = false;
        }   
    }

    private void Update()
    {
        
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask) )
        {
            Debug.Log("Objet toucher : " + hit.collider.name);
        }
    }

    public void GetFireAction(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Shoot();
        }
    }

}
