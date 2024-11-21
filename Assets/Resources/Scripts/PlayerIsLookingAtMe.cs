using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerIsLookingAtMe (A)", menuName = "ScriptableObjects/Actions/PlayerIsLookingAtMe")]
public class PlayerIsLookingAtMe : Action
{
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<TargetReference>().target;
        WhatAmILooking whatAmILooking = target.GetComponentInChildren<WhatAmILooking>();
        List<GameObject> targetViewList = whatAmILooking.viewList;

        foreach(GameObject objectInVision in targetViewList)
        {
            if(owner == objectInVision)
            {
                return true;
            }

        }
        return false;
    }
}
