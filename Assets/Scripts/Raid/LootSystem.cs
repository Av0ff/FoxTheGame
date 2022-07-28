using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour
{
    [SerializeField]
    private Fox character;

    private void Awake()
    {
        character = GameObject.FindObjectOfType<Fox>();
    }

    private void Update()
    {
        if (DistanceToPickUp() < 3f)
        {
            DontDestroyOnLoadLevel.load.food++;
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, character.transform.position, Time.deltaTime * 10f);
        }
    }

    private float DistanceToPickUp()
    {
        Vector3 direction = character.transform.position - transform.position;

        return Vector3.Magnitude(direction);
    }
}
