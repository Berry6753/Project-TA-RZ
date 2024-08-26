using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Monster_A : Monster,IHit
{
    [SerializeField] private GameObject atkPrefab;
    [SerializeField] private GameObject explosionPrefab;
    [Inject] private PoolManager _poolManager;

    private void Awake()
    {
        _poolManager.CreatePool(atkPrefab,1);
        _poolManager.CreatePool(explosionPrefab,1);
        StartCoroutine(Ex());
    }

    public void StartAtk()
    {
        Vector3 playerPosition = Player.transform.position;
        GameObject atkObject = _poolManager.DequeueObject(atkPrefab);
        atkObject.transform.position = playerPosition; 
    }

    public void PlayExplosion()
    {
        GameObject explosion = _poolManager.DequeueObject(explosionPrefab);
        ParticleSystem particle = explosionPrefab.GetComponent<ParticleSystem>();
        explosion.transform.position = Player.transform.position;
        particle.Play();
    }

    IEnumerator Ex()
    {
        Mon_Common_CoolTime = 2.0f;
        Mon_Common_Range = 10.0f;
        yield return new WaitForSeconds(3f);
        Mon_Common_Range = 10.0f;

    }
}
