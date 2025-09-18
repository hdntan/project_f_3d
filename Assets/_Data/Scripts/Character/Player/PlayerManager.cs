using NUnit.Framework;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : CharacterManager
{
    public PlayerLocomotionManager playerLocomotionManager;
    public PlayerAnimatorManager playerAnimatorManager;

    public PlayerStatsManager playerStatsManager;






    protected override void Awake()
    {
        base.Awake();
        this.playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        this.playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        this.playerStatsManager = GetComponent<PlayerStatsManager>();
        PlayerInputManager.instance.player = this;
        PlayerCamera.instance.player = this;
        WorldSaveGameManager.instance.player = this;



    }
    
    protected override void Start()
    {
        base.Start();
      
        this.PlayerUpdateUI();

    }

protected virtual void PlayerUpdateUI()
{
    this.playerStatsManager.OnVitalityChanged += this.playerStatsManager.SetNewMaxHealthValue;
    this.playerStatsManager.OnEnduranceChanged += this.playerStatsManager.SetNewMaxStaminaValue;

   
    
        this.playerStatsManager.OnCurrentStaminaChanged += PlayerUIManger.instance.hudManager.SetNewStaminaValue;
        this.playerStatsManager.OnCurrentHealthChanged += PlayerUIManger.instance.hudManager.SetNewHealthValue;
   
}


    protected override void Update()
    {
        base.Update();
        //handle player movement
        this.playerLocomotionManager.HandleAllMovement();
        this.playerStatsManager.RegenerateStamina();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        //handle camera movement
        PlayerCamera.instance.HandleAllCameraAction();
    }

    public void SaveGameDataToCurrentCharacterData(ref CharacterSaveData currentCharacterData)
    {
        currentCharacterData.sceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentCharacterData.characterName = this.characterName;
        currentCharacterData.yPosition = this.transform.position.y;
        currentCharacterData.xPosition = this.transform.position.x;
        currentCharacterData.zPosition = this.transform.position.z;


        currentCharacterData.currentHealth = this.playerStatsManager.currentHealth;
        currentCharacterData.currentStamina = this.playerStatsManager.currentStamina;

        currentCharacterData.vitality = this.playerStatsManager.vitality;
        currentCharacterData.endurance = this.playerStatsManager.endurance;
        Debug.Log("Save Game Data To Current Character Data");

    }

    public void LoadGameDataFromCurrentCharacterData(ref CharacterSaveData currentCharacterData)
    {
        this.characterName = currentCharacterData.characterName;
        Vector3 position = new Vector3(currentCharacterData.xPosition, currentCharacterData.yPosition, currentCharacterData.zPosition);
        this.transform.position = position;

        this.playerStatsManager.vitality = currentCharacterData.vitality;
        this.playerStatsManager.endurance = currentCharacterData.endurance;



        this.playerStatsManager.maxStamina = this.playerStatsManager.CaculateStaminaBasedOnEnduranceLevel(this.playerStatsManager.endurance);
        this.playerStatsManager.maxHealth = this.playerStatsManager.CaculateHealthBasedOnVitalityLevel(this.playerStatsManager.vitality);

        this.playerStatsManager.currentHealth = currentCharacterData.currentHealth;
        this.playerStatsManager.currentStamina = currentCharacterData.currentStamina;
        PlayerUIManger.instance.hudManager.SetMaxHealthValue(this.playerStatsManager.maxHealth);
       PlayerUIManger.instance.hudManager.SetMaxStaminaValue(this.playerStatsManager.maxStamina);
        Debug.Log("Save Game Data To Current Character Data");
       
        // this.playerStatsManager.currentStamina = this.playerStatsManager.maxStamina;
        // PlayerUIManger.instance.hudManager.SetMaxStaminaValue(this.playerStatsManager.maxStamina);
        // PlayerUIManger.instance.hudManager.SetNewStaminaValue(this.playerStatsManager.currentStamina);



        // this.playerStatsManager.currentHealth = this.playerStatsManager.maxHealth;
        // PlayerUIManger.instance.hudManager.SetMaxHealthValue(this.playerStatsManager.maxHealth);
        // PlayerUIManger.instance.hudManager.SetNewHealthValue(this.playerStatsManager.currentHealth);

    }

    // public override void OnNetworkSpawn()
    // {
    //     base.OnNetworkSpawn();

    //     if (IsOwner)
    //     {
    //         PlayerInputManager.instance.player = this;
    //         PlayerCamera.instance.player = this;


    //         this.maxStamina = this.playerStatsManager.CaculateStaminaBasedOnEnduranceLevel(this.endurance);
    //         this.currentStamina = this.maxStamina;
    //         PlayerUIManger.instance.hudManager.SetMaxStaminaValue(this.maxStamina);
    //         PlayerUIManger.instance.hudManager.SetNewStaminaValue(this.currentStamina);



    //     }

    // }

}
