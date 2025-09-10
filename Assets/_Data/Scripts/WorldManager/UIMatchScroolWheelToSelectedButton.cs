using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMatchScroolWheelToSelectedButton : MonoBehaviour
{
    [SerializeField] GameObject currentSelected;
    [SerializeField] GameObject previouslySelected;
    [SerializeField] RectTransform currentSelectedTransform;


    [SerializeField] RectTransform contentPanel;
    [SerializeField] ScrollRect scrollRect;

    private void Update()
    {
        this.currentSelected = EventSystem.current.currentSelectedGameObject;
        if (this.currentSelected != null)
        {
            if (this.currentSelected != this.previouslySelected)
            {
                this.previouslySelected = this.currentSelected;
                this.currentSelectedTransform = this.currentSelected.GetComponent<RectTransform>();
                this.SnapTo(this.currentSelectedTransform);
            }
        }
    }

    private void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();

        Vector2 newPosition =
        (Vector2)scrollRect.transform.InverseTransformPoint(this.contentPanel.position) - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);

        newPosition.x = 0;

        contentPanel.anchoredPosition = newPosition;
   
    }
}
