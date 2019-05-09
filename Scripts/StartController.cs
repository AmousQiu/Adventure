using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public GameObject gameScene, startScene,gameOverScene,winScene;
    public Text startHeading, buttonText;
    //public MainController mainController;
    private DataController dataController;
    private GameData gameData;
    private StartSceneData startSceneData;
    private string startSceneHeadingString, buttonTextString;


    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        gameData = dataController.GetGameData();
        
        //Debug.Log("Problem Here 1");
        //gameData = mainController.GetGameData();
        startSceneData = gameData.startSceneData;
        //Debug.Log("satrt scene set active in StartController");

        buttonTextString = startSceneData.buttonText;
        startSceneHeadingString = startSceneData.gameTitle;
        FillTexts();
        Debug.Log("1 is working");
        startScene.SetActive(true);
        gameScene.SetActive(false);
        gameOverScene.SetActive(false);
        winScene.SetActive(false);
    }
    private void FillTexts()
    {
        buttonText.text = buttonTextString;
        startHeading.text = startSceneHeadingString;
    }

    public void TapToContinueClick()
    {
        Debug.Log("2 is working");
        startScene.SetActive(false);
        gameScene.SetActive(true);
        gameOverScene.SetActive(false);
    }
}

