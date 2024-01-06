using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8f; //h�z

        public float speedMultiplier = 1f; // h�z �arpan�

        public Vector2 initialDirection; 

    public LayerMask wallLayer; //Raycast yapaca��m�z layerlar


    public Rigidbody2D rigidbody2D { get; private set; }
    public Vector2 direction { get; private set; } 
    public Vector2 nextDirection { get; private set; } //Bas�lan tu�lar� s�raya sokmaya sa�lar
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
        this.transform.position = this.startingPosition; //ba�lang�� yeri
        this.rigidbody2D.isKinematic= false; //Moblar duvardan ge�mesin diye
        this.enabled = true; //Scripti aktif eder
    }
    private void Start()
    {
        ResetState();
    }
    private void Update()
    {
        if(this.nextDirection != Vector2.zero) //Karakter yanlar� doluysa hareket edemeyecek ve bir sonraki gidece�i yeri s�raya sokacak
        {
            SetDirection(this.nextDirection);
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = this.rigidbody2D.position; //Konumumuz
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime; //Bakt���m�z y�ne do�ru sabit h�zla gitmemizi sa�lar
        
        this.rigidbody2D.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if(!Occupied(direction) || forced) //Y�n de�i�ince Y�nS�ras�n� resetler
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else //Gitmemizi istedi�i y�n kapal�ysa o y�n� s�raya koyar
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.9f, 0.0f, direction, 0.5f, wallLayer);
        //Raycast BoxCast ��nk� tilelar ile uyumlu olmas� laz�m. Parantez i�i s�ras�yla = (Konum, Boyut, A��s�, Y�n�, Uzakl���)
        return hit.collider != null;
        //Raycast �eye �arparsa collider null olmayacak, �arparsan olacak (Occupied durumu)       
    }

}

