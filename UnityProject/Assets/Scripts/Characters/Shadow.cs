using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Game {

    public class Shadow : Enemy {



        protected override void Start() {
            base.Start();
            if (_weapon != null) {
                _weapon.OnAttack += OnAttack;
            }
        }
        private void Update() {
           
        }

        private void OnAttack() {
                InvokeAttackAnimation(0);
        }

        
    }
}