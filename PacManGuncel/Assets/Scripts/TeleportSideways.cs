using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSideways : MonoBehaviour
{
    public Transform connection;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 position = other.transform.position;
        position.x = this.connection.position.x;
        position.y = this.connection.position.y;
        other.transform.position = position;
    }
    
}
