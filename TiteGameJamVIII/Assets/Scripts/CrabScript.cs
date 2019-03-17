using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrabScript : MonoBehaviour
{
    private PlayerController player;

    private bool rave = false;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isDead && !rave)
        {
            rave = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Vector2 MoveTo = new Vector2(player.transform.position.x + Random.Range(-1.5f, 1.5f), player.transform.position.y + Random.Range(-1.5f, 1.5f));
            transform.DOMove(MoveTo, 5f).OnComplete(() => 
            {
                animator.SetTrigger("Rave");
            });
        }
    }
}
