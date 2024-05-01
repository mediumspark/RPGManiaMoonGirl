using UnityEngine;

namespace Playable.Entities
{
    public class EndSceneOnBattleExit : MonoBehaviour, IOnTriggerInteract
    {
        public bool on = false;

        private void Update()
        {
            if(!on)
                on = GameState.instance.InBattle; 
        }

        public void OnTriggerInteract()
        {
            if(on && !GameState.instance.InBattle)
                GameState.instance.LoadOverWorld(); 
        }

    }
}