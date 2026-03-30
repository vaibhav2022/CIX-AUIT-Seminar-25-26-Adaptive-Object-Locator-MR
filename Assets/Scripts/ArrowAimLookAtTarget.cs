using UnityEngine;

public class ArrowAimHUDPointer : MonoBehaviour
{
    public Transform target;
    public Transform head;

    void LateUpdate()
    {
        Debug.Log("Hello from Unity!----------------");

        if (target == null || head == null) return;

        Vector3 toTarget = (target.position - head.position).normalized;

        Vector3 localDir = head.InverseTransformDirection(toTarget);

        Vector3 flattened = new Vector3(localDir.x, localDir.y, 1f).normalized;

        transform.localRotation = Quaternion.LookRotation(flattened, Vector3.up);
    }
}