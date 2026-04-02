using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Save_LoadPlayerPref : MonoBehaviour
{
    private string PlayerNameKey="PlayerName";
    private string PlayerScoreKey="PlayerScore";

    private void EnsureKeys()
    {
        if (string.IsNullOrWhiteSpace(PlayerNameKey)) PlayerNameKey = "PlayerName";
        if (string.IsNullOrWhiteSpace(PlayerScoreKey)) PlayerScoreKey = "PlayerScore";
    }

    public void Save(GameObject ScoreBoard)
    {
        EnsureKeys();
        string playerName = ScoreBoard.GetComponent<TextMeshProUGUI>().text;
        int score = Random.Range(0, 1000); // Set the score as needed
        PlayerPrefs.SetString(PlayerNameKey, playerName);
        PlayerPrefs.SetInt(PlayerScoreKey, score);
        PlayerPrefs.Save();
        Debug.Log($"Saved: {playerName} with score {score}");
    }

    public void Load()
    {
        EnsureKeys();
        string playerName = PlayerPrefs.GetString(PlayerNameKey, "Unknown");
        int score = PlayerPrefs.GetInt(PlayerScoreKey, 0);
        Debug.Log($"Loaded: {playerName} with score {score}");
    }
}
