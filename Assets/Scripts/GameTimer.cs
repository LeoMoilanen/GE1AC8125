using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Text gameTimeText;
    [SerializeField] private float timer;
    [SerializeField] private GameObject waveSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waveSpawner.GetComponent<WaveSpawner>().gameWon == false)
        {
            timer += Time.deltaTime;
            gameTimeText.text = timer.ToString();
        }
    }
}
