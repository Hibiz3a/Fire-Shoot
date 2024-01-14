using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zm_ZombieStats : Ch_Character_Stats
{
    Gm_GameController gameController;

    Zm_Spawner spawner;

    [SerializeField]
    private float score = 10; 
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gm_GameController>();
        spawner = gameController.GetComponentInChildren<Zm_Spawner>();

        currentHealth = MaxHealth;
    }

    private void Update()
    {
        CheckHealth();
    }


    public override void Die()
    {
        gameController.AddScore(score);
        spawner.ennemiesKilled++;
        Destroy(gameObject);
    }
}
