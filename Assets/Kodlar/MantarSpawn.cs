using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantarSpawn : MonoBehaviour
{
    public Transform spawnNoktasi;
    public GameObject spawnlanacakYaratik;
    float spawnSuresi;
    void Start()
    {
        StartCoroutine(SpawnSistemi()); // Spawn sistemi başlat
    }

    // Update is called once per frame
    IEnumerator SpawnSistemi(){
        while (true) // Sonsuz döngü
        {
            spawnSuresi = Random.Range(1, 3); // Rastgele süre belirle
            yield return new WaitForSeconds(spawnSuresi); // Bekle
            NesneOlustur(); // Nesne oluştur
        }
       
    }
    
        void NesneOlustur(){
        
        GameObject temp = Instantiate(spawnlanacakYaratik);
        temp.transform.position = spawnNoktasi.position;
        
    }
    
    
}
