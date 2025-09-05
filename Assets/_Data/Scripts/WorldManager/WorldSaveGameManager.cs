using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSaveGameManager : MonoBehaviour
{
    public static WorldSaveGameManager instance;

    public PlayerManager player;

    [SerializeField] private int worldSceneIndex = 1;
    public int WorldSceneIndex => worldSceneIndex;
    [Header("Save/Load")]
    public bool saveGame;
    public bool loadGame;   

    [Header("Save Data Writer")]
    public SaveFileDataWriter saveGameDataWriter;

    [Header("Current Character Data")]
    public CharacterSaveData currentCharacterData;
    public CharacterSlot currentCharacterSlotBeingUsed;
    public string saveFileName;

    [Header("Character Slots")]

    public CharacterSaveData characterSlot_01;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (this.saveGame)
        {
            this.SaveGame();
            this.saveGame = false;
        }
        
        if (this.loadGame)
        {
            this.LoadGame();
            this.loadGame = false;
        }
    }

    public IEnumerator LoadWorldScene()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);
        yield return null;
    }

    private void DecideCharacterFileNameBasedOnCharacterSlotBeingUsed()
    {
        switch (this.currentCharacterSlotBeingUsed)
        {
            case CharacterSlot.CharacterSlot_01:
                this.saveFileName = "characterSlot_01";
                break;
            case CharacterSlot.CharacterSlot_02:
                this.saveFileName = "characterSlot_02";
                break;
            case CharacterSlot.CharacterSlot_03:
                this.saveFileName = "characterSlot_03";
                break;
            case CharacterSlot.CharacterSlot_04:
                this.saveFileName = "characterSlot_04";
                break;
            case CharacterSlot.CharacterSlot_05:
                this.saveFileName = "characterSlot_05";
                break;
            case CharacterSlot.CharacterSlot_06:
                this.saveFileName = "characterSlot_06";
                break;
            case CharacterSlot.CharacterSlot_07:
                this.saveFileName = "characterSlot_07";
                break;
            case CharacterSlot.CharacterSlot_08:
                saveFileName = "characterSlot_08";
                break;
            case CharacterSlot.CharacterSlot_09:
                this.saveFileName = "characterSlot_09";
                break;
            case CharacterSlot.CharacterSlot_10:
                this.saveFileName = "characterSlot_10";
                break;
            default:
                break;
        }
    }

    public void CreateNewGame()
    {
        this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed();
        this.currentCharacterData = new CharacterSaveData();
        Debug.Log("New Game Created");
    }

    public void LoadGame()
    {
        this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed();
        this.saveGameDataWriter = new SaveFileDataWriter();
        this.saveGameDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
        this.saveGameDataWriter.saveFileName = this.saveFileName;
        this.currentCharacterData = this.saveGameDataWriter.LoadCharacterSaveFile();

        StartCoroutine(LoadWorldScene());
    }

    public void SaveGame()
    {
        this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed();
        this.saveGameDataWriter = new SaveFileDataWriter();
        this.saveGameDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
        this.saveGameDataWriter.saveFileName = this.saveFileName;

        this.player.SaveGameDataToCurrentCharacterData(ref this.currentCharacterData);

        this.saveGameDataWriter.CreateNewCharacterSaceFile(this.currentCharacterData);
    }


}
