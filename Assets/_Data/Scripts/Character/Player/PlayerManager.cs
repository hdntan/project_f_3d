using NUnit.Framework;
using Unity.Collections;
using UnityEngine;

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
        this.PlayerSettings();


    }

    protected virtual void PlayerSettings()
    {
        PlayerInputManager.instance.player = this;
        PlayerCamera.instance.player = this;
        WorldSaveGameManager.instance.player = this;


        this.playerStatsManager.maxStamina = this.playerStatsManager.CaculateStaminaBasedOnEnduranceLevel(this.playerStatsManager.endurance);
        this.playerStatsManager.currentStamina = this.playerStatsManager.maxStamina;
        PlayerUIManger.instance.hudManager.SetMaxStaminaValue(this.playerStatsManager.maxStamina);
        PlayerUIManger.instance.hudManager.SetNewStaminaValue(this.playerStatsManager.currentStamina);
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
        currentCharacterData.CharacterName = this.characterName.ToString();
        currentCharacterData.yPosition = this.transform.position.y;
        currentCharacterData.xPosition = this.transform.position.x;
        currentCharacterData.zPosition = this.transform.position.z;

    }

    public void LoadGameDataFromCurrentCharacterData(CharacterSaveData currentCharacterData)
    {
        this.characterName = currentCharacterData.CharacterName;
        Vector3 position = new Vector3(currentCharacterData.xPosition, currentCharacterData.yPosition, currentCharacterData.zPosition);
        this.transform.position = position;

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
