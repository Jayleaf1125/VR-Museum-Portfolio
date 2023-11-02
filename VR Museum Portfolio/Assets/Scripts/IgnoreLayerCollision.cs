using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayerCollision : MonoBehaviour
{
    public int layer1;
    public int layer2;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(layer1, layer2);
    }
}
