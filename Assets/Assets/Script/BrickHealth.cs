using Unity.VisualScripting;
using UnityEngine;

public class BrickHealth : MonoBehaviour
{
    [SerializeField] int healthPoints = 1;
    int currentHealth = 0;
    void Start()
    {
        currentHealth = healthPoints;
    }


    void Update()
    {

    }

    void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
        Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }


}
