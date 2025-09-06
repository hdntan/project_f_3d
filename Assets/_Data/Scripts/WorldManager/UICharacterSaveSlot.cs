using TMPro;
using UnityEngine;

public class UICharacterSaveSlot : MonoBehaviour
{
    SaveFileDataWriter saveFileWriter;

    [Header("Game Slot")]
    public CharacterSlot characterSlot;

    [Header("Character Info")]
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI timePlayed;

    private void OnEnable()
    {
        this.LoadSaveSlot();
    }

    private void LoadSaveSlot()
    {
        this.saveFileWriter = new SaveFileDataWriter();
        this.saveFileWriter.saveDataDirectoryPath = Application.persistentDataPath;

        if (this.characterSlot == CharacterSlot.CharacterSlot_01)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_01.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (this.characterSlot == CharacterSlot.CharacterSlot_02)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_02.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (this.characterSlot == CharacterSlot.CharacterSlot_03)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_03.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (this.characterSlot == CharacterSlot.CharacterSlot_04)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_04.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (this.characterSlot == CharacterSlot.CharacterSlot_05)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_05.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (this.characterSlot == CharacterSlot.CharacterSlot_06)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_06.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (this.characterSlot == CharacterSlot.CharacterSlot_07)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_07.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (this.characterSlot == CharacterSlot.CharacterSlot_08)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_08.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (this.characterSlot == CharacterSlot.CharacterSlot_09)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_09.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (this.characterSlot == CharacterSlot.CharacterSlot_10)
        {
            this.saveFileWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(this.characterSlot);
            if (this.saveFileWriter.CheckToSeeIfSaveFileExists())
            {
                this.characterName.text = WorldSaveGameManager.instance.characterSlot_10.characterName;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

    }
}
