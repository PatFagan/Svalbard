using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartographerMap : Conversation
{
    public override bool CheckPreconditions()
    {
        UpdateToPlayerPreconditions();
        return true; // no preconditions
    }

    public override void UpdatePreconditions()
    {
        //preconditions["HasMetCartographer"] = true;
    }
}