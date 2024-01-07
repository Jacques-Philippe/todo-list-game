using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pilot.Bedroom
{

    public class DialogBox : MonoBehaviour
    {
        [SerializeField]
        private GameObject canvas;

        [SerializeField]
        private TextMeshProUGUI canvasText;

        [SerializeField]
        private PlayerInteraction playerInteraction;

        public Action OnDialogStarted;
        public Action OnDialogCompleted;

        private Queue<string> dialog = new Queue<string>();

        private void Awake()
        {
            playerInteraction.OnInputReceived += HandlePlayerInputReceived;
        }

        private void Start()
        {
            HideCanvas();
        }

        public void StartDialog(Queue<string> incomingDialog)
        {
            if (incomingDialog.Count < 1) {
                throw new Exception("Received empty dialog. Is this intentional?");
            }
            if (!canvas.activeSelf)
            {
                ShowCanvas();
            }
            this.dialog = incomingDialog;

            canvasText.text = this.dialog.Dequeue();
            OnDialogStarted?.Invoke();
        }

        private void HandlePlayerInputReceived()
        {
            //if the dialog canvas isn't active, return
            if (!this.canvas.activeSelf)
            {
                return;
            }

            if (dialog.Count == 0)
            {
                HideCanvas();
                this.OnDialogCompleted?.Invoke();
                return;
            }
            canvasText.text = this.dialog.Dequeue();
        }

        private void HideCanvas()
        {
            this.canvas.SetActive(false);
        }

        private void ShowCanvas()
        {
            this.canvas.SetActive(true);
        }
    }

}