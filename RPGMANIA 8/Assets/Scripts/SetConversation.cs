using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Playable;

[CommandInfo("Player", "Convesation Based Movement", "Turning ConvesationOn turns players movement on/off")]
public class SetConversation : Command
{
    public bool ConversationOn; 

    public override void OnEnter()
    {
        GameState.instance.InCutscene = ConversationOn; 
        Continue();
    }
}
