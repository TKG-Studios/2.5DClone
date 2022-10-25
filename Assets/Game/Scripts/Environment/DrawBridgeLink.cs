using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
    public class DrawBridgeLink : MonoBehaviour
    {
        protected Health _health;
        public GameObject objectToActivate;
        private void Awake()
        {
            _health = this.gameObject.GetComponent<Health>();
        }

        protected virtual void OnEnable()
        {
            if (_health != null)
            {
                _health.OnHit += OnHit;
            }
        }

        private void OnDisable()
        {
            if (_health != null)
            {
                _health.OnHit = OnHit;
            }
        }

        protected virtual void OnHit()
        {
            objectToActivate.GetComponent<RotateDoor>().isActive = true;
        }
    }
}