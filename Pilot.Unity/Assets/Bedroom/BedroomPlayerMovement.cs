using System.Collections.Generic;
using UnityEngine;

namespace Pilot.Bedroom
{

    public class BedroomPlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private PlayerWakes playerWakes;

        [SerializeField]
        private DialogBox dialogBox;

        [SerializeField]
        private PlayerMovement playerMovement;

        [SerializeField]
        private PlayerInteraction playerInteraction;

        //when the player wakes up, we start a new dialog

        void Start()
        {
            var dialog = new Queue<string>();
            dialog.Enqueue("Hello");
            dialog.Enqueue("World");

            this.playerWakes.OnPlayerWakes += () => dialogBox.StartDialog(dialog);
            //this.dialogBox.OnDialogStarted += playerInteraction.EnablePlayerInteraction;
            this.dialogBox.OnDialogCompleted += () =>
            {
                playerMovement.EnableMovement();
            };

            this.playerMovement.DisableMovement();
        }
    }
}
