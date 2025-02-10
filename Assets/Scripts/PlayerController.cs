using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private Animator animator;
    [SerializeField]private float movespeed = 5;
    public Vector3 playerMoveDirection;

    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoveDirection = new Vector3(inputX, inputY).normalized;
        
        animator.SetFloat("moveX",inputX);
        animator.SetFloat("moveY",inputY);

        if (playerMoveDirection == Vector3.zero){
            animator.SetBool("moving",false);
        }
        else{
            animator.SetBool("moving",true);
        }
    }

    private void FixedUpdate() 
    {
        rb.linearVelocity = new Vector2(playerMoveDirection.x * movespeed, playerMoveDirection.y * movespeed);
    }
}
