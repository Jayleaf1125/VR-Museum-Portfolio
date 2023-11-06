using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(ManaSystem))]
[RequireComponent(typeof(ExperienceSystem))]
public class PlayerSystem: MonoBehaviour
{
    public string playerName;
    private HealthSystem healthBar;
    private ManaSystem manaBar;
    private ExperienceSystem expBar;

    public void Awake()
    {
        healthBar = GetComponent<HealthSystem>();
        manaBar = GetComponent<ManaSystem>();
        expBar = GetComponent<ExperienceSystem>();
    }
}
