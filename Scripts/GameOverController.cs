using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverScene, startScene;
    public Text gameOverHeading, buttonText;
    //public MainController mainController;
    private GameData gameData;
    private DataController dataController;
    private GameOverSceneData gameOverSceneData;
    private string gameOverSceneHeadingString, buttonTextString;


    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        gameData = dataController.GetGameData();
        gameOverSceneData = gameData.gameOverSceneData;
        buttonTextString = gameOverSceneData.buttonText;
        gameOverSceneHeadingString = gameOverSceneData.gameOverSceneHeading;
        FillTexts();
    }

    private void FillTexts()
    {
        buttonText.text = buttonTextString;
        gameOverHeading.text = gameOverSceneHeadingString;
    }

    public void TapToContinueClick()
    {
        gameOverScene.SetActive(false);
        startScene.SetActive(true);
    }
}

