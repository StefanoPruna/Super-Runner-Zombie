using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Prefab;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);
    
    void Start()
    {
        ResetDelay();
        StartCoroutine(EnemyGenerator());
    }

    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);
        if (active)
        {
            var newTransform = transform;
            GameObjectUtil.Instantiate(Prefab[Random.Range(0, Prefab.Length)], newTransform.position);
            ResetDelay();
        }
    
    StartCoroutine(EnemyGenerator());
        
    }

    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }
}
