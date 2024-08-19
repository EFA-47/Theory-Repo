using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cat : Animal
{
    override public void Start()
    {
        specialAct = "Eat_b";
        base.Start();
    }
    override public void Shout()
    {
        Debug.Log(gameObject.name + " meowed");
    }

    public override void SetAnimalAct()
    {
        moving *= -1;
        resting = !resting; 
    }
}
