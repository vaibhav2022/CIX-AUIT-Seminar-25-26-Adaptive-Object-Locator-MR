using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public Transform head;
    public GameObject markerPrefab;
    public RuntimeTransformContextSource targetContextSource;
    public AnchorManager anchorManager;
    public AnchorLabelMenu anchorLabelMenu;
    public AnchorMenuUI anchorMenuUI;
    public AnchorUIScreenToggle screenToggle;

    private Transform currentTarget;

    public float placementDistance = 2.0f;

    private float lastInputTime = 0f;
    public float inputCooldown = 0.3f;

    void Update()
    {
        if (anchorLabelMenu != null && anchorLabelMenu.isOpen)
        {
            return;
        }

        if (Time.time - lastInputTime < inputCooldown) return;

        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            PlaceMarkerInFront();
            lastInputTime = Time.time;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            DeleteSelectedAnchor();
            lastInputTime = Time.time;
        }
    }

    // public void PlaceMarkerInFront()
    // {
    //     if (head == null || markerPrefab == null || targetContextSource == null || anchorManager == null) return;

    //     if (anchorManager.anchors.Count >= 4)
    //     {
    //         Debug.Log("Anchor limit reached. Cannot add more than 4 anchors.");

    //         if (anchorMenuUI != null)
    //         {
    //             anchorMenuUI.ShowTemporaryMessage("Max 4 anchors", 1f);
    //         }

    //         return;
    //     }

    //     Vector3 spawnPosition = head.position + head.forward * placementDistance;
    //     spawnPosition.y = head.position.y - 0.1f;

    //     GameObject newMarker = Instantiate(markerPrefab, spawnPosition, Quaternion.identity);

    //     string label = "Unlabeled";
    //     anchorManager.AddAnchor(label, newMarker);
    //     anchorManager.selectedIndex = anchorManager.anchors.Count - 1;

    //     AnchorData selected = anchorManager.GetSelectedAnchor();
    //     currentTarget = selected != null ? selected.anchorTransform : null;

    //     targetContextSource.SetTarget(currentTarget != null ? currentTarget : head);

    //     if (anchorLabelMenu != null)
    //     {
    //         anchorLabelMenu.OpenMenu();
    //     }

    //     if (screenToggle != null)
    //     {
    //         screenToggle.ShowLabelMode();
    //     }

    //     Debug.Log("New anchor placed.");
    // }

    public void PlaceMarkerInFront()
    {
        if (head == null || markerPrefab == null || targetContextSource == null || anchorManager == null) return;

        if (anchorManager.anchors.Count >= 4)
        {
            Debug.Log("Anchor limit reached. Cannot add more than 4 anchors.");

            if (anchorMenuUI != null)
            {
                anchorMenuUI.ShowTemporaryMessage("Max 4 anchors", 1f);
            }

            return;
        }

        Vector3 spawnPosition = head.position + head.forward * placementDistance;
        spawnPosition.y = head.position.y - 0.1f;

        GameObject newMarker = Instantiate(markerPrefab, spawnPosition, Quaternion.identity);

        AnchorInteractableToggle toggle = newMarker.GetComponent<AnchorInteractableToggle>();
        if (toggle != null)
        {
            toggle.SetInteractable(false);
        }

        string label = "Unlabeled";
        anchorManager.AddAnchor(label, newMarker);
        anchorManager.selectedIndex = anchorManager.anchors.Count - 1;

        AnchorData selected = anchorManager.GetSelectedAnchor();
        currentTarget = selected != null ? selected.anchorTransform : null;

        targetContextSource.SetTarget(currentTarget != null ? currentTarget : head);

        if (anchorLabelMenu != null && selected != null)
        {
            anchorLabelMenu.OpenMenuForAnchor(selected);
        }

        if (screenToggle != null)
        {
            screenToggle.ShowLabelMode();
        }

        Debug.Log("New anchor placed.");
    }

    public void SetCurrentTarget(Transform target)
    {
        currentTarget = target;

        if (targetContextSource != null)
        {
            targetContextSource.SetTarget(target != null ? target : head);
        }
    }

    public void DeleteSelectedAnchor()
    {
        if (anchorManager == null) return;

        anchorManager.DeleteSelectedAnchor();

        AnchorData selected = anchorManager.GetSelectedAnchor();
        currentTarget = selected != null ? selected.anchorTransform : null;

        targetContextSource.SetTarget(currentTarget != null ? currentTarget : head);

        Debug.Log("Selected anchor deleted.");
    }

    public Transform GetCurrentTarget()
    {
        return currentTarget;
    }

    // public void RefreshCurrentTargetFromSelection()
    // {
    //     if (anchorManager == null || targetContextSource == null || head == null) return;

    //     AnchorData selected = anchorManager.GetSelectedAnchor();
    //     currentTarget = selected != null ? selected.anchorTransform : null;

    //     targetContextSource.SetTarget(currentTarget != null ? currentTarget : head);
            
    // }

    public void RefreshCurrentTargetFromSelection()
    {
        if (anchorLabelMenu != null && anchorLabelMenu.isOpen)
        {
            return;
        }

        if (anchorManager == null || targetContextSource == null || head == null) return;

        AnchorData selected = anchorManager.GetSelectedAnchor();
        currentTarget = selected != null ? selected.anchorTransform : null;

        targetContextSource.SetTarget(currentTarget != null ? currentTarget : head);
    }
}