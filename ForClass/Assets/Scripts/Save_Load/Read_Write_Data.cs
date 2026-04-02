using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Read_Write_Data
{
    private string SavePath => Path.Combine(Application.persistentDataPath, "saved.json");
    //將data寫成json存入path
    
    public void write_json(RankDataEntity data)
    {
        //先讀取現有資料
        Rank_Data currentData = read_json();

        //加入新資料
        if (currentData == null) currentData = new Rank_Data();
        currentData.rankDataEntities = AddRankData(currentData.rankDataEntities, data);
        //轉成 JSON 並存檔
        string json = JsonUtility.ToJson(currentData, true);
        string encryptedJson = AES_Encryption.Encrypt(json);
        try
        {
            File.WriteAllText(SavePath, encryptedJson);
            Debug.Log($"Write complete: {SavePath}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Write fail: {e.Message}");
        }
    }

    private static List<RankDataEntity> AddRankData(List<RankDataEntity> entities, RankDataEntity data)
    {
        if (entities == null) entities = new List<RankDataEntity>();
        entities.Add(data);
        return entities;
    }

    //將path中的json轉成Rank_Data回傳
    public Rank_Data read_json()
    {
        //檢查檔案是否存在
        if (!File.Exists(SavePath))
        {
            // 如果檔案不存在，直接回傳一個新的空物件
            return new Rank_Data(); 
        }

        try
        {
            string json = File.ReadAllText(SavePath);
            json = AES_Encryption.Decrypt(json);
            Rank_Data data = JsonUtility.FromJson<Rank_Data>(json);
            if (data == null) data = new Rank_Data();
            return data;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Read fail: {e.Message}");
            // 讀取失敗時，回傳空物件以防止遊戲崩潰
            return new Rank_Data(); 
        }
    }
    public void delete_json()
    {
        if (File.Exists(SavePath))
        {
            try
            {
                File.Delete(SavePath);
                Debug.Log($"Delete complete: {SavePath}");
            }
            catch (System.Exception e)
            {
                Debug.Log($"Delete fail: {e.Message}");
            }
        }
        else
        {
            Debug.Log($"Delete fail: File not found at {SavePath}");
        }
    }
}