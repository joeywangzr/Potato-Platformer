using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{

	public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
    animator.SetBool("win", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
