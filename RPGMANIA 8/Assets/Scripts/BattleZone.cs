using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Playable;

namespace Playable.Entities.Battle
{
    public class BattleZone : MonoBehaviour
    {
        public GameObject Player;
        public Transform[] AllySpot = new Transform[2]; 
        public LayerMask GroundLayers; 
        private CharacterController playerController; 
        public float radius; 

        /*5 max enemies? but we need to make sure each object is 
         * A. In level Bounds X
         * B. Not in a wall
         * C. Grounded X
         * So 12 max spots should be enough
         */
        public Dictionary<Vector3, bool> SpawnZones = new Dictionary<Vector3, bool>();
        public void Awake()
        {
            playerController = Player.GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            if (!GameState.instance.InBattle || !GameState.instance.InCutscene)
            {
                SpawnZones.Clear();
                for (int i = 0; i < 20; i++)
                {
                    /* Distance around the circle */
                    var radians = 2 * Mathf.PI / 20 * i;

                    /* Get the vector direction */
                    var vertical = Mathf.Sin(radians);
                    var horizontal = Mathf.Cos(radians);

                    /* Get the spawn position */
                    var spawnDir = new Vector3(horizontal, 0, vertical);
                    SpawnZones.Add(new Vector3(Player.transform.position.x,
                        //Y needs to change with ground hight 
                        playerController.bounds.min.y + HalfVector.QuarterUp.y,
                        Player.transform.position.z)
                        + spawnDir * radius, false);
                }

            }

           CheckPoints(SpawnZones); 
        }

        public void CheckPoints(Dictionary<Vector3, bool> Points)
        {
            RaycastHit hit;
            List<Vector3> keysToRemove = new List<Vector3>();

            foreach (var point in Points.Keys)
            if (!Physics.SphereCast(point, 0.25f, Vector3.down,
                out hit, 0.2f, GroundLayers))
            {
                    keysToRemove.Add(point);
            }

            foreach (var point in keysToRemove)
            {
                Points.Remove(point);
            }
        }

        public void SpawnInZone(GameObject Enemy)
        {
            List<Vector3> keysToRemove = new List<Vector3>();

            foreach (var point in SpawnZones) 
            {
                if(point.Value)
                {
                    keysToRemove.Add(point.Key);  
                }
            }

            foreach (var point in keysToRemove)
            {
                SpawnZones.Remove(point);
            }

            int RemainingSpots = SpawnZones.Keys.Count;

            if (Enemy == null || RemainingSpots <= 0)
                return; 

            int index = Random.Range(0, RemainingSpots);

            var SpawnPoint = SpawnZones.Keys.ElementAt(index);

            var EnemySpawn = Instantiate(Enemy, SpawnPoint, Quaternion.identity).GetComponent<EntityBase>();
            BattleManager.instance.SpawnedEnemies.Add(EnemySpawn);
            SpawnZones[SpawnPoint] = true;

        }


#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            foreach (var zone in SpawnZones.Keys)
            {
                Gizmos.DrawWireSphere(zone, 0.25f);
            }

            Gizmos.color = Color.blue;
            foreach (var team in AllySpot)
            {
                Gizmos.DrawWireSphere(team.position, 0.25f);
            }
        }
#endif


    }
}