using UnityEngine;
using UnityEngine.UI;

public class UI_StatBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private RectTransform rectTransform;

    [Header("UI Settings")]
    [SerializeField] protected bool scaleBarLengthWithStat = true;
    [SerializeField] protected float widthScaleMultiplier = 1f;

    protected virtual void Awake()
    {
        this.slider = GetComponent<Slider>();
        this.rectTransform = GetComponent<RectTransform>();
    }

    public virtual void SetStat(int newValue)
    {
        this.slider.value = newValue;
    }
    
    public virtual void SetMaxStat(int maxValue)
    {
        this.slider.maxValue = maxValue;
        this.slider.value = maxValue;
        if (this.scaleBarLengthWithStat)
        {
            this.rectTransform.sizeDelta = new Vector2(maxValue * this.widthScaleMultiplier, this.rectTransform.sizeDelta.y);
            PlayerUIManger.instance.hudManager.RefreshHUD();
        }
    }
    
      
    

}
