using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    [SerializeField]
    private float hareketHizi;
    bool yasiyor;
    GameObject oyuncu;

    Animator anim;
     
    void Start()
    {
        oyuncu = GameObject.Find("karakter");
        anim = this.GetComponent<Animator>();
        yasiyor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(yasiyor==true){
            IleriGit();
            // Karakter ölüyse geri git;
        }
        else{
            GeriGit();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kilic")){ // 🔍 Etiket kontrol
            Ol(); 
        }
    }

    public void Ol(){
  
        anim.SetTrigger("oldur"); // 💥 Animasyon tetikle
        yasiyor = false; // ❌ Karakter öldü
        Destroy(this.gameObject, 0.4f); // 💥 Karakter yok oldu
        oyuncu.GetComponent<Karakter>().SkorArttir(); // 🏆 Skoru arttır
        
    }

    void IleriGit(){
        transform.Translate(-hareketHizi*Time.deltaTime, 0, 0);
    }

    void GeriGit(){
        transform.Translate(hareketHizi*Time.deltaTime, 0, 0);
    }
}
