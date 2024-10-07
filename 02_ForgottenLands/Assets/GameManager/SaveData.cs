using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveData
{
    private static string GetFilePath()
    {
        return Application.persistentDataPath + "/savegame.dat";
    }

    public static void SaveGameData(PlayerHealth player, List<EnemyHealth> enemies, PotionManager potionManager, List<Quest> allQuests, List<Quest> activeQuests, List<Quest> completedQuests, List<Quest> turnedInQuests, CurrencyManager currencyManager, RogueAttack rogueAttack, QuestStep questSteps, NPCQuestInteraction npcQuestInteraction, List<ChestInteraction> chestInteraction, AudioManager audioManager)
    {
        GameData data = new GameData(player, enemies, potionManager, allQuests, activeQuests, completedQuests, turnedInQuests, currencyManager, rogueAttack, questSteps, npcQuestInteraction, chestInteraction, audioManager);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(GetFilePath(), FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGameData()
    {
        string path = GetFilePath();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found.");
            return null;
        }
    }

    public static void DeleteSaveFile()
    {
        string path = GetFilePath();
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save file deleted.");
        }
        else
        {
            Debug.LogWarning("No save file found to delete.");
        }
    }

}
