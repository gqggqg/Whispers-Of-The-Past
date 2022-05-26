using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game {

    public class Weapon : MonoBehaviour {

        [SerializeField]
        private GameObject _heavyBulletPrefab;

        [SerializeField]
        private int _maxAmmo;

        [SerializeField]
        private float _reloadTime;

        [SerializeField]
        private float _cooldawnTime;

        public Animator _animator;

        public event Action OnShoot;
        public event Action OnReload;

        public float _nextAttack = 0f;
        private int _curAmmo;
        private bool _isCd = false;

        public float ReloadTime => _reloadTime;
        public int CurAmmo => _curAmmo;
        public int MaxAmmo => _maxAmmo;


        //public event Action OnShoot;

        void Start() {
            _curAmmo = _maxAmmo;
        }
        public void Attack() {
            if (_curAmmo > 0) {
                if (_isCd == false) {
                    StartCoroutine(Shoot());
                }
            }
        }
        public void Reload() {
            StartCoroutine(DoReload());
            _curAmmo = -1;
        }

        IEnumerator Shoot() {
            _curAmmo--;
            OnShoot?.Invoke();
            Instantiate(_heavyBulletPrefab, transform.position, transform.rotation);
            _isCd = true;
            yield return new WaitForSeconds(_cooldawnTime);
            _isCd = false;
        }

        IEnumerator DoReload() {
            OnReload?.Invoke();
            yield return new WaitForSeconds(_reloadTime);
            _curAmmo = _maxAmmo;
        }
    }
}
