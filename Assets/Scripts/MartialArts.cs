using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartialArts : MonoBehaviour {

    Animator animator;
    public ParticleSystem kickParticles;
    public ParticleSystem punchParticles;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.K))
            animator.SetTrigger("Kick");

        if (Input.GetKeyDown(KeyCode.P))
            animator.SetTrigger("Punch");
    }

    public void kick()
    {
        if (kickParticles)
        {
            kickParticles.gameObject.SetActive(false);
            kickParticles.gameObject.SetActive(true);
        }
    }

    public void punch()
    {
        if (punchParticles)
        {
            punchParticles.gameObject.SetActive(false);
            punchParticles.gameObject.SetActive(true);
        }
    }
}
