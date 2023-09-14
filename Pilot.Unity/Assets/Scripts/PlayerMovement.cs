using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal == 0.0f && vertical == 0.0f)
        {
            return;
        }

        Vector3 direction = speed * ((Vector3.right * horizontal) + (Vector3.up * vertical));
        Vector3 movement = Vector3.ClampMagnitude(direction, speed);

        this.playerTransform.position += movement * Time.deltaTime;
    }
}
