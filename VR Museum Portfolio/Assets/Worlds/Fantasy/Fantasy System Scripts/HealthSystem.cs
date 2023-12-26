using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    // private int? shield = null;
    private Renderer renderer;
    private Material originalMat;
    public Material newMat;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        if( renderer != null )
        {
            originalMat = renderer.material;
            Debug.Log("Renderer Exist");
        } else
        {
            Debug.Log("No renderer exist");
        }
    }

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

                currentHealth = updatedHealth;

                break;
            case "heal":
                int updatedHealth2 = currentHealth + num;

                if (updatedHealth2 > maxHealth)
                {
                    currentHealth = maxHealth;
                    return;
                }

                currentHealth = updatedHealth2;
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
        StartCoroutine(ChangeMaterialForDuration(2f));
        currentHealth = maxHealth;
    }

    // Changing Material
    IEnumerator ChangeMaterialForDuration(float duration)
    {
        ChangeMaterial(newMat);
        yield return new WaitForSeconds(duration);
        ChangeMaterial(originalMat);
    }

    void ChangeMaterial(Material material)
    {
        renderer.material = material;
    }
}
