using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sodier : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 2f; 
    private Collider2D col;
    private float resTimer = 3f;
    public Manager manager;
    void Start()
    {
        StartCoroutine(SelfDestruct());
        col = GetComponent<Collider2D>();
        manager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
        manager.GetComponent<Manager>().soldierDie++;
    }

    void Update()
    {
        if (col.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            Debug.Log("Saved a soldier!");
            resTimer -= Time.deltaTime;
            if (resTimer <= 0f)
            {
                Destroy(gameObject);
                manager.GetComponent<Manager>().soldierSave++;
            }
        }
    }
}
