using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Target")]
    public Transform target;          // Player

    [Header("Offset & Smooth")]
    public Vector3 offset = new Vector3(0, 0, -10); // c�mara centrada en Player
    public float smoothSpeed = 0.125f;              // velocidad de seguimiento

    void LateUpdate()
    {
        if (target == null) return;

        // Posici�n deseada centrada en Player
        Vector3 desiredPosition = target.position + offset;

        // Suavizar movimiento
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Mantener pixel art n�tido (64 PPU, tiles 64x64)
        transform.position = new Vector3(
            Mathf.Round(smoothedPosition.x * 64f) / 64f,
            Mathf.Round(smoothedPosition.y * 64f) / 64f,
            smoothedPosition.z
        );
    }
}
