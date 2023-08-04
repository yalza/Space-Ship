using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Formation : MonoBehaviour
{
    

    protected List<GameObject> enemies = new List<GameObject>();

    [SerializeField] int amountEnemy = 16;
    [SerializeField] float moveDuration = 3f;
    [SerializeField] float delayTime = 5f;

    [SerializeField] GameObject enemyPrefab;

    [SerializeField] List<Transform> SquarePoints = new List<Transform>();
    [SerializeField] List<Transform> RectanglePoints = new List<Transform>();
    [SerializeField] List<Transform> TrianglePoints = new List<Transform>();
    [SerializeField] List<Transform> DiamondPoints = new List<Transform>();

    private void Start()
    {
        GenerateEnemies();
        StartCoroutine(ArrangeFormations());
    }

    public void GenerateEnemies()
    {
        for (int i = 0; i < amountEnemy; i++)
        {

            float posY = 10f;
            float posX = Random.Range(-8.0f, 8.0f);
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

    IEnumerator ArrangeFormations()
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
