using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoBubbleBehaviour : MonoBehaviour
{
    [SerializeField] private float bubbleDuration;

    private void Awake()
    {
        StartCoroutine(BubbleLifeTime());
    }

    IEnumerator BubbleLifeTime()
    {
        yield return new WaitForSeconds(bubbleDuration);
        Destroy(gameObject);
    }
}
