using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
    public class AmmoUI : MonoBehaviour {
        [SerializeField]
        private GameObject _ammoImage;

        [SerializeField]
        private GameObject _reloadMessage;

        [SerializeField]
        private Weapon _playerWeapon;

        [SerializeField]
        private int _ammoGap;

        private GameObject[] _ammoArray;


        private Color _ammoColor;
        private void Start() {
            if (_playerWeapon != null) {
                _playerWeapon.OnReload += ReloadAmmo;
                _playerWeapon.OnShoot += ShootAmmo;

                _ammoArray = new GameObject[_playerWeapon.MaxAmmo];

                Vector3 reloadMessagePosition = transform.position;
                reloadMessagePosition.y += _ammoGap;
                reloadMessagePosition.x -= 150;
                _reloadMessage = Instantiate(_reloadMessage, reloadMessagePosition, transform.rotation, transform);

                Vector3 curPosition = transform.position;
                _ammoArray[0] = Instantiate(_ammoImage, curPosition, transform.rotation, transform);
                for (int i = 1; i < _playerWeapon.MaxAmmo; i++) {
                    curPosition.x = transform.position.x - _ammoGap * i * transform.localScale.x;
                    _ammoArray[i] = Instantiate(_ammoImage, curPosition, transform.rotation, transform);
                }

                _ammoColor = _ammoImage.GetComponent<Image>().color;
                
                _reloadMessage.SetActive(false);
            }
            
        }



        void ShootAmmo() {
            _ammoArray[_playerWeapon.CurAmmo].GetComponent<Image>().color = _ammoColor / 4;
        }

        void ReloadAmmo() {
            StartCoroutine(DoReload());
        }
        IEnumerator DoReload() {
            _reloadMessage.SetActive(true);
            yield return new WaitForSeconds(_playerWeapon.ReloadTime);
            _reloadMessage.SetActive(false);
            for (int i = 0; i < _playerWeapon.MaxAmmo; i++) {
                _ammoArray[i].GetComponent<Image>().color = _ammoColor;
            }
        }
    }
}