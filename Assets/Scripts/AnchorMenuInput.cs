

using UnityEngine;

public class AnchorMenuInput : MonoBehaviour
{
    public AnchorManager anchorManager;
    public PlacementManager placementManager;
    public AnchorLabelMenu anchorLabelMenu;

    public float joystickThreshold = 0.7f;

    private bool stickInUse = false;

    void Update()
    {
        if (anchorLabelMenu != null && anchorLabelMenu.isOpen)
        {
            return;
        }

        if (anchorManager == null || placementManager == null) return;

        // Right joystick only
        Vector2 stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        // Only vertical movement matters
        float vertical = stick.y;

        if (Mathf.Abs(vertical) < 0.2f)
        {
            stickInUse = false;
            return;
        }

        if (stickInUse) return;

        if (vertical > joystickThreshold)
        {
            anchorManager.MoveSelectionUp();
            placementManager.RefreshCurrentTargetFromSelection();
            stickInUse = true;
        }
        else if (vertical < -joystickThreshold)
        {
            anchorManager.MoveSelectionDown();
            placementManager.RefreshCurrentTargetFromSelection();
            stickInUse = true;
        }
    }
}