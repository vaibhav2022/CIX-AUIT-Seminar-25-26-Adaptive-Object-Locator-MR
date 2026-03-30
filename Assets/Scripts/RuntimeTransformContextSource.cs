using AUIT.ContextSources;
using UnityEngine;

public class RuntimeTransformContextSource : TransformContextSource
{
    [SerializeField]
    private Transform runtimeTarget;

    [SerializeField]
    private Transform fallbackTarget;

    public void SetTarget(Transform newTarget)
    {
        runtimeTarget = newTarget;
        Debug.Log("RuntimeTransformContextSource set to: " + (runtimeTarget != null ? runtimeTarget.name : "NULL"));
    }

    public override Transform GetValue()
    {
        Debug.Log("RuntimeTransformContextSource GetValue: " + (runtimeTarget != null ? runtimeTarget.name : "NULL"));
        // return runtimeTarget;

        if (runtimeTarget != null)
            return runtimeTarget;

        return fallbackTarget;
    }

    public void ClearTarget()
    {
        runtimeTarget = null;
    }
}

// using AUIT.ContextSources;
// using UnityEngine;

// public class RuntimeTransformContextSource : TransformContextSource
// {
//     [SerializeField]
//     private Transform runtimeTarget;

//     public void SetTarget(Transform newTarget)
//     {
//         runtimeTarget = newTarget;
//         Debug.Log("RuntimeTransformContextSource set to: " + (runtimeTarget != null ? runtimeTarget.name : "NULL"));
//     }

//     public override Transform GetValue() 
//     {
//         return runtimeTarget;
//     }

//     public bool HasTarget()
//     {
//         return runtimeTarget != null;
//     }
// }