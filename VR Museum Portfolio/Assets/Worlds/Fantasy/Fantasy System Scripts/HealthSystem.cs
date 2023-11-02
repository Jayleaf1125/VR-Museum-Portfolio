using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private int? shield = null;

    public void UpdateHealth(int num, string statement)
    {
        switch(statement)
        {
            case "damage":
                int updatedHealth = currentHealth - num;

                if(updatedHealth < 0)
                {
                    onDeathHealthReset();
                    return;
                }

                currentHealth -= num;

                break;
            case "heal":
                int updatedHealth2 = currentHealth + num;

                if (updatedHealth2 > maxHealth)
                {
                    currentHealth = maxHealth;
                    return;
                }

                currentHealth += num;
                break;
        }
    }

    public void UpgradeHealth(int num)
    {
        maxHealth += num;
    }

    private void onDeathHealthReset()
    {
        Debug.Log("You died, get your ass up");
        currentHealth = maxHealth;
        Destroy(gameObject);
    }
}
