using Playable.Entities.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playable.Entities
{
    public class Door : MonoBehaviour, IOnTriggerInteract, IInteractable
    {
        public bool Exit;
        public string LevelName;

        public void OnInteract()
        {
            if(!Exit)
                GameState.instance.LoadLevel(LevelName);
        }

        public void OnTriggerInteract()
        {
            if (Exit)
                GameState.instance.LoadOverWorld();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
        }
#endif
    }
}