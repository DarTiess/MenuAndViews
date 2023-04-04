using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBlock : MonoBehaviour
{

    public string levelNumber;
    public int starsCount;
    public List<Image> starsImages;
    public TextMeshProUGUI levelText;

    private void Start()
    {
        levelText.text = levelNumber;
        for (int i = 0; i < starsCount; i++)
        {
            starsImages[i].color=Color.yellow;
            
        }
    }
}