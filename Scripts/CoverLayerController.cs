using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverLayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController player;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        float alphalevel = player.wickHitCount / 7;
        GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.8f - alphalevel);
       
    }
}
