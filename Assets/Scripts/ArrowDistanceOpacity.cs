using UnityEngine;

public class ArrowDistanceOpacity : MonoBehaviour
{
    public PlacementManager placementManager;
    public Transform head;
    public Renderer arrowRenderer;

    public float minDistance = 2.0f;
    public float maxDistance = 6.0f;

    public float nearAlpha = 0.1f;
    public float farAlpha = 1.0f;

    public float smoothSpeed = 5f;

    private Material[] mats;
    private float currentAlpha;

    void Start()
    {
        if (arrowRenderer != null)
        {
            mats = arrowRenderer.materials;
            currentAlpha = farAlpha;
        }
    }

    void Update()
    {
        if (placementManager == null || head == null || arrowRenderer == null || mats == null) return;

        Transform target = placementManager.GetCurrentTarget();
        if (target == null) return;

        float distance = Vector3.Distance(head.position, target.position);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        float t = Mathf.InverseLerp(minDistance, maxDistance, distance);
        float desiredAlpha = Mathf.Lerp(nearAlpha, farAlpha, t);

        currentAlpha = Mathf.Lerp(currentAlpha, desiredAlpha, Time.deltaTime * smoothSpeed);

        foreach (Material mat in mats)
        {
            if (mat.HasProperty("_Color"))
            {
                Color c = mat.color;
                c.a = currentAlpha;
                mat.color = c;
            }
        }
    }
}