using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class Weapon : MonoBehaviour {
        public Transform firePoint;
        public GameObject heavyBulletPrefab;

        private PlayerMovement pMove;
        private Player_Manager _player_manager;

        private void Start() {
            pMove = GetComponent<PlayerMovement>();
            _player_manager = GetComponent<Player_Manager>();
            _player_manager.canAttack = true;

        }

        void Update() {

            if (!_player_manager.canAttack) {
                return;
            }


            if (Input.GetKeyDown(_player_manager.attackKey)) {

                Shoot();
            }

        }

        void Shoot() {
            Vector3 dir = Input.mousePosition;
            dir.z = 0.0f;
            dir = Camera.main.ScreenToWorldPoint(dir);
            dir = dir - transform.position;
            if (dir.x < 0 && pMove._facingRight) {
                pMove.Flip();
            }
            else if (dir.x > 0 && !pMove._facingRight) {
                pMove.Flip();
            }
            //////////
            Instantiate(heavyBulletPrefab, firePoint.position, firePoint.rotation);

            //////////
            
            

        }
    }
}