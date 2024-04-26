using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Playable.Entities
{
    public class CameraControls : MonoBehaviour
    {
        public static CameraControls instance;
        public CinemachineVirtualCamera OWCam, BattleCam;
        public CinemachineTargetGroup BattleTargetGroup;

        private void Awake()
        {
            instance = this;
        }

        public void OnBattle(EntityBase[] Enemies)
        {
            OWCam.gameObject.SetActive(false);
            BattleCam.gameObject.SetActive(true);
            foreach (var enemy in Enemies)
            {
                BattleTargetGroup.AddMember(enemy.transform, 1, 2);
            }
        }

        public void OnOW()
        {
            OWCam.gameObject.SetActive(true);
            BattleCam.gameObject.SetActive(false);
        }
    }
}