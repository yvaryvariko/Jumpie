using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public Transform playerTransform;

    void Update()
    {
        float score = playerTransform.transform.position.y * 10;

        scoreText.text = Mathf.RoundToInt(score).ToString();
    }
}
