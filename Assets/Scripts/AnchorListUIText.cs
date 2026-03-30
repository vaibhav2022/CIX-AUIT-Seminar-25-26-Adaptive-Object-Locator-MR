using System.Text;
using TMPro;
using UnityEngine;

public class AnchorListUIText : MonoBehaviour
{
    public AnchorManager anchorManager;
    public TextMeshProUGUI listText;

    void Update()
    {
        RefreshText();
    }

    public void RefreshText()
    {
        if (anchorManager == null || listText == null) return;

        StringBuilder sb = new StringBuilder();
        // sb.AppendLine("Saved Anchors");
        sb.AppendLine();

        if (anchorManager.anchors.Count == 0)
        {
            sb.AppendLine("No anchors saved");
        }
        else
        {
            for (int i = 0; i < anchorManager.anchors.Count; i++)
            {
                string prefix = (i == anchorManager.selectedIndex) ? "> " : "  ";
                sb.AppendLine(prefix + anchorManager.anchors[i].label);
            }
        }

        listText.text = sb.ToString();
    }
}