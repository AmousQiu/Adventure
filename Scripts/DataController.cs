using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Networking;

public class DataController : MonoBehaviour
{

    private GameData gameData;

    //Start() ensures our DataController is not destroyed when scenes change. Hence the scene name "Persistent".
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadGameData();
        SceneManager.LoadScene(gameData.firstScene);
    }

    public GameData GetGameData()
    {
        return gameData;
    }


    /*
     * LoadGameData() writes file path, if the file exists it copies its contents into a string.  
       Then JsonUtility converts this string into a GameData object.*/

    private void LoadGameData()
    {
        string filePath = Application.streamingAssetsPath + "/data.json";
        string dataAsJson = "";

        if (Application.platform == RuntimePlatform.Android)
        {
            UnityWebRequest www = UnityWebRequest.Get(filePath);
            www.SendWebRequest();
            while (!www.isDone)
            {
            }
            if (string.IsNullOrEmpty(www.error))
            {
                dataAsJson = www.downloadHandler.text;
                gameData = JsonUtility.FromJson<GameData>(dataAsJson);
            }
            else
            {
                Debug.LogError(www.error);
            }
        }
        else
        {
            if (File.Exists(filePath))
            {
                dataAsJson = File.ReadAllText(filePath);
                gameData = JsonUtility.FromJson<GameData>(dataAsJson);
            }
            else
                Debug.Log("No such file!");
        }

    }
}
