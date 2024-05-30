using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketliBlok : MonoBehaviour
{
    [Header("Davranış Seçimi")]
    public bool döndür = false;
    public bool hareketEttir = false;
    public GameObject hedef;

    [Header("Döndür")]
    public float hız;
    public bool saatYönünde;
    public bool sınırla = false;
    public float zSınır = 100; 

    [Header("Hareket Ettir")]
    public float hareketHızı; // eksi değerde olamaz
    public int başlangıç;
    public GameObject[] noktalar;

    bool ilk = true;
    Vector3 tolerans = new Vector3(0.1f, 0.1f, 0.1f);
    Transform hedefNokta = null;

    void Update()
    {
        if (döndür && hareketEttir)
        {
            Döndür();
            HareketEttir();
        }
        else if (döndür)
            Döndür();
        else if (hareketEttir)
            HareketEttir();
    }

    public void Döndür()
    {
        if (saatYönünde)
            hedef.transform.RotateAround(hedef.transform.position, Vector3.forward, -hız * Time.deltaTime);
        else
            hedef.transform.RotateAround(hedef.transform.position, Vector3.forward, hız * Time.deltaTime);

        if (Mathf.Abs(hedef.transform.eulerAngles.z) <= zSınır && sınırla)
            saatYönünde = !saatYönünde;

    }

    public void HareketEttir()
    {
        if (ilk)
        {
            hedef.transform.position = noktalar[başlangıç].transform.position;

            ilk = false;
        }

        if (Vector3.Distance(hedef.transform.position, noktalar[0].transform.position) <= 0.1f)
            hedefNokta = noktalar[1].transform;
        else if (Vector3.Distance(hedef.transform.position, noktalar[1].transform.position) <= 0.1f)
            hedefNokta = noktalar[0].transform;

        Vector3 yön =  hedefNokta.position - hedef.transform.position;

        hedef.transform.Translate((yön.normalized * hareketHızı) * Time.deltaTime, Camera.main.transform);

    }
}
