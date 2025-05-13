using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        // Encuentra la cámara principal (AR Camera)
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Sigue la posición de la cámara
        transform.position = cameraTransform.position;
    }
}
