using UnityEngine;

public class ArrowVisibilityByTarget : MonoBehaviour
{
    public PlacementManager placementManager;
    public Transform head;
    public Renderer[] arrowRenderers;

    public float hideDistance = 1.6f;
    public float showDistance = 1.9f;

    private bool isVisible = true;

    void Update()
    {
        if (placementManager == null || head == null || arrowRenderers == null || arrowRenderers.Length == 0)
            return;

        Transform target = placementManager.GetCurrentTarget();

        if (target == null)
        {
            SetArrowVisible(false);
            return;
        }

        float distance = Vector3.Distance(head.position, target.position);

        if (isVisible && distance < hideDistance)
        {
            SetArrowVisible(false);
        }
        else if (!isVisible && distance > showDistance)
        {
            SetArrowVisible(true);
        }
    }

    private void SetArrowVisible(bool visible)
    {
        isVisible = visible;

        foreach (Renderer r in arrowRenderers)
        {
            if (r != null) r.enabled = visible;
        }
    }
}