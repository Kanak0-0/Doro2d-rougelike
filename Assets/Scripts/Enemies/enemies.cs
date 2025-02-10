using UnityEngine;

public class enemies : MonoBehaviour
{
    [SerializeField]private SpriteRenderer spriteRenderer;
    [SerializeField]private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField]private float movespeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() 
    {
         // facing the player
        if(PlayerController.Instance.transform.position.x > transform.position.x){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }

        //attract to player
        direction = (PlayerController.Instance.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * movespeed, direction.y * movespeed);
    
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
