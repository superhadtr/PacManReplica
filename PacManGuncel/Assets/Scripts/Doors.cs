using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Doors : MonoBehaviour
{
    

    private void Update()
    {
        if(Keys.keys==2)
        {
            Destroy(gameObject);
        }
    }
}
