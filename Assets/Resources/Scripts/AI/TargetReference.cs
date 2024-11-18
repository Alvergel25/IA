using UnityEngine;

public class TargetReference : MonoBehaviour
{
    public GameObject target;

    void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
    }
}