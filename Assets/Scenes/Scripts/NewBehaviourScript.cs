using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharactersSortingOrder : MonoBehaviour
{
    private List<SpriteRenderer> characters;

    private void Start()
    {
        characters = new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>());
    }

    private void Update()
    {
        SortCharactersByYPosition();
    }

    private void SortCharactersByYPosition()
    {
        characters.Sort((a, b) => (int)(a.transform.position.y - b.transform.position.y));
        int currentSortingOrder = 0;
        foreach (var character in characters)
        {
            character.sortingOrder = currentSortingOrder;
            currentSortingOrder++;
        }
    }
}

