using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float gravityScaleFactor = 50f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().gravityScale += (Time.timeSinceLevelLoad *Time.deltaTime) / gravityScaleFactor;

        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
            GameObject score= GameObject.FindWithTag("Score");
            int scoreText = int.Parse(score.GetComponent<TextMeshProUGUI>().text);
            scoreText++;
            score.GetComponent<TextMeshProUGUI>().text = scoreText.ToString();
        }
    }
}
