using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class PlayerAttack : MonoBehaviour {
        public Transform firePoint;
        public GameObject heavyBulletPrefab;

        [SerializeField]
        private AnimationController _animation_controller;

        [SerializeField]
        private Player _player_manager;

        private void Start() {

        }

        void Update() {     
            if (!_player_manager.CanAttack) {
                return;
            }

            if (Input.GetKeyDown(_player_manager.AttackKey)) {
                Shoot();
            }

        }

        void Shoot() {
            Vector3 dir = Input.mousePosition;
            dir = Camera.main.ScreenToWorldPoint(dir);
            dir = dir - transform.position;

            _animation_controller.FlipToDirection(dir);
            //////////
            Instantiate(heavyBulletPrefab, firePoint.position, firePoint.rotation);
            //////////

        }
    }
}