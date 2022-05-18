using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG {
    public class HeavyBullet : MonoBehaviour {
        public float speed = 10f;
        public Rigidbody2D rb;

        void Start() {
            Vector3 dir = Input.mousePosition;
            dir = Camera.main.ScreenToWorldPoint(dir);
            dir = dir - transform.position;
            dir.z = 0.0f;
            dir.Normalize();
            rb.velocity = dir * speed;
            Debug.Log(dir * speed);
            Debug.Log(dir);
        }

        private void OnTriggerEnter2D(Collider2D hitInfo) {
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
        }

    }
}