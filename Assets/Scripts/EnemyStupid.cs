using UnityEngine;

public class EnemyStupid : MonoBehaviour
{
    public GameObject leftBorder;
    public GameObject rightBorder;
    public Rigidbody2D gitidbody;

    private float speed = 3;
    
    private bool isLeftDirectionMove;
    
    private void Update()
    {
        if (this.isLeftDirectionMove)
        {
            this.gitidbody.velocity = Vector2.left * this.speed;

            if (this.transform.position.x < this.leftBorder.transform.position.x)
            {
                this.isLeftDirectionMove = !this.isLeftDirectionMove;
            }
        }
        else
        {
            this.gitidbody.velocity = Vector2.right * this.speed;

            if (this.transform.position.x > this.rightBorder.transform.position.x)
            {
                this.isLeftDirectionMove = !this.isLeftDirectionMove;
            }
        }
    }
}
