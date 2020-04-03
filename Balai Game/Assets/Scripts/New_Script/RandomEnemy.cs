using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour
{

    public GameObject TheEnemy;
    public int xpos;
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
        while (Enemycount < 15)
        {
            xpos = Random.Range(-40,45);
            zpos = Random.Range(115,118);
            Instantiate(TheEnemy, new Vector3(xpos, 5f, zpos), Quaternion.identity);
            yield return new WaitForSeconds(EnemyCreateTime);
            Enemycount += 1;
        }
    }
}
