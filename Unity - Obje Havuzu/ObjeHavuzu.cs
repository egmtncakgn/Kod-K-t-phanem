using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeHavuzu : MonoBehaviour
{
    [System.Serializable]
    public class Havuz
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjeHavuzu Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Havuz> havuzlar;
    public Dictionary<string, Queue<GameObject>> havuzDictionary;

    void Start()
    {
        havuzDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Havuz havuz in havuzlar)
        {
            Queue<GameObject> objeHavuzu = new Queue<GameObject>();
            for (int i = 0; i < havuz.size; i++)
            {
                GameObject obj = Instantiate(havuz.prefab);
                obj.SetActive(false);
                objeHavuzu.Enqueue(obj);
            }

            havuzDictionary.Add(havuz.tag, objeHavuzu);
        }
    }
    
    public GameObject HavuzdanGetir(string tag, Vector3 pos, Quaternion rot)
    {
        if (!havuzDictionary.ContainsKey(tag))
        {
            Debug.LogWarning(tag + " Tag'ında bir havuz bulunamadı.");
            return null;
        }

        GameObject getirilecekObje = havuzDictionary[tag].Dequeue();
        
        getirilecekObje.SetActive(true);
        getirilecekObje.transform.position = pos;
        getirilecekObje.transform.rotation = rot;

        havuzDictionary[tag].Enqueue(getirilecekObje);

        return getirilecekObje;
    }
}
