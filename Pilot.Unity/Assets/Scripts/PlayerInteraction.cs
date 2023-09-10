using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Action OnPlayerInteracted;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player interacted");
            OnPlayerInteracted?.Invoke();
        }   
    }
}
