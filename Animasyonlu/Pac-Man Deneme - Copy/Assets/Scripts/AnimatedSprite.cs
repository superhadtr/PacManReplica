using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] //Bu Component i�in spriteRenderer gerekli k�lma

public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; } // Sprite tan�m� ayarlama
    public Sprite[] sprites; // Spritelar� tan�mlama
    public float animationTime = 0.25f; // Animasyonun kare h�z�n� ayarlamak i�in tan�mlama
    public int animationFrame { get; private set; } // Animasyonun ka��nc� framede oldu�unu tutmak i�in animasyonun karesini tan�mlama
    public bool loop = true; // Loopta olup olmad���n� kontrol etmek i�in de�i�ken tan�mlama

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer'� se�me
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), this.animationTime, this.animationTime); // Ba�lang��tan itibaren her saniye animasyon �al��mas� i�in tekrarlay�c� yapma
    }

    private void Advance()
    {
        if (!this.spriteRenderer.enabled) // E�er spriteRenderer aktif de�il ise animasyona girme ve ��k
            return;

        this.animationFrame++; // Animasyonun karesini bir sonraki kare yapma

        if(this.animationFrame >= this.sprites.Length && this.loop) // E�er animasyonun karesi Sprite'�n uzunlu�undan b�y�k veya
            this.animationFrame = 0;                                // e�itse ve ayn� zamanda loopta ise animasyon karesini ba�a al

        if (this.animationFrame >= 0 && this.animationFrame < this.sprites.Length) // E�er animasyon karesi 0 dan b�y�k ve e�itse yani
            this.spriteRenderer.sprite = this.sprites[this.animationFrame];        // 0.kare 1.kare ve �zeri ise ve ayn� zamanda animasyonun
                                                                                   // karesi Sprite'�n uzunlu�undan k���k ise bu Sprite'�
                                                                                   // s�ras� gelen animasyon karesi ile de�i�tir
    }

    public void Restart()
    {
        this.animationFrame = -1; // Animasyonun kare s�ras�n� ba�tan ba�lat ve Advence metoduna d�nerek animasyona tekrar gir

        Advance();
    }
}
