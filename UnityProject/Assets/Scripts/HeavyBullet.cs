using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class HeavyBullet : MonoBehaviour {
        public float speed = 10f;
        public Rigidbody2D rb;
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private float _maxRange;

        private Vector3 _startPosition;


        void Start() {
            Vector3 dir = transform.up;
            _startPosition = transform.position;
            rb.velocity = dir * speed;
        }

        private void OnTriggerEnter2D(Collider2D hitInfo) {

            Enemy target = hitInfo.GetComponent<Enemy>();
            if (target != null) Debug.Log(target.name);
            if (target == null) {
                return;
            }
            target.TakeDamage(1);
            StartCoroutine(BulletCollapse());
            
        }

        private void FixedUpdate() {
            float _distanseTraveled = Mathf.Abs((transform.position - _startPosition).magnitude);
            if (_distanseTraveled >= _maxRange) {
                StartCoroutine(BulletCollapse());
            }
        }
        IEnumerator BulletCollapse() {
            rb.velocity = Vector2.zero;
            animator.SetBool("isDestroy", true);
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }

    }
}