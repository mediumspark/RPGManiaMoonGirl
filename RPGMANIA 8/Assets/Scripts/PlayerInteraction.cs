using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

namespace Playable.Entities.Player
{
    using TMPro;
    using UI;
    using UnityEngine.UI; 

    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]
        LayerMask InteractionLayers;
        [SerializeField]
        float InteractionRange = 1.0f;
        [SerializeField]
        SpriteRenderer Indicator;
        private IInteractable interactable;
        private PlayerInput _input;
        public TextMeshProUGUI PickUpObjectText; 

        private void Awake()
        {
            _input = new PlayerInput();
            _input.Misc.Select.performed += OnSelect;
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void OnSelect(InputAction.CallbackContext obj)
        {
            if (interactable != null)
            {
                switch (interactable)
                {
                    case var x when x is Page:
                        var y = x as Page;
                        PickUpObjectText.text = $"Page {y.Number}";
                        break;
                }

                StartCoroutine(PlayText(PickUpObjectText));
            }
            interactable?.OnInteract();
        }

        private IEnumerator PlayText(TextMeshProUGUI Text)
        {
            PickUpObjectText.gameObject.SetActive(true); 
            yield return new WaitForSecondsRealtime(0.5f);
            PickUpObjectText.gameObject.SetActive(false);
        }


        private void FixedUpdate()
        {
            interactable = null;

            Collider[] col = Physics.OverlapSphere(transform.position, InteractionRange, InteractionLayers);

            foreach(var Collider in col)
            {
                switch (col[0].tag)
                {
                    case "Boss":
                    case "Enemy":
                    case var x when x == "Door" && Collider.GetComponent<Door>().Exit:
                            Collider.GetComponent<IOnTriggerInteract>().OnTriggerInteract(); 
                        break;

                    case "NPC":
                        interactable = Collider.GetComponentInParent<IInteractable>();
                        break; 

                    case "Threshhold":
                    case "Chest":
                    case var x when x == "Door" && !Collider.GetComponent<Door>().Exit:
                    case "Switch":
                        interactable = Collider.GetComponent<IInteractable>();
                        break;

                    case "Instakill":
                        break;

                }
            }

            Indicator.gameObject.SetActive(interactable != null);
        }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, InteractionRange);
        }
#endif
    }
}
