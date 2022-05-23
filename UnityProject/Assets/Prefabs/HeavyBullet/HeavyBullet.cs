using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class HeavyBullet : MonoBehaviour {
        public float speed = 10f;
        public Rigidbody2D rb;
        public Animator animator;

        void Start() {
            animator = GetComponent<Animator>();
            Vector3 dir = Input.mousePosition;
            dir = Camera.main.ScreenToWorldPoint(dir);
            dir = dir - transform.position;
            dir.z = 0.0f;
            dir.Normalize();
            rb.velocity = dir * speed;
        }

        private void OnTriggerEnter2D(Collider2D hitInfo) {
            Debug.Log(hitInfo.name);
            Enemy target = hitInfo.GetComponent<Enemy>();

            if (hitInfo.name == "HeavyBullet(Clone)") {
                return;
            }
            if (hitInfo.name == "MainCharacter") {
                return;
            }
            if (target != null) {
                target.TakeDamage(1);
            }
            rb.velocity = Vector2.zero;
            StartCoroutine(BulletCollapse());
            
        }
        IEnumerator BulletCollapse() {
            animator.SetBool("isDestroy", true);
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }

    }
}