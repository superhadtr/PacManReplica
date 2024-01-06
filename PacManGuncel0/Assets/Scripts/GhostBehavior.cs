/*using UnityEngine;

[RequireComponent(typeof(Mob))]
public abstract class MobBehavior : MonoBehaviour
{
    public Mob mob { get; private set; }
    public float duration;

    private void Awake()
    {
        this.mob = GetComponent<Mob>();
    }

    public void Enable()
    {
        Enable(this.duration);
    }
    public virtual void Enable(float duration)
    {
        this.enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        Debug.Log("Disable1");
        this.enabled = false;
        Debug.Log("Disable2");
        CancelInvoke();
        Debug.Log("Disable3");
    }
}*/
using UnityEngine;

[RequireComponent(typeof(Mob))]
public abstract class GhostBehavior : MonoBehaviour
{
    public Mob Mob { get; private set; }
    public float duration;

    private void Awake()
    {
        Mob = GetComponent<Mob>();
    }

    public void Enable()
    {
        Debug.Log("Enable0");
        Enable(duration);
        Debug.Log("Enable1");
    }

    public virtual void Enable(float duration)
    {
        Debug.Log("Enable2");
        enabled = true;
        Debug.Log("Enable3");
        CancelInvoke();
        Invoke(nameof(Disable), duration);
        Debug.Log("Enable4");
    }

    public virtual void Disable()
    {
        Debug.Log("Disable01");
        enabled = false;
        Debug.Log("Disable02");
        CancelInvoke();
        Debug.Log("Disable03");
    }

}