using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkList : ChuongMonoSingleton<JunkList>
{
    public List<Transform> junkList;
    public int junkIndex = 1;
    public Transform junkPrefab;
    
    protected override void LoadObjects()
    {
        //Load weaponList
        foreach (Transform child in transform)
        {
            junkList.Add(child);
        }


        GetJunkByIndex(junkIndex);
    }

    //Get the weaponPrefab
    public void GetJunkByIndex(int index) => junkPrefab = junkList[junkIndex - 1];

    /*private void FixedUpdate()
    {
        GetJunkByIndex(junkIndex);
    }*/
}
