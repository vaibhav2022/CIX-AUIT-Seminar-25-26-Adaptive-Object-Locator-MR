using UnityEngine;

public class DebugLookAt : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}