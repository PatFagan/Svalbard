using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetingYigs : Conversation
{
    public override bool CheckPreconditions()
    {
        UpdateToPlayerPreconditions();
        if (preconditions[conditionKey] == false)
            return true;
        else
            return false;
    }

    public override void UpdatePreconditions()
    {
        preconditions[conditionKey] = true;
    }
}