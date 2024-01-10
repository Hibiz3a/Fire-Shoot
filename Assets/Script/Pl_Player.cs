using UnityEngine;
using Mirror;
using System.Collections;

public class Pl_Player : NetworkBehaviour
{


    /*proprieter qui permet de lire et d'ecrire sans utiliser de verification sur la variable _isDead, 
     * Acsesor (Get permet de recuperer la valuer de _isDead, set permet d'ecrire sur la variables _isDead), 
     * protected = seul la class faite peut y acceder*/
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }



    #region Variables SerializeField
    [SerializeField]
    private float maxHealth = 100f;

    [SerializeField]
    private Behaviour[] disableOnDeath;
    private bool[] wasEnabledOnStart;
    
    
    #endregion

    #region SyncVar

    [SyncVar]
    private float currentHealth;


    [SyncVar]
    private bool _isDead = false;

    #endregion

    public void Setup()
    {
        wasEnabledOnStart = new bool[disableOnDeath.Length];
        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            wasEnabledOnStart[i] = disableOnDeath[i].enabled;
        }

        SetDefault();
    }

    private void SetDefault()
    {
        isDead = false;
        for(int i = 0;i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = wasEnabledOnStart[i];
        }
        currentHealth = maxHealth;

        Collider col = GetComponent<Collider>();
        if(col != null)
        {
            col.enabled = true;
        }
    }


    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(GameManager.instance.matchSettings.respawnTimer);
        SetDefault();
        Transform spawnPoint = NetworkManager.singleton.GetStartPosition();
        transform.position =  spawnPoint.position;
        transform.rotation = spawnPoint.rotation;
    }

    private void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            RpcTakeDamage(999);
        }
    }


    [ClientRpc]
    public void RpcTakeDamage(float damage)
    {
        if(isDead)
        {
            return;
        }
        currentHealth -= damage;
        Debug.Log(transform.name + "a maintenant : " + currentHealth + "points de vie");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        for(int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = false;
        }

        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }
        Debug.Log(transform.name + " est mort.");

        StartCoroutine(Respawn());
    }
}
