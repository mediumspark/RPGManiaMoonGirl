using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; 

namespace Playable.Entities.Overworld
{
    using Playable.Entities; 
    public class BasicNPC : MonoBehaviour, IInteractable
    {
        [SerializeField]
        Flowchart Flowchart;

        public void OnInteract()
        {
            if(!Flowchart.HasExecutingBlocks())
                Flowchart.ExecuteBlock($"{name}");
        }
    }
}