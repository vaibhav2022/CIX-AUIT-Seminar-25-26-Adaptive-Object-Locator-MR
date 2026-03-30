using UnityEngine;

public class AnchorUIScreenToggle : MonoBehaviour
{
    public GameObject homeLabel;
    public Canvas anchorMenuCanvas;
    public Canvas labelMenuCanvas;

    public GameObject homeInstructions;
    public GameObject anchorListInstructions;
    public GameObject labelMenuInstructions;

    public Renderer[] arrowRenderers;

    public AnchorManager anchorManager;
    public PlacementManager placementManager;
    public AnchorLabelMenu anchorLabelMenu;

    public bool isAnchorMode = false;

    void Start()
    {
        SetHomeMode();
    }

    void Update()
    {
        if (anchorLabelMenu != null && anchorLabelMenu.isOpen)
        {
            return;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            ToggleMode();
        }
    }

    public void ToggleMode()
    {
        isAnchorMode = !isAnchorMode;

        if (isAnchorMode)
            SetAnchorMode();
        else
            SetHomeMode();
    }

    public void SetHomeMode()
    {
        isAnchorMode = false;

        if (homeLabel != null) homeLabel.SetActive(true);
        if (anchorMenuCanvas != null) anchorMenuCanvas.enabled = false;
        if (labelMenuCanvas != null) labelMenuCanvas.enabled = false;

        if (homeInstructions != null) homeInstructions.SetActive(true);
        if (anchorListInstructions != null) anchorListInstructions.SetActive(false);
        if (labelMenuInstructions != null) labelMenuInstructions.SetActive(false);

        SetArrowVisible(false);
        SetAllAnchorsVisible(false);
    }

    public void SetAnchorMode()
    {
        isAnchorMode = true;

        if (homeLabel != null) homeLabel.SetActive(false);
        if (anchorMenuCanvas != null) anchorMenuCanvas.enabled = true;
        if (labelMenuCanvas != null) labelMenuCanvas.enabled = false;

        if (homeInstructions != null) homeInstructions.SetActive(false);
        if (anchorListInstructions != null) anchorListInstructions.SetActive(true);
        if (labelMenuInstructions != null) labelMenuInstructions.SetActive(false);

        if (anchorManager != null)
            anchorManager.UpdateAnchorVisibility();

        if (placementManager != null)
            placementManager.RefreshCurrentTargetFromSelection();

        SetArrowVisible(true);
    }

    public void ShowLabelMode()
    {
        if (anchorMenuCanvas != null) anchorMenuCanvas.enabled = false;
        if (labelMenuCanvas != null) labelMenuCanvas.enabled = true;

        if (homeInstructions != null) homeInstructions.SetActive(false);
        if (anchorListInstructions != null) anchorListInstructions.SetActive(false);
        if (labelMenuInstructions != null) labelMenuInstructions.SetActive(true);
    }

    public void ShowAnchorListMode()
    {
        if (anchorMenuCanvas != null) anchorMenuCanvas.enabled = true;
        if (labelMenuCanvas != null) labelMenuCanvas.enabled = false;

        if (homeInstructions != null) homeInstructions.SetActive(false);
        if (anchorListInstructions != null) anchorListInstructions.SetActive(true);
        if (labelMenuInstructions != null) labelMenuInstructions.SetActive(false);

        if (anchorManager != null)
            anchorManager.UpdateAnchorVisibility();

        if (placementManager != null)
            placementManager.RefreshCurrentTargetFromSelection();

        SetArrowVisible(true);
    }

    private void SetAllAnchorsVisible(bool visible)
    {
        if (anchorManager == null) return;

        foreach (var anchor in anchorManager.anchors)
        {
            if (anchor != null && anchor.anchorObject != null)
            {
                anchor.anchorObject.SetActive(visible);
            }
        }
    }

    private void SetArrowVisible(bool visible)
    {
        if (arrowRenderers == null) return;

        foreach (Renderer r in arrowRenderers)
        {
            if (r != null)
                r.enabled = visible;
        }
    }
}