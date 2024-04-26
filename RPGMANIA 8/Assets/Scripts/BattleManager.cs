using Playable;
using Playable.Entities;
using Stats;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using TMPro;

namespace Playable.Entities.Battle
{
    [System.Serializable]
    public struct Loot
    {
        public int EXP; 
        //ITEMS & MONEY
    }

    public class BattleManager : MonoBehaviour
    {
        public static BattleManager instance;
        public List<EntityBase> SpawnedEnemies = new List<EntityBase>();
        [SerializeField]
        private List<EntityBase> TurnOrder = new List<EntityBase>();
        [SerializeField]
        GameObject WinCanvas;
        [SerializeField]
        TextMeshProUGUI LootText; 
        [SerializeField]
        List<Loot> CollectedLoot; 
        public BattleZone zone;
        public EntityBase CurrentActor; 
        public EntityBase SelectedUnit;
        PlayerInput input;

        public void RemoveFromTurnOrder(EntityBase Unit)
        {
            TurnOrder.Remove(Unit);
            SpawnedEnemies.Remove(Unit);

            if (SpawnedEnemies.Count == 0)
            {
                Victory(); 
                GameState.instance.InBattle = false;
            }
        }

        public void AddLoot(Loot loot)
        {
            CollectedLoot.Add(loot); 
        }

        private void Victory()
        {
            int TotalExp = 0; 

            foreach(var loot in CollectedLoot)
            {
                PlayerRef.instance.Stats.Experience += loot.EXP; 
                TotalExp += loot.EXP;
            }

            LootText.text = $"EXP : {TotalExp}";
            WinCanvas.SetActive(true);
            WinCanvas.GetComponent<Animator>().Play("Win");

        }


        private void Awake()
        {
            instance = this;
            zone = FindObjectOfType<BattleZone>();
            input = new PlayerInput();
            input.Misc.Select.performed += OnClick;
        }
        private void OnEnable()
        {
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }

        public void OnClick(InputAction.CallbackContext context)
        {
            var rayhit = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray: rayhit, hitInfo: out RaycastHit hit))
            {
                Transform SelectableObject = hit.collider.transform.parent;
                if (SelectableObject == null)
                    return; 

                if(SelectableObject.TryGetComponent(out EntityBase entity))
                {
                    SelectedUnit = entity;
                }
            }
        }
        public void BattleStart()
        {
            CameraControls.instance.OnBattle(SpawnedEnemies.ToArray());
            GameState.instance.InBattle = true;
            foreach(var e in SpawnedEnemies)
            {
                TurnOrder.Add(e.GetComponent<EntityBase>());
            }
            TurnOrder.Add(PlayerRef.instance); 
            TurnOrder = TurnOrder.OrderByDescending(e => e.GetComponent<EntityBase>().stats.Speed).ToList();
            CurrentActor = TurnOrder[0];
            //foreach(var a in Player.allies)

        }

        public void EndTurn()
        {
            int Currentindex = TurnOrder.IndexOf(CurrentActor);
            if (Currentindex + 1 < TurnOrder.Count)
            {
                Currentindex++;
            }
            else
                Currentindex = 0; 

            CurrentActor = TurnOrder[Currentindex];
        }

        private void Update()
        {
            if (!GameState.instance.InBattle)
                return;

            GameState.instance.BattleCanvas.SetActive( CurrentActor.tag == "Player");

            if(CurrentActor.tag == "Enemy")
            {
                CurrentActor.BasicAttack(PlayerRef.instance, CurrentActor.stats.Attack); 
            }

        }
    }
}