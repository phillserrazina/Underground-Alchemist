using System;
using UnityEngine;

namespace Lucerna.Utils
{
	public class ColliderEvents : MonoBehaviour 
	{
        // VARIABLES
        public event EventHandler<Collision> OnCollisionEnterRaised;
        public event EventHandler<Collision> OnCollisionStayRaised;
        public event EventHandler<Collision> OnCollisionExitRaised;

        public event EventHandler<Collider> OnTriggerEnterRaised;
        public event EventHandler<Collider> OnTriggerStayRaised;
        public event EventHandler<Collider> OnTriggerExitRaised;

        // EXECUTION FUNCTIONS
        private void OnCollisionEnter(Collision other)
        {
            OnCollisionEnterRaised?.Invoke(this, other);
        }

        private void OnCollisionStay(Collision other)
        {
            OnCollisionStayRaised?.Invoke(this, other);
        }

        private void OnCollisionExit(Collision other)
        {
            OnCollisionExitRaised?.Invoke(this, other);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterRaised?.Invoke(this, other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerStayRaised?.Invoke(this, other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitRaised?.Invoke(this, other);
        }
    }
}