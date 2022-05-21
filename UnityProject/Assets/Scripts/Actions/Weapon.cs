using System;
using UnityEngine;

namespace RPG {

    public class Weapon : MonoBehaviour {

        [SerializeField]
        private GameObject _heavyBulletPrefab;


        public event Action OnShoot;


        public void Shoot() {
            Instantiate(_heavyBulletPrefab, transform.position, transform.rotation);
            OnShoot?.Invoke();
        }
    }
}
