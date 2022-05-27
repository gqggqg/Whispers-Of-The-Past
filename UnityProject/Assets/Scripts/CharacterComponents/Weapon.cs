using System;
using UnityEngine;

namespace Game {

    public class Weapon : MonoBehaviour {

        [SerializeField]
        private GameObject _heavyBulletPrefab;


        public event Action OnShoot;


        public void Shoot() {
            OnShoot?.Invoke();
            Instantiate(_heavyBulletPrefab, transform.position, transform.rotation);
        }
    }
}
