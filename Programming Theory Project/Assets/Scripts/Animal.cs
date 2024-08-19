
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Animal : MonoBehaviour
{
    protected float moving = 1;
    protected bool resting = false;
    protected string specialAct;
    private float moveTime;
    private float waitTime;
    private int rotate;
    private Animator anim;
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        SetAnimalAct();
        anim.SetFloat("Speed_f", moving);
        anim.SetBool(specialAct, true);
        
        waitTime = 0;
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime > 10)
        {
            RotateAnimalRandom();
            StartCoroutine(StartMoving());
            Shout();
            
        }
        waitTime += Time.deltaTime;
    }

    public virtual IEnumerator StartMoving()
    {
        waitTime = 0;
        moveTime = 0;
        SetAnimalAct();
        anim.SetFloat("Speed_f", moving);
        anim.SetBool(specialAct, false);
        while(moveTime < 2.5)
        {
            moveTime += Time.deltaTime;
            yield return null;
        }
        while(moveTime < 6 && moveTime > 2.5)
        {
            moveTime += Time.deltaTime;
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
            yield return null;
        }
        //Shout();
        SetAnimalAct();
        anim.SetFloat("Speed_f", moving);
        anim.SetBool(specialAct, true);
    }

    private void RotateAnimalRandom()
    {
        rotate = Random.Range(-180,181);
        transform.Rotate(Vector3.up, rotate);
    }

    public virtual void Shout()
    {
        
    }
    
    public abstract void SetAnimalAct();
}
