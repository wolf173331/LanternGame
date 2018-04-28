using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class CharacterFall : MonoBehaviour
    {

        // Use this for initialization
        public float FallHeightToDeath = 0.5f;
        protected float m_fallY = 0f;
        protected float _wasY = 0f;
        protected float m_fallTime = 0f;

        private Damageable m_damageable;
        private Transform m_trans;
        private Damager m_damager;
        void Awake()
        {
            m_trans = GetComponent<Transform>();
            _wasY = m_trans.position.y;

            m_damageable = GetComponent<Damageable>();
            m_damager = GetComponent<Damager>();
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (m_trans.position.y < _wasY)
            {
                m_fallY += _wasY - m_trans.position.y;
                if (m_fallY >= FallHeightToDeath)
                {
                   m_damageable.TakeDamage(m_damager, false);
                }
            }
            else
            {
                m_fallY = 0f;
            }
            _wasY = m_trans.position.y;

        }
    }
}
