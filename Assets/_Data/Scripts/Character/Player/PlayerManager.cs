using System.Collections;
using NUnit.Framework;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : CharacterManager
{
    public bool respawnCharacter = false;
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

    public override IEnumerator ProcessDeathEvent(bool manuallySelectDeathAnimation = false)
    {
         PlayerUIManger.instance.popUpManager.SendYouDiedPopUp();
      
        return base.ProcessDeathEvent(manuallySelectDeathAnimation);

       
    }

    

    protected virtual void PlayerUpdateUI()
    {
        this.playerStatsManager.OnVitalityChanged += this.playerStatsManager.SetNewMaxHealthValue;
        this.playerStatsManager.OnEnduranceChanged += this.playerStatsManager.SetNewMaxStaminaValue;



        this.playerStatsManager.OnCurrentStaminaChanged += PlayerUIManger.instance.hudManager.SetNewStaminaValue;
        this.playerStatsManager.OnCurrentHealthChanged += PlayerUIManger.instance.hudManager.SetNewHealthValue;
        this.playerStatsManager.OnCurrentHealthChanged += this.playerStatsManager.CheckHP;

    }


    protected override void Update()
    {
        base.Update();
        //handle player movement
        this.playerLocomotionManager.HandleAllMovement();
        this.playerStatsManager.RegenerateStamina();
        this.DebugMenu();
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
        Debug.Log("Current Health" + " " + currentCharacterData.currentHealth);
        Debug.Log("Current Stamina" + " " + currentCharacterData.currentStamina);

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


        PlayerUIManger.instance.hudManager.SetMaxStaminaValue(this.playerStatsManager.maxStamina);
        PlayerUIManger.instance.hudManager.SetMaxHealthValue(this.playerStatsManager.maxHealth);

        this.playerStatsManager.currentStamina = currentCharacterData.currentStamina;
        this.playerStatsManager.currentHealth = currentCharacterData.currentHealth;
     

        PlayerUIManger.instance.hudManager.SetNewStaminaValue(currentCharacterData.currentStamina);
        PlayerUIManger.instance.hudManager.SetNewHealthValue(currentCharacterData.currentHealth);
        Debug.Log("Current Health" + " " + currentCharacterData.currentHealth);
        Debug.Log("Current Stamina" + " " + currentCharacterData.currentStamina);
        Debug.Log("Save Game Data To Current Character Data");


    }

    public void CreateNewDataFromCurrentCharacterData(ref CharacterSaveData currentCharacterData)
    {
        this.characterName = currentCharacterData.characterName;
        Vector3 position = new Vector3(currentCharacterData.xPosition, currentCharacterData.yPosition, currentCharacterData.zPosition);
        this.transform.position = position;

        this.playerStatsManager.vitality = currentCharacterData.vitality;
        this.playerStatsManager.endurance = currentCharacterData.endurance;

        this.playerStatsManager.maxStamina = this.playerStatsManager.CaculateStaminaBasedOnEnduranceLevel(this.playerStatsManager.endurance);
        this.playerStatsManager.maxHealth = this.playerStatsManager.CaculateHealthBasedOnVitalityLevel(this.playerStatsManager.vitality);

        PlayerUIManger.instance.hudManager.SetMaxStaminaValue(this.playerStatsManager.maxStamina);
        PlayerUIManger.instance.hudManager.SetMaxHealthValue(this.playerStatsManager.maxHealth);

        this.playerStatsManager.currentStamina = this.playerStatsManager.CaculateStaminaBasedOnEnduranceLevel(this.playerStatsManager.endurance);
        this.playerStatsManager.currentHealth = this.playerStatsManager.CaculateHealthBasedOnVitalityLevel(this.playerStatsManager.vitality);

        PlayerUIManger.instance.hudManager.SetNewStaminaValue(this.playerStatsManager.currentStamina);
        PlayerUIManger.instance.hudManager.SetNewHealthValue(this.playerStatsManager.currentHealth);

        Debug.Log("Save Game Data New Current Character Data");

    }

    public override void ReviveCharacter()
    {
        base.ReviveCharacter();
        this.playerStatsManager.currentHealth = this.playerStatsManager.maxHealth;
        this.playerStatsManager.currentStamina = this.playerStatsManager.maxStamina;
        this.playerStatsManager.isDead = false;
        this.playerAnimatorManager.PlayTargetActionAnimation("Empty", false);
    
    }
    
    private void DebugMenu()
    {
        if(this.respawnCharacter)
        {
            this.respawnCharacter = false;
           
            this.ReviveCharacter();
        }
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
