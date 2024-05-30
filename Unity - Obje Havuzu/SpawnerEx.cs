using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEx : MonoBehaviour
{
    ObjeHavuzu objeHavuzu;

    public string tag;

    void Start()
    {
        //performans için başta instance ediyoruz
        objeHavuzu = ObjeHavuzu.Instance;
    }

    void Update()
    {
        objeHavuzu.HavuzdanGetir(tag, transform.position, Quaternion.identity);
    }
}
