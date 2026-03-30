using System.Collections.Generic;
using UnityEngine;

public class AnchorManager : MonoBehaviour
{
    public List<AnchorData> anchors = new List<AnchorData>();
    public int selectedIndex = -1;

    public void AddAnchor(string label, GameObject anchorObject)
    {
        if (anchorObject == null) return;

        anchors.Add(new AnchorData(label, anchorObject.transform, anchorObject));

        selectedIndex = anchors.Count - 1;
        UpdateAnchorVisibility();

        Debug.Log("Anchor added: " + label);
    }

    public void RenameSelectedAnchor(string newLabel)
    {
        AnchorData selected = GetSelectedAnchor();
        if (selected == null) return;

        selected.label = newLabel;
        Debug.Log("Selected anchor renamed to: " + newLabel);
    }

    public void DeleteSelectedAnchor()
    {
        if (selectedIndex < 0 || selectedIndex >= anchors.Count) return;

        AnchorData data = anchors[selectedIndex];

        if (data.anchorObject != null)
            Destroy(data.anchorObject);

        anchors.RemoveAt(selectedIndex);

        if (anchors.Count == 0)
            selectedIndex = -1;
        else if (selectedIndex >= anchors.Count)
            selectedIndex = anchors.Count - 1;

        UpdateAnchorVisibility();
    }

    public AnchorData GetSelectedAnchor()
    {
        if (selectedIndex < 0 || selectedIndex >= anchors.Count) return null;
        return anchors[selectedIndex];
    }

    public void MoveSelectionUp()
    {
        if (anchors.Count == 0) return;
        selectedIndex = Mathf.Max(0, selectedIndex - 1);
        UpdateAnchorVisibility();
    }

    public void MoveSelectionDown()
    {
        if (anchors.Count == 0) return;
        selectedIndex = Mathf.Min(anchors.Count - 1, selectedIndex + 1);
        UpdateAnchorVisibility();
    }

    public void UpdateAnchorVisibility()
    {
        for (int i = 0; i < anchors.Count; i++)
        {
            if (anchors[i].anchorObject != null)
            {
                anchors[i].anchorObject.SetActive(i == selectedIndex);
            }
        }
    }

    public void RenameAnchor(AnchorData anchor, string newLabel)
    {
        if (anchor == null) return;
        anchor.label = newLabel;
    }

    public void SelectAnchor(AnchorData anchor)
    {
        if (anchor == null) return;

        int index = anchors.IndexOf(anchor);
        if (index >= 0)
        {
            selectedIndex = index;
            UpdateAnchorVisibility();
        }
    }
}