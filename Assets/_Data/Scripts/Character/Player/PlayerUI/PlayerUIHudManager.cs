using UnityEngine;

public class PlayerUIHudManager : MonoBehaviour
{
    public UI_StatBar healthBar;

    public UI_StatBar staminaBar;

    public void SetNewHealthValue(float newHealth)
    {
        this.healthBar.SetStat(Mathf.RoundToInt(newHealth));
    }

    public void SetMaxHealthValue(int maxHealth)
    {
        this.healthBar.SetMaxStat(maxHealth);
    }

    public void SetNewStaminaValue(float newStamina)
    {
        this.staminaBar.SetStat(Mathf.RoundToInt(newStamina));
    }

    public void SetMaxStaminaValue(int maxStamina)
    {
        this.staminaBar.SetMaxStat(maxStamina);
    }

    public void RefreshHUD()
    {
        this.healthBar.gameObject.SetActive(false);
        this.healthBar.gameObject.SetActive(true);
        this.staminaBar.gameObject.SetActive(false);
        this.staminaBar.gameObject.SetActive(true);

        
    }
}
