using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveProgressBar : MonoBehaviour
{
    public Slider slider;
    public int enemiesKilled;
    

    public void WaveProgress()
    {
        slider.value = enemiesKilled; 
    }
}
