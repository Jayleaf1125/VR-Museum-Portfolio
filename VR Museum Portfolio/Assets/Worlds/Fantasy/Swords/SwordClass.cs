using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordClass : MonoBehaviour
{
    public GameObject sword;
    public new string name = "Basic Sword";
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string otherTag = collision.gameObject.tag;

        if (otherTag == "TrainingDummy")
        {
            Debug.Log(string.Format("{0} has dealt {1} damage", name, damage));
        }
    }
}
