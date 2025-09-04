using UnityEngine;

public class PlayerUIHudManager : MonoBehaviour
{
       public UI_StatBar staminaBar;

    public void SetNewStaminaValue(float newStamina)
    {
        this.staminaBar.SetStat(Mathf.RoundToInt(newStamina));
    }
    
    public void SetMaxStaminaValue(int maxStamina)
    {
        this.staminaBar.SetMaxStat(maxStamina);
    }
}
