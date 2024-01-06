using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public static int keys = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        keys++;
        Destroy(gameObject);
    }
}
