using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    private Transform _transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transform = GetComponent<Transform>();
        _transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        _transform.LookAt(target);
    }
}
