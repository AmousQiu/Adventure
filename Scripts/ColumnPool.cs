using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int candlePoolSize = 11;
    public GameObject candlePrefab;
    public float spawnRate;
    public float candleMin = -1f;
    public float candleMax = 3.5f;

    private GameObject[] candles;
    private Vector2 objectPoolPosition = new Vector2(-100f, -10000f);
    private float timeSinceLastSpawn = 3.5f;
    private float spawnXPos = 75f;
    private int currentCandle = 0;
    public GameObject gameOverScene, gameScene;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentCandle = 0;
        candles = new GameObject[candlePoolSize];
        for (int i = 0; i < candlePoolSize; i++)
        {
            candles[i] = (GameObject)Instantiate(candlePrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < candlePoolSize; i++)
        {
            Destroy(candles[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPos = Random.Range(candleMin, candleMax);
            //Debug.Log("Current Candle is "+currentCandle);
            //Debug.Log("The size currently is " + candlePoolSize);
            candles[currentCandle].transform.position = new Vector2(spawnXPos, spawnYPos);
            GameObject wickObj = candles[currentCandle].transform.Find("Target").gameObject;
            GameObject LightObj = candles[currentCandle].transform.Find("light").gameObject;
            wickObj.GetComponent<Renderer>().material.color = Color.grey;
            LightObj.GetComponent<Renderer>().enabled = false;
            currentCandle++;
            if(currentCandle >= candlePoolSize)
            {
                gameScene.SetActive(false);
                gameOverScene.SetActive(true);
            }
        }
    }
}

