using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class LinkHandler : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI linkText;

    void Start()
    {
        linkText = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Cek link mana yang ditekan berdasarkan posisi mouse/sentuhan
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(linkText, eventData.position, null);
        
        if (linkIndex != -1) // -1 berarti tidak ada link yang ditekan
        {
            TMP_LinkInfo linkInfo = linkText.textInfo.linkInfo[linkIndex];
            
            // Buka URL di browser
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}