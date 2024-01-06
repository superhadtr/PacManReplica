/*using UnityEngine;

public class Mob : MonoBehaviour

    //Moblarý yediðinde vermesi gereken puan
{
    public Movement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    public GhostBehavior initialBehavior;
    public Transform target;

    public static int Points = 200;

    public void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        if (this.gameObject.active == true)
            Debug.Log("Mob aktif");
        else
            Debug.Log("Mob aktif deðil");
        this.movement.ResetState();
        Debug.Log("Disable giriyor");
        this.frightened.Disable();
        Debug.Log("Disable1");
        this.chase.Disable();
        Debug.Log("Disable2");
        this.scatter.Enable();
        Debug.Log("Disable3");

        if (this.home != this.initialBehavior)
        {
            Debug.Log("Disable4");
            this.home.Disable();
            Debug.Log("Disable4-");
        }

        if(this.initialBehavior != null)
        {
            Debug.Log("Disable5");
            this.initialBehavior.Enable();
            Debug.Log("Disable5-");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if(this.frightened.enabled)
            {
                FindObjectOfType<GameManager>().MobEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }
}*/
using UnityEngine;

[DefaultExecutionOrder(-10)]
[RequireComponent(typeof(Movement))]
public class Mob : MonoBehaviour
{
    public Movement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    public GhostBehavior initialBehavior;
    public Transform target;
    public static int Points = 200;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        home = GetComponent<GhostHome>();
        scatter = GetComponent<GhostScatter>();
        chase = GetComponent<GhostChase>();
        frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();

        frightened.Disable();
        chase.Disable();
        scatter.Enable();

        if (home != initialBehavior)
        {
            home.Disable();
        }

        if (initialBehavior != null)
        {
            initialBehavior.Enable();
        }
    }

    public void SetPosition(Vector3 position)
    {
        // Keep the z-position the same since it determines draw depth
        position.z = transform.position.z;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (frightened.enabled)
            {
                GameManager.Instance.MobEaten(this);
            }
            else
            {
                GameManager.Instance.PacmanEaten();
            }
        }
    }

}