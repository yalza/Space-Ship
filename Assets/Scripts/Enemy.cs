using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _hp = 5;

    public void TakeDamage(int damage)
    {
        _hp -= damage;

        if(_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Observer.Instant.NotifyObservers(Constant.EnemyDeadKey);
        gameObject.SetActive(false);
    }
}
