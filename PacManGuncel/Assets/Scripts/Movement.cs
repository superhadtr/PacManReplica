using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8f; //hýz

        public float speedMultiplier = 1f; // hýz çarpaný

        public Vector2 initialDirection; 

    public LayerMask wallLayer; //Raycast yapacaðýmýz layerlar


    public Rigidbody2D rigidbody2D { get; private set; }
    public Vector2 direction { get; private set; } 
    public Vector2 nextDirection { get; private set; } //Basýlan tuþlarý sýraya sokmaya saðlar
    public Vector2 startingPosition { get; private set; }

    private void Awake()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position;
    }
    public void ResetState()
    {
        this.speedMultiplier = 1f;
        this.direction= initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition; //baþlangýç yeri
        this.rigidbody2D.isKinematic= false; //Moblar duvardan geçmesin diye
        this.enabled = true; //Scripti aktif eder
    }
    private void Start()
    {
        ResetState();
    }
    private void Update()
    {
        if(this.nextDirection != Vector2.zero) //Karakter yanlarý doluysa hareket edemeyecek ve bir sonraki gideceði yeri sýraya sokacak
        {
            SetDirection(this.nextDirection);
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = this.rigidbody2D.position; //Konumumuz
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime; //Baktýðýmýz yöne doðru sabit hýzla gitmemizi saðlar
        
        this.rigidbody2D.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if(!Occupied(direction) || forced) //Yön deðiþince YönSýrasýný resetler
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else //Gitmemizi istediði yön kapalýysa o yönü sýraya koyar
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.9f, 0.0f, direction, 0.5f, wallLayer);
        //Raycast BoxCast çünkü tilelar ile uyumlu olmasý lazým. Parantez içi sýrasýyla = (Konum, Boyut, Açýsý, Yönü, Uzaklýðý)
        return hit.collider != null;
        //Raycast þeye çarparsa collider null olmayacak, çarparsan olacak (Occupied durumu)       
    }

}

