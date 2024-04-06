using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    private readonly float distanceFromPlayer = 5f;
    private Vector3 desiredPosition;
    private readonly float rotationSpeed = 1.0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void LateUpdate()
    {
        desiredPosition = (player.position + new Vector3(0, 1.3f, 0)) - player.up * distanceFromPlayer; // follow player
        
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            RotateUpward();
        }
        else
        {
            RotateDownward();
        }
        transform.position = desiredPosition;

    }

    private void RotateDownward()
    {
        Quaternion targetRotation = Quaternion.Euler(20f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void RotateUpward()
    {
        Quaternion targetRotation = Quaternion.Euler(-40f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
