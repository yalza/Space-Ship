using System.Collections;
using UnityEngine;

public class PlayerFireArm : MonoBehaviour
{
    [SerializeField] private float _coolDownTime = 0.1f;

    [SerializeField] private GameObject _bulletPlayerPrefab;

    private void Start()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(_coolDownTime);
            GameObject bullet = ObjectPooling.Instant.GetGameObject(_bulletPlayerPrefab);
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
            
        }
    }
}
