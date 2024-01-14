using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pl_Player_Stats : Ch_Character_Stats
{

    Pl_Player_Ui playerUI;
    private void Start()
    {
        playerUI = GetComponent<Pl_Player_Ui>();
        MaxHealth = 100;
        currentHealth = MaxHealth;
        SetStats();
    }

    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }

    public void SetStats()
    {
        playerUI.healthammount.text = currentHealth.ToString();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        SetStats();
    }
}
