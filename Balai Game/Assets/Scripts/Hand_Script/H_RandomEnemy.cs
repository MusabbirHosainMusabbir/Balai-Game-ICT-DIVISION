using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_RandomEnemy : MonoBehaviour
{
    public GameObject TheEnemy;
    public int xpos;
    public int zpos;
    public int EnemyCount;
    public float EnemyCreateTime = 3f;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyDrop()
    {
        while(EnemyCount < 15)
        {
            xpos = Random.Range(-40, 120);
            zpos = Random.Range(119, 141);
            Instantiate(TheEnemy, new Vector3(xpos, 9f, zpos), Quaternion.identity);
            yield return new WaitForSeconds(EnemyCreateTime);
            EnemyCount += 1;
        }
    }
}
