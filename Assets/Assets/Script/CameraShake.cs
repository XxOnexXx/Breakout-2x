using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        
    }

    public void Shake()
    {
        int rand = Random.Range(0, 3);

        if (rand == 0)
        {
            anim.SetTrigger("Shake00");
        }
        if (rand == 1)
        {
            anim.SetTrigger("Shake01");
        }
        if (rand == 2)
        {
            anim.SetTrigger("Shake02");
        }
    }
}
