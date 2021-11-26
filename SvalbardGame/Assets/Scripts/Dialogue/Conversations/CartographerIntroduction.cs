using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartographerIntroduction : Conversation
{
    public override bool CheckPreconditions()
    {
        UpdatePreconditions();
        if (preconditions["NeedsAxe"] == true)
            return true;
        else
            return false;
    }
}