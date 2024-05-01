using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playable.Entities.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        public Animator Ani;
        public PlayerMovement Movement;
        public SpriteRenderer Sprite; 

        public enum AnimatorStates { Idle, Running }

        public AnimatorStates State;

        private void Update()
        {
            switch (State)
            {
                case AnimatorStates.Idle:
                    Ani.SetBool("Running", false);
                    break;
                case AnimatorStates.Running:
                    Ani.SetBool("Running", true);
                    break;
            }

            Sprite.flipX = Movement.Right; 
        }
    }
}