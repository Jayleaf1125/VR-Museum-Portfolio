using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public int currentMana;
    public int maxMana;
    // private int? overdrive = null; // To allow the player to tempoaray increase their max mana

    public void UpdateMana(int num, string statement)
    {
        switch(statement)
        {
            case "usage":
                int updatedMana = currentMana - num;

                if (updatedMana < 0) { 
                    currentMana = 0;
                    return;
                }

                currentMana = updatedMana;
                break;
            case "regan":
                int updatedMana2 = currentMana - num;

                if (updatedMana2 < 0)
                {
                    currentMana = 0;
                    return;
                }

                currentMana = updatedMana2;
                break;
        }
    }

    public void UpgradeMana(int num)
    {
        maxMana+= num;
    }
}
