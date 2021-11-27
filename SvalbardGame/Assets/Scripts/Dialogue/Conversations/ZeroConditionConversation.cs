using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroConditionConversation : Conversation
{
    public override bool CheckPreconditions()
    {
        return true;
    }

    public override void UpdatePreconditions()
    {
        //preconditions[conditionKey] = true;
    }
}