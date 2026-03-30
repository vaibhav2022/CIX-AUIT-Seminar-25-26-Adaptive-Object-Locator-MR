using UnityEngine;

public class AnchorMenuFocusFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public float fullAlpha = 1.0f;
    public float dimAlpha = 0.35f;
    public float fadeSpeed = 5f;

    public float idleDelay = 1.0f;
    public float joystickThreshold = 0.2f;

    private float lastInputTime;
    private float targetAlpha;

    void Start()
    {
        lastInputTime = Time.time;
        targetAlpha = fullAlpha;
    }

    void Update()
    {
        Vector2 stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        if (Mathf.Abs(stick.y) > joystickThreshold || Mathf.Abs(stick.x) > joystickThreshold)
        {
            lastInputTime = Time.time;
            targetAlpha = fullAlpha;
        }
        else
        {
            if (Time.time - lastInputTime > idleDelay)
            {
                targetAlpha = dimAlpha;
            }
        }

        if (canvasGroup != null)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, Time.deltaTime * fadeSpeed);
        }
    }

    public void ForceFullOpacity()
    {
        lastInputTime = Time.time;
        targetAlpha = fullAlpha;
    }
}