using UnityEngine;
using UnityEngine.AI;

public class zm_zombie_action : MonoBehaviour
{

    [SerializeField]
    private float damage;

    private float lastAttackTime = 0f;
    private float AttackCooldown = 1f;

    private NavMeshAgent agent;

    [SerializeField]
    private float stopDistance;

    private float distanceToPlayer;
    public Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Assurez-vous que le joueur est assigné
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Assurez-vous que le NavMeshAgent est présent sur le zombie
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found on zombie.");
        }
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (player != null)
        {
            // Définir la destination du zombie sur la position actuelle du joueur
            agent.SetDestination(player.position);
            if (distanceToPlayer < stopDistance)
            {
                if (Time.time - lastAttackTime >= AttackCooldown)
                {
                    lastAttackTime = Time.time;
                    player.GetComponent<Ch_Character_Stats>().TakeDamage(damage);
                    player.GetComponent<Ch_Character_Stats>().CheckHealth();
                }
            }

        }
    }
}
