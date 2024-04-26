using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playable.Entities.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : FallingEntity
    {
        PlayerInput input;
        Vector3 MovementVector;

        [SerializeField]
        float JumpForce;
        [SerializeField]
        float JumpTime;

        [SerializeField]
        float Speed;

        private void Awake()
        {
            Controller = GetComponent<CharacterController>();

            input = new PlayerInput();

            input.Movement.Move.performed += Move_performed;
            input.Movement.Move.canceled += Move_canceled;
            input.Movement.Jump.performed += Jump_performed;
        }

        private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            MovementVector = Vector3.zero;
        }

        private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Vector3 MovementForce = obj.ReadValue<Vector2>();

            MovementVector = new Vector3(MovementForce.x,
                0, MovementForce.y);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (GameState.instance.InBattle || GameState.instance.InCutscene)
            {
                return; 
            }

            Controller.Move(MovementVector * Time.deltaTime * Speed);
        }
        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (Grounded)
            {
                StartCoroutine(JumpAction(JumpTime));
            }
        }

        IEnumerator JumpAction(float time)
        {
            //Debug.Log("Jump Started");
            GravityForce *= -JumpForce;
            yield return new WaitForSecondsRealtime(time);
            GravityReset();
            //Debug.Log("Jump Ended");
        }

        public void Teleport(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
        public void Enable()
        {
            input.Enable();
        }

        public void Disable()
        {
            input.Disable();
        }

        private void OnEnable()
        {
            input.Enable();
        }
        private void OnDisable()
        {
            input.Disable();
        }
    }
}