using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalConversation : Conversation
{
    // checks to see if all preconditions are accessible
    // if so, it returns true
    public override bool CheckPreconditions()
    {
        if (zeroConditions)
            return true;

        if (zeroConditions == false)
        {
            UpdateToPlayerPreconditions();

            for (int i = 0; i < conditionKey.Length; i++)
            {
                if (preconditions[conditionKey[i]] == true)
                {
                    if (i == conditionKey.Length - 1)
                        return true;
                    else
                        continue;
                }
            }
        }

        return false;
    }

    public override void UpdatePreconditions()
    {
        if (zeroConditions == false)
        {
            for (int i = 0; i < conditionKey.Length; i++)
                preconditions[conditionKey[i]] = true;
        }
    }
}