using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1f;

    private Vector2 movement;

    public TextMeshProUGUI tooltipgui;
    public TextMeshProUGUI itemInUseTooltip;

    private InteractableObject interactingObject;

    public bool hasInputFocus = false;

    public bool isAsleep = false;

    public Item itemInUse;

    public int health = 20;
    public int hunger = 20;
    public int water = 20;
    public int energy = 20;

    private int maxHunger = 20;
    private int maxWater = 20;
    private int maxEnergy = 20;

    public float hungerDecreaseRate = 5f;
    public float waterDecreaseRate = 5f;
    public float energyDecreaseRate = 5f;

    public float hungerTimer = 0f;
    public float waterTimer = 0f;
    public float energyTimer = 0f;

    public float interactRate = 0.5f;
    public float interactTimer = 0;

    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer sprite;

    public AudioSource audiosource;

    public AudioClip[] audioClip;

    public bool isDead = false;

    public Image playerIsGone;

    public void PlayFootstep()
    {
        audiosource.PlayOneShot(audioClip[Random.Range(0, 2)], 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerIsGone.enabled = false;
        audiosource = GetComponent<AudioSource>();
        Time.timeScale = 1.0f;
        itemInUseTooltip.text = "";
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

        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }

        if(energyTimer < energyDecreaseRate)
        {
            energyTimer += Time.deltaTime;
            if(isAsleep)
            {
                energyTimer += Time.deltaTime * 3f;
            }
        }
        else
        {
            if(isAsleep)
            {
                energyTimer = 0f;
                energy += 1;
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
        }

        if (energy > maxEnergy)
        {
            energy = maxEnergy;
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

        if (water > maxWater)
        {
            water = maxWater;
        }

        if(health <= 0 && !isDead)
        {
            audiosource.PlayOneShot(audioClip[4], 2.0f);
            isDead = true;
            health = 0;
            animator.SetBool("Dead", true);
            tooltipgui.text = "You're totally dying, press any key to give up.";
        }
    }


    void UpdateToolTip(Collider2D col)
    {
        if(col.gameObject.GetComponent<InteractableObject>())
        {
            if(col.gameObject.GetComponent<FishingSpot>())
            {
                interactingObject = col.gameObject.GetComponent<FishingSpot>();
                if(itemInUse != null)
                {
                    tooltipgui.text = "Press Space to use " + itemInUse.itemname + " on " + " fishing spot.";
                }
                else
                {
                    tooltipgui.text = "Press Space to try to catch fish.";
                }
            }
            else if(col.gameObject.GetComponent<PalmTree>())
            {
                interactingObject = col.gameObject.GetComponent<PalmTree>();
                if(itemInUse != null)
                {
                    tooltipgui.text = "Press Space to use " + itemInUse.itemname + " on " + " palm tree.";
                }
                else
                {
                    tooltipgui.text = "Press Space to shake the palm tree.";
                }
            }
            else if(col.gameObject.GetComponent<Fireplace>())
            {
                interactingObject = col.gameObject.GetComponent<Fireplace>();
                if(itemInUse != null)
                {
                    tooltipgui.text = "Press Space to use " + itemInUse.itemname + " on " + " fireplace.";
                }
                else
                {
                    if(col.gameObject.GetComponent<Fireplace>().isBurning)
                        tooltipgui.text = "Press Space to cook fish.";
                    else if(col.gameObject.GetComponent<Fireplace>().barkAmount <= 0)
                        tooltipgui.text = "Press space to add bark to the fireplace.";
                    else if(!col.gameObject.GetComponent<Fireplace>().isBurning)
                        tooltipgui.text = "Press space to light the fireplace.";
                }
            }
            else if(col.gameObject.GetComponent<Rock>())
            {
                interactingObject = col.gameObject.GetComponent<Rock>();
                if(itemInUse != null)
                {
                    tooltipgui.text = "Press Space to use " + itemInUse.itemname + " on " + " rock.";
                }
                else
                {
                    tooltipgui.text = "Press Space to pickup the rock.";
                }
            }
            else if(col.gameObject.GetComponent<Shirt>())
            {
                interactingObject = col.gameObject.GetComponent<Shirt>();
                if(itemInUse != null)
                {
                    tooltipgui.text = "Press Space to use " + itemInUse.itemname + " on " + " shirt.";
                }
                else
                {
                    tooltipgui.text = "Press Space to pickup the shirt.";
                }
            }
            else if(col.gameObject.GetComponent<Flints>())
            {
                interactingObject = col.gameObject.GetComponent<Flints>();
                if(itemInUse != null)
                {
                    tooltipgui.text = "Press Space to use " + itemInUse.itemname + " on " + " flints.";
                }
                else
                {
                    tooltipgui.text = "Press Space to pickup the flints.";
                }
            }
            else if(col.gameObject.GetComponent<Boat>())
            {
                interactingObject = col.gameObject.GetComponent<Boat>();
                if(itemInUse != null)
                {
                    tooltipgui.text = "Press Space to use " + itemInUse.itemname + " on " + " flints.";
                }
                else
                {
                    tooltipgui.text = "Press Space to get on the boat.";
                }
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        UpdateToolTip(col);
    }

    public void ClearInteractingObject(Collider2D col)
    {
        Debug.Log(interactingObject);
        if(interactingObject != null)
        {
            if(col.gameObject == interactingObject.gameObject)
            {
                tooltipgui.text = "";
                interactingObject = null;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        ClearInteractingObject(col);
    }

    public void UseItem(Item item)
    {
        if(itemInUse == item)
        {
            itemInUse = null;
            itemInUseTooltip.text = "";
        }
        else
        {
            itemInUse = item;
            itemInUseTooltip.text = "Using: " + item.itemname;
        }
        if(interactingObject != null)
        {
            if(itemInUse != null)
                tooltipgui.text = "Press Space to use " + itemInUse.itemname + " on " + interactingObject.objectname;
            else
            {
                UpdateToolTip(interactingObject.GetComponent<Collider2D>());
            }
        }
        else
        {
            tooltipgui.text = "";
        }
    }

    void GetInputs()
    {
        if(interactingObject != null && !isAsleep && interactTimer >= interactRate)
        {
            if(InputManager.GetInteractDown())
            {
                interactTimer = 0;
                energyTimer += 6;
                interactingObject.GetComponent<InteractableObject>().InteractWithObject(itemInUse);
                if(interactingObject != null)
                {
                    UpdateToolTip(interactingObject.GetComponent<Collider2D>());
                }
                else
                {
                    tooltipgui.text = "";
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            itemInUse = null;
            itemInUseTooltip.text = "";
            if(interactingObject != null)
            {
                UpdateToolTip(interactingObject.GetComponent<Collider2D>());
            }
            else
            {
                tooltipgui.text = "";
            }
        }

        if(InputManager.GetSleepDown())
        {
            isAsleep = !isAsleep;
            animator.SetBool("Asleep", isAsleep);
            if(isAsleep)
            {
                Time.timeScale = 2.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }

        movement = InputManager.GetMovement();
        if (movement != Vector2.zero && !isAsleep)
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

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            DecreaseStatus();
        }

        interactTimer += Time.deltaTime;
        if(interactTimer > interactRate)
            interactTimer = interactRate;

        if(hasInputFocus && !isDead)
        {
            GetInputs();
        }
        else
        {
            body.velocity = Vector2.zero;
            animator.SetBool("Movement", false);
        }

        if(isDead)
        {
            tooltipgui.text = "You're totally dying, press 'R' to give up.";
            if (Input.GetKeyDown(KeyCode.R))
            {
                DOTween.KillAll();
                SceneManager.LoadScene("Failed");
            }
        }
    }
}
