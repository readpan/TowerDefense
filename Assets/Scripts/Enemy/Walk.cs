using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour
{
    private Enemy enemy;

    public void Awake()
    {
        enemy = this.GetComponent<Enemy>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        GoStraight();
    }

    /// <summary>
    /// 走直线
    /// </summary>
    public void GoStraight()
    {
        this.transform.Translate(transform.forward * enemy.moveSpeed*Time.deltaTime);
    }
}