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

    [Client]
    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask) )
        {
            if(hit.collider.CompareTag("Player"))
            CmdPlayerShoot(hit.collider.name, weapon.damage);
        }
    }

    public void GetFireAction(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Shoot();
        }
    }

    [Command]
    private void CmdPlayerShoot(string playerID, float damage)
    {
        Debug.Log(playerID + " a ete toucher");

        Pl_Player player = GameManager.GetPLayer(playerID);
        player.RpcTakeDamage(damage);
    }

}
