using UnityEngine;
using System;
public class CharacterStatusManager : MonoBehaviour
{
    public CharacterManager character;

    [Header("Player Stats")]
    public bool isDead = false;
    [SerializeField] private int _endurance = 10;
    public int endurance
    {
        get => _endurance;
        set
        {
            if (_endurance != value)
            {
                _endurance = value;
                OnEnduranceChanged?.Invoke(_endurance);
            }
        }
    }

    [SerializeField] private int _vitality = 15;
    public int vitality
    {
        get => _vitality;
        set
        {
            if (_vitality != value)
            {
                _vitality = value;
                Debug.Log($"OnVitalityChanged invoked with value: {_vitality}");
                OnVitalityChanged?.Invoke(_vitality);
            }
        }
    }

    [SerializeField] private float _currentStamina = 0;
    public float currentStamina
    {
        get => _currentStamina;
        set
        {
            if (_currentStamina == value) return;
            _currentStamina = value;
            OnCurrentStaminaChanged?.Invoke(_currentStamina);
        }
    }

   [SerializeField] private int _currentHealth = 0;
    public int currentHealth
    {
        get => _currentHealth;
        set
        {
            if (_currentHealth == value) return;
            _currentHealth = value;
            OnCurrentHealthChanged?.Invoke(_currentHealth);
        }
    }

    public int maxStamina;
    public int maxHealth;
    public float staminaRegenerationTimer = 0f;
    public float staminaRegenerationDelay = 2f;
    public float staminaTickTimer = 0f;

    public event Action<int> OnEnduranceChanged;
    public event Action<int> OnVitalityChanged;

    public event Action<float> OnCurrentStaminaChanged;
    public event Action<int> OnCurrentHealthChanged;


    protected virtual void Awake()
    {
        this.character = GetComponent<CharacterManager>();
    }
    protected virtual void Start()
    {

    }
    
    public void CheckHP(int healthValue)
    {
        if (this.currentHealth <= 0 && !this.isDead)
        {
            StartCoroutine(this.character.ProcessDeathEvent());
        }

        if(this.currentHealth > this.maxHealth)
        {
            this.currentHealth = this.maxHealth;
        }
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

    public int CaculateHealthBasedOnVitalityLevel(int vitality)
    {
        float health;
        health = vitality * 15;
        return Mathf.RoundToInt(health);
    }
    public void SetNewMaxStaminaValue(int newEndurance)
    {
        this.maxStamina = this.CaculateStaminaBasedOnEnduranceLevel(newEndurance);
        PlayerUIManger.instance.hudManager.SetMaxStaminaValue(this.maxStamina);
        this.currentStamina = this.maxStamina;
       
    }
    public void SetNewMaxHealthValue(int newVitality)
    {
        this.maxHealth = this.CaculateHealthBasedOnVitalityLevel(newVitality);
        PlayerUIManger.instance.hudManager.SetMaxHealthValue(this.maxHealth);
        this.currentHealth = this.maxHealth;
    }

    private void OnValidate()
    {
        // Gọi event khi giá trị thay đổi từ Inspector
        OnVitalityChanged?.Invoke(_vitality);
        OnEnduranceChanged?.Invoke(_endurance);
    }
}
