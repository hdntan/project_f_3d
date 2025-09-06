using UnityEngine;
using System.IO;
using System;
using UnityEngine.TextCore.Text;

public class SaveFileDataWriter 
{
    public string saveDataDirectoryPath = "";
    public string saveFileName = "";

    public bool CheckToSeeIfSaveFileExists()
    {
        string fullPath = Path.Combine(saveDataDirectoryPath, saveFileName);
        return File.Exists(fullPath);
    }

    public void DeleteSaveFile()
    {
        string fullPath = Path.Combine(saveDataDirectoryPath, saveFileName);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            Debug.Log("Save file deleted: " + fullPath);
        }
        else
        {
            Debug.LogWarning("No save file found to delete at: " + fullPath);
        }
    }

    public void CreateNewCharacterSaceFile(CharacterSaveData characterData)
    {
        string savePath = Path.Combine(saveDataDirectoryPath, saveFileName);
        try
        {
            // create directory if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(savePath));
            Debug.Log("Directory created or already exists at: " + Path.GetDirectoryName(savePath));
            //serialize characterData to JSON
            string dataToStore = JsonUtility.ToJson(characterData, true);
            //write JSON to file
            using (FileStream steam = new FileStream(savePath, FileMode.Create))
            {
                using (StreamWriter fileWriter = new StreamWriter(steam))
                {
                    fileWriter.Write(dataToStore);
                    Debug.Log("Save file created at: " + savePath);
                }
            }
        }

        catch (Exception e)
        {
            Debug.LogError("Failed to create save file: " + e.Message);
        }
    }

    public CharacterSaveData LoadCharacterSaveFile()
    {
        string loadPath = Path.Combine(saveDataDirectoryPath, saveFileName);
        if (!File.Exists(loadPath))
        {
         
            return null;
        }

        try
        {
            using (FileStream stream = new FileStream(loadPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string dataAsJson = reader.ReadToEnd();
                    CharacterSaveData characterData = JsonUtility.FromJson<CharacterSaveData>(dataAsJson);
                    Debug.Log("Save file loaded from: " + loadPath);
                    return characterData;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to load save file: " + e.Message);
            return null;
        }
    }
}
