using UnityEngine;

namespace Pilot.Bedroom
{

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform playerTransform;

        [SerializeField]
        private float movementSpeed;

        public LayerMask barrierLayerMask;

        /// <summary>
        /// Whether player movement is currently enabled
        /// </summary>
        public bool IsPlayerMovementEnabled { private set; get; } = true;

        // Update is called once per frame
        void Update()
        {
            if (!this.IsPlayerMovementEnabled)
            {
                return;
            }

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            Vector3 horizontalMovement = horizontal * Vector3.right;
            Vector3 verticalMovement = vertical * Vector3.forward;

            if (horizontalMovement.magnitude > 0 || verticalMovement.magnitude > 0)
            {
                Vector3 movementDirUnit = (horizontalMovement + verticalMovement).normalized;
                Vector3 movement = (movementDirUnit * movementSpeed * Time.deltaTime);

                //rotate player transform
                playerTransform.rotation = Quaternion.LookRotation(movement);

                if (CollidesWithBarrier(movement))
                {
                    return;
                }

                //move player transform
                playerTransform.Translate(movement, Space.World);
            }
        }

        private bool CollidesWithBarrier(Vector3 movement)
        {
            Ray ray = new Ray(origin: playerTransform.position, direction: movement);
            return Physics.Raycast(ray, maxDistance: 0.2f, this.barrierLayerMask);
        }

        public void EnableMovement()
        {
            this.IsPlayerMovementEnabled = true;
        }

        public void DisableMovement()
        {
            this.IsPlayerMovementEnabled = false;
        }
    }

}