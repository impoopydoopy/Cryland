using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractibleList : MonoBehaviour
{
    private GameObject closestEntity;

    private List<GameObject> TriggeredEntities;

    public bool dialogueActive = false;
    public GameObject dialogueWith;

    private void Start()
    {
        TriggeredEntities = new List<GameObject>();
    }
    public void AddEntity(GameObject entity)
    {
        TriggeredEntities.Add(entity);
    }
    public void RemoveEntity(GameObject entity)
    {
        TriggeredEntities.Remove(entity);
    }

    // called on pressing yes on dialogue
    public void death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EntityTrigger")
        {
            AddEntity(collision.gameObject);
        }
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "EntityTrigger")
        {
            // later remove this part and make a script where it removes  member from above comment-mentioned list of entities
            RemoveEntity(collision.gameObject);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(TriggeredEntities.Count <= 0)
            {
                return;
            }

            // govno algorithm but it works 
            List<float> distances = new List<float>();
            List<GameObject> GOdistances = new List<GameObject>();
            foreach (GameObject a in TriggeredEntities)
            {
                distances.Add(Vector2.Distance(transform.position, a.transform.position));
                GOdistances.Add(a);
            }
            closestEntity = GOdistances[distances.IndexOf(distances.Min())];
            closestEntity.GetComponent<IActionable>().Action();
        }
    }
}
