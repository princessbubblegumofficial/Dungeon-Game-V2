using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] protected float moveSpeed;
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;

    protected Transform target;
    [SerializeField] protected float distance;
    protected SpriteRenderer spriteRenderer;

    public Image hpImage; //Red Health Bar
    public Image hpEffectImage; //White Health Bar Hurting Effect

    void Start()
    {
        healthPoint = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Introduction();
    }

    void Update()
    {
        Move();
        TurnDirection();
        if (healthPoint <= 0)
        {
            Death();
        }
        Attack();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthPoint -= 10; // Example damage for testing
            Debug.Log(enemyName + " took damage. Remaining health: " + healthPoint);
        }

        DisplayHPBar();
    }

    protected virtual void Introduction()
    {
        Debug.Log("My name is " + enemyName + ". I have " + maxHealthPoint + " health points." + moveSpeed + " is my speed.");
    }

    protected virtual void Move()
    {
        if (Vector2.Distance(transform.position, target.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    protected virtual void TurnDirection()
    {
        if (transform.position.x > target.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Death()
    {
        Debug.Log(enemyName + " has been defeated.");
        Destroy(gameObject);
    }
    
    protected virtual void DisplayHPBar()
    {
        
            hpImage.fillAmount = healthPoint / maxHealthPoint;
            if(hpEffectImage.fillAmount > hpImage.fillAmount)
            {
            hpEffectImage.fillAmount -= 0.005f;
            }
            else
            {
                hpEffectImage.fillAmount = hpImage.fillAmount; // Parar de diminuir
            }
    }
    
}
