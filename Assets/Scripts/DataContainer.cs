using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public int coins;

    public List<bool> stageCompletion;

    public void StageComplete(int i) //counter for number of player wins
    {
        stageCompletion[i] = true;
    }

}
