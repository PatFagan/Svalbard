using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartographerIntroduction : Conversation
{
    public override bool CheckPreconditions()
    {
        UpdateToPlayerPreconditions();
        if (preconditions["HasMetCartographer"] == false)
            return true;
        else
            return false;
    }

    public override void UpdatePreconditions()
    {
        preconditions["HasMetCartographer"] = true;
    }
}