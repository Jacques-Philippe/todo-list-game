using System;
using UnityEngine;

namespace Pilot.Bedroom
{

    public class PlayerWakes : MonoBehaviour
    {
        [Tooltip("The visual corresponding to the player")]
        [SerializeField]
        private Transform playerVisual;

        [Tooltip("The full player gameobject. This should be moved to the player visual on player wakes up")]
        [SerializeField]
        private Transform fullPlayer;

        [SerializeField]
        private Animator bedController;

        [Tooltip("The time we should wait on scene start before listening for user input")]
        [SerializeField]
        private float timeToWaitBeforeListening;

        /// <summary>
        /// Event fired for the player is woken up
        /// </summary>
        public Action OnPlayerWakes;

        /// <summary>
        /// Timer to help us keep track of the time we wait
        /// </summary>
        private float timer = 0.0f;


        // Update is called once per frame
        void Update()
        {
            //after X seconds
            if (timer < timeToWaitBeforeListening) {
                timer += Time.deltaTime;
                return;
            }
            //listen for input
            if (!InputIsDetected())
            {
                return;
            }
            //given input, use the wake animation
            bedController.SetBool("InputDetected", true);
            //move the full player transform to that of the player visual
        }

        private bool InputIsDetected()
        {
            bool movementInput = Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f;

            return movementInput;
        }

        /// <summary>
        /// Helper to move the full player gameobject to the player visual prefab. <br />
        /// This is called in the inspector via Animation Event in the bed's Wake animation
        /// </summary>
        private void MovePlayerToPlayerVisual()
        {
            this.fullPlayer.transform.rotation = this.playerVisual.transform.rotation;
            this.fullPlayer.transform.position = this.playerVisual.transform.position;

            //hide player visual
            this.playerVisual.gameObject.SetActive(false);

            this.OnPlayerWakes?.Invoke();
            
            this.enabled = false;
        }
    }

}