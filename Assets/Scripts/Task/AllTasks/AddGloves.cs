using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGloves: Task
{
    
    [SerializeField] private GameObject glovesTrigger;
    public override string RUDescription { get => "Надеть перчатки"; set { } }
    public override string ENDescription { get => "Put on glove"; }
    public override string Name { get => "PutGlove"; }
    //Условия выполнения задания
    public override void Terms()
    {
        glovesTrigger.SetActive(true);
        base.Terms();
    }
    public void OnGlovesWorn()
    {
        FinishTask();
    }
}
