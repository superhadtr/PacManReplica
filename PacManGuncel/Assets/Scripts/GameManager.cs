using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Mob[] mob;
    public Pacman Pacman;
    public Transform Coins;

    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        NewGame(); //Oyunu ba�lat�r
    }

    private void Update()
    {
        if(this.lives <=0 && Input.anyKeyDown)
        {
            NewGame(); //Karakter �l�rse yeniden ba�lat�r
        }
    }

    private void NewGame() //Yeni oyuna ba�lama fonksiyonu
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    //Temel oyun kurallar�yla ilgili fonksiyonlar

    private void NewRound()
    {
        foreach (Transform coin in this.Coins)
        {
            coin.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void GameOver()
    {
        for (int i = 0; i < this.mob.Length; i++)
        {
            this.mob[i].gameObject.SetActive(false);
        }
        this.Pacman.gameObject.SetActive(false);
    }

    private void ResetState()
    {
        for (int i = 0; i < this.mob.Length; i++)
        {
            this.mob[i].gameObject.SetActive(true);
        }
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }


    public void MobEaten(Mob mob)
    {
        SetScore(this.score + Mob.Points); //Yarat�k yeme puan�
    }

    public void PacmanEaten()
    {
        this.Pacman.gameObject.SetActive(false);
        if (this.lives > 0)
        {
            
            Invoke(nameof(ResetState), 3f); //�ld�kten sonra delay
            ResetState();
        }
        else { GameOver (); }
    }
}
    

