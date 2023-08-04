using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lifeTime = 1.0f;

    [SerializeField] private Vector2 _moveDirection = Vector2.up;

    private void OnEnable()
    {
        StartCoroutine(DisActive());
    }

    private void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_moveDirection * _moveSpeed);
    }

    IEnumerator DisActive()
    {
        yield return new WaitForSeconds(_lifeTime);
        transform.gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
                gameObject.SetActive(false);
            }
            
        }
    }
}
