using UnityEngine;

public class CharacterStatusManager : MonoBehaviour
{
    public CharacterManager character;

    [Header("Player Stats")]
    public int endurance = 10;
    public int maxStamina;
    public float currentStamina = 0;

    public float staminaRegenerationTimer = 0f;
    public float staminaRegenerationDelay = 2f;
    public float staminaTickTimer = 0f;

    protected void Awake()
    {
        this.character = GetComponent<CharacterManager>();
    }
    public virtual void RegenerateStamina()
    {
        if (character.isPerformingAction) return;
        if (PlayerInputManager.instance.sprintInput) return;



        if (this.currentStamina < this.maxStamina)
        {
            Debug.Log("Regenerate Stamina");
            this.staminaRegenerationTimer += Time.deltaTime;
            if (this.staminaRegenerationTimer >= this.staminaRegenerationDelay)
            {
                this.staminaTickTimer += Time.deltaTime;
                if (this.staminaTickTimer >= 0.1f)
                {
                    this.currentStamina += 2;
                    this.currentStamina = Mathf.Clamp(this.currentStamina, 0, this.maxStamina);
                    this.staminaTickTimer = 0f;
                    PlayerUIManger.instance.hudManager.SetNewStaminaValue(this.currentStamina);
                }
            }
        }
        else
        {
            // Nếu đầy stamina, reset timer để lần sau phải chờ lại delay
            this.staminaRegenerationTimer = 0f;
            this.staminaTickTimer = 0f;
     
        }


    }
    public int CaculateStaminaBasedOnEnduranceLevel(int endurance)
    {
        float stamina;
        stamina = endurance * 10;
        return Mathf.RoundToInt(stamina);
    }
}
