using UnityEngine;

public class AnchorInteractableToggle : MonoBehaviour
{
    public Behaviour[] componentsToToggle;
    public Rigidbody rb;

    public void SetInteractable(bool enabledState)
    {
        if (componentsToToggle != null)
        {
            foreach (var comp in componentsToToggle)
            {
                if (comp != null)
                    comp.enabled = enabledState;
            }
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Lock object while labeling
            rb.isKinematic = !enabledState;
        }
    }
}