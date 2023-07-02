﻿using UnityEngine;

namespace LSC
{
    public class Weapon : MonoBehaviour
    {
        [Header("剛體")]
        public Rigidbody2D rig;

        [Header("武器發射力道")]
        public Vector2 power;
        [Header("攻擊力"), Range(0, 500)]
        public float attack = 50;

        private void Awake()
        {
            rig.AddForce(power); 
        }
    }
}

