using TMPro;
using UnityEngine;
using System.IO;

public class Save_Load : MonoBehaviour
{
    private string SavePath => Path.Combine(Application.persistentDataPath, "saved.json");
    [SerializeField] GameObject inputField;
    public void Save()
    {
        RankDataEntity rank_Data = new RankDataEntity();
        rank_Data.playerName = inputField.GetComponent<TextMeshProUGUI>().text;
        rank_Data.score = Random.Range(0, 1000); // Set the score as needed
        Read_Write_Data tool = new Read_Write_Data();
        tool.write_json(rank_Data);
        Debug.Log($"Saved: {rank_Data.playerName} with score {rank_Data.score}");
    }
    public void Load()
    {
        Read_Write_Data tool = new Read_Write_Data();
        Rank_Data data = tool.read_json();
        foreach (var entity in data.rankDataEntities)
        {
            Debug.Log($"Player: {entity.playerName}, Score: {entity.score}");
        }
    }
}
