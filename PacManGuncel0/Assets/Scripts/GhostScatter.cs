using UnityEngine;

public class GhostScatter : GhostBehavior
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();
        if (node != null && this.enabled && !this.Mob.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);
            //tekrar geri gitmesini engeller
            if (node.availableDirections[index] == -this.Mob.movement.direction && node.availableDirections.Count>1)
            {
                index++;

                if(index >= node.availableDirections.Count) 
                {
                    index = 0;
                }
            }
            this.Mob.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
