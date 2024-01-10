using UnityEngine;
using Mirror;

public class Pl_PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    private string remoteLayerName = "RemotePlayer";

    Camera sceneCamera;

    private void Start()
    {

        if (!isLocalPlayer)
        {
            DisableCOmponenets();
            AssignRemotePlayer();


        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }

        GetComponent<Pl_Player>().Setup();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string netID = GetComponent<NetworkIdentity>().netId.ToString();

        Pl_Player player = GetComponent<Pl_Player>();

        GameManager.RegisterPlayer(netID, player);
    }

    private void DisableCOmponenets()
    {
            //On vas desactiver chacun des script qui ne sont pas sur notre joueur 
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
    }

    private void AssignRemotePlayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    private void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }

        GameManager.UnregisterPlayer(transform.name);
    }
}
