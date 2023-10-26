using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTurnType : MonoBehaviour
{
    public ActionBasedContinuousTurnProvider continuousTurn;
    public ActionBasedSnapTurnProvider snapTurn;

    public void SetTypeFromIndex(int index)
    {
        switch(index)
        {
            case 0:
                snapTurn.enabled = false; 
                continuousTurn.enabled = true;
                break;
            case 1:
                snapTurn.enabled = true;
                continuousTurn.enabled = false;
                break;
        }
    }
}
