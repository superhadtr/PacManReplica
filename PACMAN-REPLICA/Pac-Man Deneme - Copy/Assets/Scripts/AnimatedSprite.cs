using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] //Bu Component için spriteRenderer gerekli kýlma

public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; } // Sprite tanýmý ayarlama
    public Sprite[] sprites; // Spritelarý tanýmlama
    public float animationTime = 0.25f; // Animasyonun kare hýzýný ayarlamak için tanýmlama
    public int animationFrame { get; private set; } // Animasyonun kaçýncý framede olduðunu tutmak için animasyonun karesini tanýmlama
    public bool loop = true; // Loopta olup olmadýðýný kontrol etmek için deðiþken tanýmlama

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer'ý seçme
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), this.animationTime, this.animationTime); // Baþlangýçtan itibaren her saniye animasyon çalýþmasý için tekrarlayýcý yapma
    }

    private void Advance()
    {
        if (!this.spriteRenderer.enabled) // Eðer spriteRenderer aktif deðil ise animasyona girme ve çýk
            return;

        this.animationFrame++; // Animasyonun karesini bir sonraki kare yapma

        if(this.animationFrame >= this.sprites.Length && this.loop) // Eðer animasyonun karesi Sprite'ýn uzunluðundan büyük veya
            this.animationFrame = 0;                                // eþitse ve ayný zamanda loopta ise animasyon karesini baþa al

        if (this.animationFrame >= 0 && this.animationFrame < this.sprites.Length) // Eðer animasyon karesi 0 dan büyük ve eþitse yani
            this.spriteRenderer.sprite = this.sprites[this.animationFrame];        // 0.kare 1.kare ve üzeri ise ve ayný zamanda animasyonun
                                                                                   // karesi Sprite'ýn uzunluðundan küçük ise bu Sprite'ý
                                                                                   // sýrasý gelen animasyon karesi ile deðiþtir
    }

    public void Restart()
    {
        this.animationFrame = -1; // Animasyonun kare sýrasýný baþtan baþlat ve Advence metoduna dönerek animasyona tekrar gir

        Advance();
    }
}
