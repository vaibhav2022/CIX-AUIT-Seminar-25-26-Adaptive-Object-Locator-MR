using UnityEngine;

[System.Serializable]
public class AnchorData
{
    public string label;
    public Transform anchorTransform;
    public GameObject anchorObject;

    public AnchorData(string label, Transform anchorTransform, GameObject anchorObject)
    {
        this.label = label;
        this.anchorTransform = anchorTransform;
        this.anchorObject = anchorObject;
    }
}