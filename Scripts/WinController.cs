using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public Text winHeading, buttonText;
    public GameObject winScene, startScene;
    //public MainController mainController;
    private GameData gameData;
    private WinSceneData winSceneData;
    private string winSceneHeadingString, buttonTextString;
    public DataController dataController;

    void Start()
    {
        //gameData = mainController.GetGameData();
        dataController = FindObjectOfType<DataController>();
        gameData = dataController.GetGameData();
        winSceneData = gameData.winSceneData;

        buttonTextString = winSceneData.buttonText;
        winSceneHeadingString = winSceneData.winSceneHeading;
        FillTexts();
    }

    private void FillTexts()
    {
        buttonText.text = buttonTextString;
        winHeading.text = winSceneHeadingString;
    }

    public void TapToContinueClick()
    {
        winScene.SetActive(false);
        startScene.SetActive(true);
    }
}


