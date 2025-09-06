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
    public CharacterSaveData characterSlot_02;
    public CharacterSaveData characterSlot_03;
    public CharacterSaveData characterSlot_04;
    public CharacterSaveData characterSlot_05;
    public CharacterSaveData characterSlot_06;
    public CharacterSaveData characterSlot_07;
    public CharacterSaveData characterSlot_08;
    public CharacterSaveData characterSlot_09;
    public CharacterSaveData characterSlot_10;


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

    private void Start()
    {
        this.LoadAllCharacterProfile();
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

    public string DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot characterSlot)
    {
        string fileName= "";
        switch (characterSlot)
        {
            case CharacterSlot.CharacterSlot_01:
                fileName = "characterSlot_01";
                break;
            case CharacterSlot.CharacterSlot_02:
                fileName = "characterSlot_02";
                break;
            case CharacterSlot.CharacterSlot_03:
                fileName = "characterSlot_03";
                break;
            case CharacterSlot.CharacterSlot_04:
                fileName = "characterSlot_04";
                break;
            case CharacterSlot.CharacterSlot_05:
                fileName = "characterSlot_05";
                break;
            case CharacterSlot.CharacterSlot_06:
                fileName = "characterSlot_06";
                break;
            case CharacterSlot.CharacterSlot_07:
                fileName = "characterSlot_07";
                break;
            case CharacterSlot.CharacterSlot_08:
                fileName = "characterSlot_08";
                break;
            case CharacterSlot.CharacterSlot_09:
                fileName = "characterSlot_09";
                break;
            case CharacterSlot.CharacterSlot_10:
                fileName = "characterSlot_10";
                break;
            default:
                break;


        }
        return fileName;
    }

    public void CreateNewGame()
    {
        this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.currentCharacterSlotBeingUsed);
        this.currentCharacterData = new CharacterSaveData();
        Debug.Log("New Game Created");
    }

    public void LoadGame()
    {
        this.saveFileName =  this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.currentCharacterSlotBeingUsed);
        this.saveGameDataWriter = new SaveFileDataWriter();
        this.saveGameDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
        this.saveGameDataWriter.saveFileName = this.saveFileName;
        this.currentCharacterData = this.saveGameDataWriter.LoadCharacterSaveFile();

        StartCoroutine(LoadWorldScene());
    }

    private void LoadAllCharacterProfile()
    {
        this.saveGameDataWriter = new SaveFileDataWriter();
        this.saveGameDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
        Debug.Log("Load All Character");

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_01);
        this.characterSlot_01 = this.saveGameDataWriter.LoadCharacterSaveFile();

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_02);
        this.characterSlot_02 = this.saveGameDataWriter.LoadCharacterSaveFile();

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_03);
        this.characterSlot_03 = this.saveGameDataWriter.LoadCharacterSaveFile();

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_04);
        this.characterSlot_04 = this.saveGameDataWriter.LoadCharacterSaveFile();

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_05);
        this.characterSlot_05 = this.saveGameDataWriter.LoadCharacterSaveFile();

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_06);
        this.characterSlot_06 = this.saveGameDataWriter.LoadCharacterSaveFile();

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_07);
        this.characterSlot_07 = this.saveGameDataWriter.LoadCharacterSaveFile();

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_08);
        this.characterSlot_08 = this.saveGameDataWriter.LoadCharacterSaveFile();

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_09);
        this.characterSlot_09 = this.saveGameDataWriter.LoadCharacterSaveFile();

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_10);
        this.characterSlot_10 = this.saveGameDataWriter.LoadCharacterSaveFile();

        
    }

    public void SaveGame()
    {
        this.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.currentCharacterSlotBeingUsed);
        this.saveGameDataWriter = new SaveFileDataWriter();
        this.saveGameDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
        this.saveGameDataWriter.saveFileName = this.saveFileName;

        this.player.SaveGameDataToCurrentCharacterData(ref this.currentCharacterData);

        this.saveGameDataWriter.CreateNewCharacterSaceFile(this.currentCharacterData);
    }


}
