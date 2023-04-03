using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public int PlayerGold = 100;
    public float GrowthRate = 0.8f;

    public Text GoldText;

    void AddGold()
    {
        PlayerGold += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("AddGold", 0.2f, GrowthRate);
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = PlayerGold.ToString();
    }
}
