using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoundsCheck))]

public class Enemy : MonoBehaviour
{

    [Header("Inscribed")]

    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10;

    public int score = 100;

    private BoundsCheck bndCheck;

    void Awake()
    {

        bndCheck = GetComponent<BoundsCheck>();
        
    }

    public Vector3 pos
    {
        get
        {

            return this.transform.position;

        }

        set
        {

            this.transform.position = value;

        }

    }

    // Update is called once per frame
    void Update()
    {

        Move();

        if (bndCheck.LocIs(BoundsCheck.eScreenLocs.offDown))
        {

            Destroy(gameObject);

        }
        
    }

    public virtual void Move()
    {

        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;

    }

    void OnCollisionEnter(Collision Coll)
    {

        GameObject otherGO = Coll.gameObject;

        if (otherGO.GetComponent<ProjectileHero>() != null)
        {

            Destroy(otherGO);
            Destroy(gameObject);

        }

        else
        {

            Debug.Log("Enemy hit by non-ProjectileHero: " + otherGO.name);

        }

    }


}
