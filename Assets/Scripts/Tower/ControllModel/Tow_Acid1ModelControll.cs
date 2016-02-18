using UnityEngine;
using System.Collections;
using System;
using DevelopEngine;

public class Tow_Acid1ModelControll : ControllAttackModelBase
{
    public void Awake()
    {
        rotatePlace = Global.FindChild<Transform>(this.transform, "Turret");
    }
    public override void LookAtEnemy(Transform target)
    {
        rotatePlace.LookAt(target);
    }
}
