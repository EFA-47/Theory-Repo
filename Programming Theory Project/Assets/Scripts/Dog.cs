using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dog : Animal
{
    override public void Start()
    {
        specialAct = "Sit_b";
        base.Start();
    }
    public override void Shout()
    {
        Debug.Log(gameObject.name + " barked");
    }
    public override void SetAnimalAct()
    {
        moving *= -1;
        resting = !resting; 
    }
}
