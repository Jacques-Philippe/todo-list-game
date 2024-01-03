using UnityEngine;

namespace Pilot.Bedroom
{

    public class BedroomPlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private PlayerWakes playerWakes;

        [SerializeField]
        private PlayerMovement playerMovement;

        void Start()
        {
            this.playerWakes.OnPlayerWakes += playerMovement.EnableMovement;

            this.playerMovement.DisableMovement();
        }
    }
}
