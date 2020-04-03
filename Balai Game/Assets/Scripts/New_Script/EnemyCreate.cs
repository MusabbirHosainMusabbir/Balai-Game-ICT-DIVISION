using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject TheEnemy;
    [HideInInspector]
    public int xpos;
    [HideInInspector]
    public int zpos;
    public int Enemycount;
    public float EnemyCreateTime = 1f;

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
        while (Enemycount < 2)
        {
            xpos = Random.Range(-16,-31);
            zpos = Random.Range(90,107);
            Instantiate(TheEnemy, new Vector3(xpos, 5f, zpos), Quaternion.identity);
            yield return new WaitForSeconds(EnemyCreateTime);
            Enemycount += 1;
        }
    }
}
