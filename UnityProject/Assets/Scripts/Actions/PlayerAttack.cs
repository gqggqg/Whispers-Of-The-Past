using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace RPG {
    public class PlayerAttack : MonoBehaviour {
        public Transform firePoint;
        public GameObject heavyBulletPrefab;

        public event Action OnAttack;

        [SerializeField]
        private Player _player_manager;



        void Update() {     
            if (!_player_manager.CanAttack) {
                return;
            }

            if (Input.GetKeyDown(_player_manager.AttackKey)) {
                Shoot();
            }

        }

        void Shoot() {

            OnAttack?.Invoke();
            //////////
            Instantiate(heavyBulletPrefab, firePoint.position, firePoint.rotation);
            //////////

        }
    }
}