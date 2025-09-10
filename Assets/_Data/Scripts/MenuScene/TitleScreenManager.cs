using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public static TitleScreenManager instance;
    public GameObject titleScreenMainMenu;
    public GameObject titleScreenLoadMenu;

    public Button loadMenuReturnButton;
    public Button mainMenuLoadGameButton;
    public Button mainMenuNewGameButton;


    public GameObject noCharacterSlotsPopUp;
    public Button noCharacterSlotsOkayButton;

    public GameObject deleteCharacterSlotPopUp;
    public Button deleteCharacterSlotConfirmButton;

    [Header("Character Slot")]
    public CharacterSlot currentCharacterSlot = CharacterSlot.NO_SLOT;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartNetworkAsHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void StartNewGame()
    {
        WorldSaveGameManager.instance.AttemptToCreateNewGame();

    }

    public void OpenLoadGameMenu()
    {
        //close
        this.titleScreenMainMenu.SetActive(false);
        //open
        this.titleScreenLoadMenu.SetActive(true);

        this.loadMenuReturnButton.Select();
    }

    public void CloseLoadGameMenu()
    {
        //close
        this.titleScreenMainMenu.SetActive(true);
        //open
        this.titleScreenLoadMenu.SetActive(false);

        this.mainMenuLoadGameButton.Select();
    }

    public void DisplayNoFreeCharacterSlotsPopUp()
    {
        this.noCharacterSlotsPopUp.SetActive(true);
        this.noCharacterSlotsOkayButton.Select();
    }

    public void CloseNoFreeCharacterSlotsPopUp()
    {
        this.noCharacterSlotsPopUp.SetActive(false);
        this.mainMenuNewGameButton.Select();
    }

    public void SelectCharacterSlot(CharacterSlot characterSlot)
    {
        this.currentCharacterSlot = characterSlot;
    }

    public void SelectNoSlot()
    {
        this.currentCharacterSlot = CharacterSlot.NO_SLOT;
    }

    public void AttemptToDeleteCharacterSlot()
    {
        if (this.currentCharacterSlot != CharacterSlot.NO_SLOT)
        {
            this.deleteCharacterSlotPopUp.SetActive(true);
            this.deleteCharacterSlotConfirmButton.Select();
        }
    }

    public void DeleteCharacterSlotConfirm()
    {
        this.deleteCharacterSlotPopUp.SetActive(false);
        WorldSaveGameManager.instance.DeleteSlotSaveGame(this.currentCharacterSlot);
        //disable & enable for reload character menu
        this.titleScreenLoadMenu.SetActive(false);
        this.titleScreenLoadMenu.SetActive(true);

        this.loadMenuReturnButton.Select();
    }

    public void CloseDeleteCharacterSlotPopUp()
    {
        this.deleteCharacterSlotPopUp.SetActive(false);
        this.loadMenuReturnButton.Select();
    }
}
