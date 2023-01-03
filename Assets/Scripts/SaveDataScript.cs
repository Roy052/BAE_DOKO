using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class CheeseData
{
    public int cheese;
    public int[] upgradeList = new int[5];

    public CheeseData()
    {
        cheese = 0;
        upgradeList = new int[5] { 0, 0, 0, 0, 0 };
    }

    public CheeseData(CheeseData cheeseData)
    {
        this.cheese = cheeseData.cheese;
        for (int i = 0; i < 5; i++)
            this.upgradeList[i] = cheeseData.upgradeList[i];
    }

    public CheeseData(int cheese, int[] upgradeList)
    {
        this.cheese = cheese;
        for (int i = 0; i < 5; i++)
            this.upgradeList[i] = upgradeList[i];
    }
}
public class SaveDataScript : MonoBehaviour
{
    static public void CreateSaveData()
    {
        CheeseData saveData = new CheeseData();
        string save = JsonUtility.ToJson(saveData);
        //Debug.Log(save);
        File.WriteAllText("./Assets/Save/" + "SaveData.json", save);
    }

    static public void SaveIntoJson(CheeseData cheeseData)
    {
        CheeseData saveData = new CheeseData(cheeseData);
        string save = JsonUtility.ToJson(saveData);
        //Debug.Log(save);
        File.WriteAllText("./Assets/Save/" + "SaveData.json", save);
    }

    static public void SaveIntoJson(int cheese, int[] upgradeList)
    {
        CheeseData saveData = new CheeseData(cheese, upgradeList);
        string save = JsonUtility.ToJson(saveData);
        //Debug.Log(save);
        File.WriteAllText("./Assets/Save/" + "SaveData.json", save);
    }

    static public CheeseData LoadFromJson()
    {
        try
        {
            string path = "./Assets/Save/SaveData.json";
            //Debug.Log(path);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                //Debug.Log(json);
                CheeseData cd = JsonUtility.FromJson<CheeseData>(json);
                return cd;
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
        return default;
    }

    static public void DeleteSave()
    {
        try
        {
            string path = "./Assets/Save/SaveData.json";
            //Debug.Log(path);
            if (File.Exists(path))
            {
                File.Delete(path);
                SaveDataScript.RefreshEditor();
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
    }
    static public void RefreshEditor()
    {
        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        #endif
    }
}
