using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public UnitCode unitCode { get; } // �ٲ� �� ���� get��
    public string name { get; set; }
    public int maxHp { get; set; }
    public int nowHp { get; set; }
    public int atkDmg { get; set; }
   // public float atkSpeed { get; set; }
    public float moveSpeed { get; set; }
   // public float atkRange { get; set; }
    //public float fieldOfVision { get; set; }

    public Status()
    {
    }

    public Status(UnitCode unitCode, string name, int maxHp, int atkDmg, float atkSpeed, float moveSpeed, float atkRange, float fieldOfVision)
    {
        this.unitCode = unitCode;
        this.name = name;
        this.maxHp = maxHp;
        nowHp = maxHp;
        this.atkDmg = atkDmg;
       // this.atkSpeed = atkSpeed;
        this.moveSpeed = moveSpeed;
       // this.atkRange = atkRange;
        //.fieldOfVision = fieldOfVision;
    }

    public Status SetUnitStatus(UnitCode unitCode)
    {
        Status status = null;

        switch (unitCode)
        {
            case UnitCode.Player:
                status = new Status(unitCode,
                    "NoName", 
                    DataManager.Instance.data.maxHp,
                    DataManager.Instance.data.atkDmg, 
                    1f,
                    DataManager.Instance.data.moveSpeed, 
                    0, 
                    0);
                break;
            case UnitCode.enemy1:
                status = new Status(unitCode, "Enemy1", 100, 10, 1.5f, 2f, 1.5f, 7f);
                break;
        }
        return status;
    }

}
public enum UnitCode
{
    Player,
    enemy1
}