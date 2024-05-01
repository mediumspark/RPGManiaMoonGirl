using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playable.Entities
{
    public class Treasure : MonoBehaviour, IInteractable
    {
        //Reward
        public virtual void OnInteract()
        {
            gameObject.SetActive(false);
        }
    }
}