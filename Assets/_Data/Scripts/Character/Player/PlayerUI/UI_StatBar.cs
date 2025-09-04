using UnityEngine;
using UnityEngine.UI;

public class UI_StatBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    protected virtual void Awake()
    {
        this.slider = GetComponent<Slider>();
    }

    public virtual void SetStat(int newValue)
    {
        this.slider.value = newValue;
    }
    
    public virtual void SetMaxStat(int maxValue)
    {
        this.slider.maxValue = maxValue;
        this.slider.value = maxValue;
    }
    
      
    

}
