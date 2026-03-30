using TMPro;
using UnityEngine;

public class AnchorMenuUI : MonoBehaviour
{
    public AnchorManager anchorManager;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI row0Text;
    public TextMeshProUGUI row1Text;
    public TextMeshProUGUI row2Text;
    public TextMeshProUGUI row3Text;

    private TextMeshProUGUI[] rows;
    private Coroutine messageCoroutine;

    void Awake()
    {
        rows = new TextMeshProUGUI[] { row0Text, row1Text, row2Text, row3Text };
    }

    void Update()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (titleText != null && messageCoroutine == null)
            titleText.text = "Saved Anchors";

        if (anchorManager == null || rows == null) return;

        for (int i = 0; i < rows.Length; i++)
        {
            if (rows[i] == null) continue;

            if (i < anchorManager.anchors.Count)
            {
                string label = anchorManager.anchors[i].label;

                if (i == anchorManager.selectedIndex)
                {
                    rows[i].text = $"<b><color=#FFFFFF>> {label}</color></b>";
                }
                else
                {
                    rows[i].text = $"<color=#AAAAAA>  {label}</color>";
                }
            }
            else
            {
                rows[i].text = "";
            }
        }
    }

    public void ShowTemporaryMessage(string message, float duration = 1f)
    {
        if (messageCoroutine != null)
            StopCoroutine(messageCoroutine);

        messageCoroutine = StartCoroutine(ShowMessageRoutine(message, duration));
    }

    private System.Collections.IEnumerator ShowMessageRoutine(string message, float duration)
    {
        if (titleText != null)
            titleText.text = message;

        yield return new WaitForSeconds(duration);

        if (titleText != null)
            titleText.text = "Saved Anchors";

        messageCoroutine = null;
    }
}