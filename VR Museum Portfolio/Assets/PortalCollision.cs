using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public SceneTransitionManager sceneTransitionManager;
    public int sceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Portal")
        {
            sceneTransitionManager.GoToSceneAsync(sceneIndex);
        }
    }
}
