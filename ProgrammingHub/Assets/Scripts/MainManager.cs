using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public Dictionary<Player.Teams, CharacterCard> teamsToCharacters;
    public static MainManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        teamsToCharacters = new Dictionary<Player.Teams, CharacterCard>()
        {
            {Player.Teams.Circle, null },
            {Player.Teams.Cross, null }
        };

    }

    //public CharacterCard teamCard;
    //public CharacterCard anotherTeamCard;

    //private void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);

    //    LoadCards ();


    //}

    //[System.Serializable]
    //class SaveData
    //{
    //    public CharacterCard teamCard;
    //    public CharacterCard anotherTeamCard;

    //}
    //public void SaveCards()
    //{
    //    SaveData data = new SaveData();
    //    data.teamCard = teamCard;
    //    data.anotherTeamCard = anotherTeamCard;

    //    string json = JsonUtility.ToJson(data);

    //    File.WriteAllText(Application.persistentDataPath +
    //        "/savefile.json",
    //        json);
    //}

    //public void LoadCards()
    //{
    //    string path = Application.persistentDataPath +
    //        "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        teamCard = data.teamCard;
    //        anotherTeamCard = data.anotherTeamCard;
    //    }
    //}
}
