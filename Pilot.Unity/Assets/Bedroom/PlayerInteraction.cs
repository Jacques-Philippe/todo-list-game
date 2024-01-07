using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pilot.Bedroom
{

    public class PlayerInteraction : MonoBehaviour
    {
        /// <summary>
        /// Whether we're listening for player interaction
        /// </summary>
        private bool isEnabled = true;

        public Action OnInputReceived;

        // Update is called once per frame
        void Update()
        {
            if (!isEnabled)
            {
                return;
            }

            //else we're listening for player interaction
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.OnInputReceived?.Invoke();
            }
        }

        public void EnablePlayerInteraction()
        {
            this.isEnabled = true;
        }

        public void DisablePlayerInteraction()
        {
            this.isEnabled = false;
        }
    }

}