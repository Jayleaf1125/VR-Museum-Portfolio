using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    public int level;
    public int currentExpAmount;
    public int maxExp;
    private HealthSystem healthbar;
    private ManaSystem manabar;
    // In the future, lets make these proporities private as we dont want people to easily interfere

    public void Awake()
    {
        healthbar = GetComponent<HealthSystem>();
        manabar = GetComponent<ManaSystem>();
    }

    public void GainExpericePoints()
    {
        // Modify this function to get experince points based on the enemies you fought and their level
        int expGained = Random.Range(5, 25);

        Debug.Log(string.Format("You have gained {0} experience points", expGained));

        if (currentExpAmount < maxExp && (expGained + currentExpAmount) < maxExp)
        {
            currentExpAmount += expGained;
            return;
        }

        LevelUp();
    }

    private void LevelUp()
    {
        // Adding leftover exp
        int leftOverExp = Mathf.Abs(currentExpAmount - maxExp);
        level++;
        currentExpAmount = 0;
        currentExpAmount += leftOverExp;
        maxExp += 25;

        // Increasing Stats
        int maxHealthRandomIncrease = Random.Range(1, 10);
        int maxManaRandomIncrease = Random.Range(1, 10);

        healthbar.UpgradeHealth(maxHealthRandomIncrease);
        healthbar.UpdateHealth(healthbar.maxHealth, "heal");

        manabar.UpgradeMana(maxManaRandomIncrease);
        manabar.UpdateMana(manabar.maxMana, "regan");

        // Display Level Up
        print(string.Format("You Leveled Up! You are now Level {0}", level));
        print(string.Format("Health increased by {0}", maxHealthRandomIncrease));
        print(string.Format("Mana increased by {0}", maxManaRandomIncrease));
    }
}
