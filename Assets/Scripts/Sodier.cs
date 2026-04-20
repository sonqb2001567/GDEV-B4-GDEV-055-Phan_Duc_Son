using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sodier : MonoBehaviour
{
    public float time = 5f; 
    private float resTimer = 3f;
    public Manager manager;

    private bool isDone = false;

    void Start()
    {
        StartCoroutine(SelfDestruct());
        manager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(time);

        if (!isDone)
        {
            isDone = true;
            manager.soldierDie++;
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isDone) return;
        Debug.Log("Saving... " + resTimer);

        if (other.CompareTag("Player"))
        {
            resTimer -= Time.deltaTime;

            if (resTimer <= 0f)
            {
                isDone = true;
                manager.soldierSave++;
                Debug.Log("Saved!");
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            resTimer = 3f; // reset if player leaves early
        }
    }
}