using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSaveGameManager : MonoBehaviour
{
    public static WorldSaveGameManager instance;

    public PlayerManager player;

    [SerializeField] public int worldSceneIndex = 1;
   
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

    public IEnumerator LoadNewCharacterWorlScene()
    {
        //if u just want 1 world scene use this
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(this.worldSceneIndex);

        // if u want to use different scenes for levels in your project use this
        //AsyncOperation loadOperation = SceneManager.LoadSceneAsync(this.currentCharacterData.sceneIndex);

        this.player.CreateNewDataFromCurrentCharacterData(ref this.currentCharacterData);
        yield return null;
    }

        public IEnumerator LoadWorldScene()
    {
        //if u just want 1 world scene use this
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(this.worldSceneIndex);

        // if u want to use different scenes for levels in your project use this
        //AsyncOperation loadOperation = SceneManager.LoadSceneAsync(this.currentCharacterData.sceneIndex);

        this.player.LoadGameDataFromCurrentCharacterData(ref this.currentCharacterData);
        yield return null;
    }



    public void AttemptToCreateNewGame()
    {
        this.saveGameDataWriter = new SaveFileDataWriter();
        this.saveGameDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_01);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_01;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 1");
            this.NewGame();
            return;
        }

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_02);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_02;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 2");
            this.NewGame();
            return;
        }

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_03);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_03;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 3");
          this.NewGame();
            return;
        }

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_04);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_04;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 4");
           this.NewGame();
            return;
        }

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_05);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_05;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 5");
            this.NewGame();
            return;
        }

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_06);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_06;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 6");
         this.NewGame();
            return;
        }

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_07);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_07;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 7");
           this.NewGame();
            return;
        }

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_08);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_08;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 8");
            this.NewGame();
            return;
        }

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_09);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_09;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 9");
         this.NewGame();
            return;
        }

        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot.CharacterSlot_10);
        if (!saveGameDataWriter.CheckToSeeIfSaveFileExists())
        {
            this.currentCharacterSlotBeingUsed = CharacterSlot.CharacterSlot_10;
            this.currentCharacterData = new CharacterSaveData();
            Debug.Log("New Game Created 10");
           this.NewGame();
            return;
        }

        TitleScreenManager.instance.DisplayNoFreeCharacterSlotsPopUp();

    }

    public void DeleteSlotSaveGame(CharacterSlot characterSlot)
    {
   
        this.saveGameDataWriter = new SaveFileDataWriter();
        this.saveGameDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
        this.saveGameDataWriter.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);;
        this.saveGameDataWriter.DeleteSaveFile();
    }

    public void LoadGame()
    {
        this.saveFileName = this.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.currentCharacterSlotBeingUsed);
        this.saveGameDataWriter = new SaveFileDataWriter();
        this.saveGameDataWriter.saveDataDirectoryPath = Application.persistentDataPath;
        this.saveGameDataWriter.saveFileName = this.saveFileName;
        this.currentCharacterData = this.saveGameDataWriter.LoadCharacterSaveFile();

        StartCoroutine(this.LoadWorldScene());
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

    public void NewGame()
    {
        //save new game data
        this.SaveGame();
        StartCoroutine(this.LoadNewCharacterWorlScene());
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


    public string DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(CharacterSlot characterSlot)
    {
        string fileName = "";
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


}
