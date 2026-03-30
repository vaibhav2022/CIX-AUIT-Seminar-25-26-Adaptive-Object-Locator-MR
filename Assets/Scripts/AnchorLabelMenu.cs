using TMPro;
using UnityEngine;

public class AnchorLabelMenu : MonoBehaviour
{
    public AnchorManager anchorManager;
    public AnchorUIScreenToggle screenToggle;
    public PlacementManager placementManager;

    public GameObject panelRoot;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI row0Text;
    public TextMeshProUGUI row1Text;
    public TextMeshProUGUI row2Text;
    public TextMeshProUGUI row3Text;

    public string[] presetLabels = { "Couch", "Window", "Desk", "Chair" };

    public float joystickThreshold = 0.7f;
    public float inputCooldown = 0.25f;

    private TextMeshProUGUI[] rows;
    private int selectedLabelIndex = 0;
    private float lastMoveTime = 0f;

    private AnchorData pendingAnchor;

    public bool isOpen = false;

    void Awake()
    {
        rows = new TextMeshProUGUI[] { row0Text, row1Text, row2Text, row3Text };
        CloseMenu();
    }

    void Update()
    {
        if (!isOpen) return;

        if (Time.time - lastMoveTime >= inputCooldown)
        {
            // Vector2 stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

            // if (stick.y > joystickThreshold)
            float vertical = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;

            if (vertical > joystickThreshold)
            {
                selectedLabelIndex = Mathf.Max(0, selectedLabelIndex - 1);
                lastMoveTime = Time.time;
                RefreshUI();
            }
            else if (vertical < -joystickThreshold)
            {
                selectedLabelIndex = Mathf.Min(presetLabels.Length - 1, selectedLabelIndex + 1);
                lastMoveTime = Time.time;
                RefreshUI();
            }
        }

        // Right trigger only
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            ConfirmSelectedLabel();
        }
    }

    public void OpenMenuForAnchor(AnchorData anchor)
    {
        pendingAnchor = anchor;
        isOpen = true;
        selectedLabelIndex = 0;

        if (panelRoot != null)
            panelRoot.SetActive(true);

        // Force current target to stay on the newly created anchor
        if (placementManager != null && pendingAnchor != null)
        {
            placementManager.SetCurrentTarget(pendingAnchor.anchorTransform);
        }

        RefreshUI();
    }

    public void CloseMenu()
    {
        isOpen = false;
        pendingAnchor = null;

        if (panelRoot != null)
            panelRoot.SetActive(false);
    }

    public void ConfirmSelectedLabel()
    {
        if (anchorManager == null || pendingAnchor == null) return;

        // Rename the exact anchor being labeled
        anchorManager.RenameAnchor(pendingAnchor, presetLabels[selectedLabelIndex]);

        // Keep selection on that same anchor
        anchorManager.SelectAnchor(pendingAnchor);

        if (placementManager != null)
        {
            placementManager.SetCurrentTarget(pendingAnchor.anchorTransform);
        }

        if (screenToggle != null)
        {
            screenToggle.ShowAnchorListMode();
        }

        if (pendingAnchor != null && pendingAnchor.anchorObject != null)
        {
            AnchorInteractableToggle toggle = pendingAnchor.anchorObject.GetComponent<AnchorInteractableToggle>();
            if (toggle != null)
            {
                toggle.SetInteractable(true);
            }
        }

        CloseMenu();
    }

    private void RefreshUI()
    {
        if (titleText != null)
            titleText.text = "What is this?";

        for (int i = 0; i < rows.Length; i++)
        {
            if (rows[i] == null) continue;

            if (i < presetLabels.Length)
            {
                string prefix = (i == selectedLabelIndex) ? "> " : "  ";
                rows[i].text = prefix + presetLabels[i];
            }
            else
            {
                rows[i].text = "";
            }
        }
    }
}