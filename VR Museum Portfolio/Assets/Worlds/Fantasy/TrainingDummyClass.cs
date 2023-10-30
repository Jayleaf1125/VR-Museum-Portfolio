using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummyClass : MonoBehaviour
{
    public GameObject trainingDummy;
    //public Transform spawnPoint;
    public int currentHealth = 100;
    public int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    string otherTag = collision.gameObject.tag;

    //    if (otherTag == "Sword")
    //    {
    //        SwordClass sword = collision.
    //        // this.currentHealth -=
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.tag;

        if(otherTag == "Sword")
        {
            SwordClass sword = other.GetComponent<SwordClass>();
            currentHealth -= sword.damage;

            if(currentHealth < 0)
            {
                Debug.Log("respawned");
                currentHealth = maxHealth;
            }
            else
            {
            Debug.Log(string.Format("Training Dummy: {0} / {1} health", currentHealth, maxHealth));
            }
        }
    }
}
