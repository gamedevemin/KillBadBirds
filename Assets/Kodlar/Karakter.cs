using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    [SerializeField]
    private float ziplamaGucu;
    private int sekGucu = 100;
    Rigidbody2D rb;
    Animator anim;
    GameObject oyuncu;
    public GameObject kilicSaldirmaYeri;
    private int skor;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    public void SkorArttir(){
        skor ++; // 🏆 Skoru arttır
    }
    public int SkoruOgren(){
        return skor;
    }
    void Update()
    {
        if(Input.GetKeyDown("k")){
            Zipla();
        }

        if(Input.GetKeyDown("l")){
            AsagiIn();
        }

        if(Input.GetKeyDown("j")){
            Saldir();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // 🛎️ Tetik
    {
        if(collision.gameObject.CompareTag("mantar")){ // 🔍 Etiket kontrol
            
            collision.gameObject.GetComponent<Dusman>().Ol(); // 🗡️ Saldır
            Sek(); // 🏃‍♂️ Zıpla
        }
    }

    public void Zipla(){
        rb.velocity = Vector2.zero; // 
        rb.AddForce(Vector2.up*ziplamaGucu);
    }

    public void Sek(){
        rb.velocity = Vector2.zero; // 
        rb.AddForce(Vector2.up*sekGucu);
    }

    public void AsagiIn(){
        rb.velocity = Vector2.zero; //  
        rb.AddForce(Vector2.down*ziplamaGucu);

    }

    public void Saldir(){

        anim.SetTrigger("saldir"); // 💥 Animasyon tetikle
        StartCoroutine(KilicAcKapat()); // 🗡️ Kılıcı aç-kapat
    }
    IEnumerator KilicAcKapat(){
        kilicSaldirmaYeri.SetActive(true); // 🗡️ Kılıcı a
        yield return new WaitForSeconds(0.4f); // ⏳ Bekle
        kilicSaldirmaYeri.SetActive(false); // 🗡️ Kılıcı kapat
    }
}
