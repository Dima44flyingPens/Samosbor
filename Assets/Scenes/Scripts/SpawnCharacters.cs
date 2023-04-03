using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacters : MonoBehaviour
{

    public GameObject characterPrefab; // префаб персонажа
    public Transform spawnPoint; // координаты, на которых будет инстанцирован персонаж
    public int cost;
    
    GameHelper gameHelper;

    public void OnClick() 
    {
        if (gameHelper.PlayerGold >= cost)
        {
            // Инстанцируем персонажа на заданных координатах
            GameObject newCharacter = Instantiate(characterPrefab, spawnPoint.position, Quaternion.identity);
            gameHelper.PlayerGold -= cost;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
