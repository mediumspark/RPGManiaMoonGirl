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


    public class Page : Treasure
    {
        [SerializeField]
        int PageNumber;

        public override void OnInteract()
        {
            //Add Page to PagesUnlocked

            base.OnInteract();
        }
    }
}