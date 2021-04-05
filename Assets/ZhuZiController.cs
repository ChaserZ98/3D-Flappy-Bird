using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ZhuZiController : MonoBehaviour
{
    public GameObject ZhuZis;

    public GameObject Prefab;

    public float spawnSpeed = 1;

    public float moveSpeed = 1.5f;
    
    public void StartSpawnZhuZi()
    {
        Debug.Log("Spawn Start!");
        StartCoroutine("Spawn");
    }

    public void StopSpawnZhuZi()
    {
        Debug.Log("Spawn Stop!");
        StopCoroutine("Spawn");
    }

    public void SpawnOne()
    {
        GameObject zhuzi = Instantiate(Prefab, ZhuZis.transform);
        zhuzi.transform.localPosition = new Vector3(3.57f, Random.Range(1.5f, 5));
        zhuzi.transform.DOMoveX(-3.62f, moveSpeed).SetId<Tween>("zhuzi").OnComplete(new TweenCallback(() => { GameObject.Destroy(zhuzi); }));
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnSpeed);
        SpawnOne();
        yield return StartCoroutine("Spawn");
    }
}
