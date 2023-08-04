using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Formation : MonoBehaviour
{
    

    protected List<GameObject> enemies = new List<GameObject>();

    [SerializeField] int amountEnemy = 16;
    [SerializeField] List<Transform> SquarePoints = new List<Transform>();
    [SerializeField] List<Transform> RectanglePoints = new List<Transform>();
    [SerializeField] List<Transform> TrianglePoints = new List<Transform>();
    [SerializeField] List<Transform> DiamondPoints = new List<Transform>();
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] float moveDuration = 3f;
    [SerializeField] float delayTime = 5f;



    private void Start()
    {
        GenerateEnemies();
        //SquareArrangeFormation();
        //DiamondArrangeFormation();
        //RectangleArrangeFormation();
        //TriangleArrangeFormation();
        StartCoroutine(Test());
    }

    public void GenerateEnemies()
    {
        for (int i = 0; i < amountEnemy; i++)
        {

            float posY = 8.0f;
            float posX = UnityEngine.Random.Range(-6.0f, 6.0f);
            GameObject enemy = ObjectPooling.Instant.GetGameObject(enemyPrefab);
            enemy.transform.position = new Vector2(posX, posY);
            enemy.SetActive(true);
            enemy.GetComponent<Collider2D>().enabled = false;
            enemies.Add(enemy);
        }
    }
    public void SquareArrangeFormation()
    {
        for (int i = 0; i < amountEnemy; i++)
        {
            enemies[i].transform.DOMove(SquarePoints[i].position, moveDuration);
        }
    }
    public void DiamondArrangeFormation()
    {
        for (int i = 0; i < amountEnemy; i++)
        {
            enemies[i].transform.DOMove(DiamondPoints[i].position, moveDuration);
        }
    }
    public void RectangleArrangeFormation()
    {
        for (int i = 0; i < amountEnemy; i++)
        {
            enemies[i].transform.DOMove(RectanglePoints[i].position, moveDuration);
        }
    }
    public void TriangleArrangeFormation()
    {
        for (int i = 0; i < amountEnemy; i++)
        {
            enemies[i].transform.DOMove(TrianglePoints[i].position, moveDuration);
        }
    }

    IEnumerator Test()
    {
        SquareArrangeFormation();

        yield return new WaitForSeconds(moveDuration + delayTime);
        DiamondArrangeFormation();

        yield return new WaitForSeconds(moveDuration + delayTime);
        TriangleArrangeFormation();

        yield return new WaitForSeconds(moveDuration + delayTime);
        RectangleArrangeFormation();

        yield return new WaitForSeconds(moveDuration);

        for (int i = 0; i < amountEnemy; i++)
        {
            enemies[i].GetComponent<Collider2D>().enabled = true;
        }
    }

}
