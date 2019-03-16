using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1f;

    private Vector2 movement;

    public TextMeshProUGUI tooltipgui;

    private GameObject interactingObject;

    public int health = 20;
    public int hunger = 20;
    public int water = 20;
    public int energy = 20;

    public float hungerDecreaseRate = 5f;
    public float waterDecreaseRate = 5f;
    public float energyDecreaseRate = 5f;

    public float hungerTimer = 0f;
    public float waterTimer = 0f;
    public float energyTimer = 0f;

    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void DecreaseStatus()
    {
        if(hungerTimer < hungerDecreaseRate)
        {
            hungerTimer += Time.deltaTime;
        }
        else
        {
            hungerTimer = 0f;
            hunger--;
            if(hunger < 0)
            {
                hunger = 0;
                health--;
            }
        }

        if(energyTimer < energyDecreaseRate)
        {
            energyTimer += Time.deltaTime;
        }
        else
        {
            energyTimer = 0f;
            energy--;
            if(energy < 0)
            {
                energy = 0;
                health--;
            }
        }

        if(waterTimer < waterDecreaseRate)
        {
            waterTimer += Time.deltaTime;
        }
        else
        {
            waterTimer = 0f;
            water--;
            if(water < 0)
            {
                water = 0;
                health--;
            }
        }

        if(health <= 0)
        {
            health = 0;
            Debug.Log("Lol u ded bruh");
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<InteractableObject>())
        {
            if(col.gameObject.GetComponent<FishingSpot>())
            {
                interactingObject = col.gameObject;
                tooltipgui.text = "Press Space to Fish";
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject == interactingObject)
        {
            tooltipgui.text = "";
            interactingObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseStatus();

        if(interactingObject != null)
        {
            if(InputManager.GetInteractDown())
            {
                interactingObject.GetComponent<InteractableObject>().InteractWithObject();
            }
        }

        movement = InputManager.GetMovement();
        if (movement != Vector2.zero)
        {
            energyTimer += Time.deltaTime * 2;
            body.velocity = Vector2.zero;
            animator.SetBool("Movement", true);
            body.AddForce(movementSpeed * movement, ForceMode2D.Impulse);
            if(body.velocity.magnitude > movementSpeed)
                body.velocity = body.velocity.normalized * movementSpeed;
        }
        else
        {
            animator.SetBool("Movement", false);
            body.velocity = Vector2.zero;
        }

        if (body.velocity.y < 0f) // Going Down
        {
            animator.SetInteger("Direction", 0);
        }
        else if (body.velocity.y > 0f) // Going Up
        {
            animator.SetInteger("Direction", 1);
        }
        
        if (body.velocity.x > 0f || body.velocity.x < 0f) // Going Sideways
        {
            animator.SetInteger("Direction", 2);
            if(body.velocity.x < 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
    }
}
