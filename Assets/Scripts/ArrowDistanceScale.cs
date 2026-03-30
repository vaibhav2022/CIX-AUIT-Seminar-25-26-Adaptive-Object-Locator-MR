using UnityEngine;

public class ArrowDistanceScale : MonoBehaviour
{
    public PlacementManager placementManager;
    public Transform head;

    public float minDistance = 0.5f;
    public float maxDistance = 5.0f;

    public float minScale = 0.6f;
    public float maxScale = 1.5f;

    public float smoothSpeed = 5f;

    private Vector3 initialScale;
    private Vector3 desiredScale;

    void Start()
    {
        initialScale = transform.localScale;
        desiredScale = initialScale;
    }

    void Update()
    {
        if (placementManager == null || head == null) return;

        Transform target = placementManager.GetCurrentTarget();
        if (target == null) return;

        float distance = Vector3.Distance(head.position, target.position);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        float t = Mathf.InverseLerp(minDistance, maxDistance, distance);
        float scaleMultiplier = Mathf.Lerp(minScale, maxScale, t);

        desiredScale = initialScale * scaleMultiplier;
        transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * smoothSpeed);
    }
}
