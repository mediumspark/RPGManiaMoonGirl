using UnityEngine;

namespace Playable.Entities
{
    public class Page : Treasure
    {
        [SerializeField]
        int PageNumber;

        public int Number => PageNumber;

        public override void OnInteract()
        {
            //Add Page to PagesUnlocked

            base.OnInteract();
        }
    }
}