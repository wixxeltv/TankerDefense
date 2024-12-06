using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TankScript : Shooter
{
    public float TankSpeed = 10f;
    private float leftRight = 0f;
    public float rotationSpeed = 10f;
    private float topDown = 0f;
    private Rigidbody _rigidbody;
    public AudioClip moveSound;
    public AudioSource audioSource;
    private bool wantToFire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wantToFire = false;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire && wantToFire)
        {
            StartCoroutine(fire());
        }
    }
    private void FixedUpdate()
    {
        _rigidbody.AddRelativeTorque(0f, leftRight * rotationSpeed, 0f);
        _rigidbody.angularVelocity = Vector3.ClampMagnitude(_rigidbody.angularVelocity, rotationSpeed);
        _rigidbody.AddRelativeForce( new Vector3(0f, 0f, topDown).normalized * TankSpeed);
    }

    void OnMoveLeftRight(InputValue value)
    {

        leftRight = value.Get<float>();
    }

    void OnMoveTopDown(InputValue value)
    {
        topDown = value.Get<float>();
        if (value.Get<float>() != 0)
        {
            StartCoroutine(FadeAudio.Fade(false, audioSource, .25f, .5f));
        }
        else
        {
            StartCoroutine(FadeAudio.Fade(true, audioSource, .5f, 0));
        }
    }

    void OnShoot(InputValue value)
    {
        if (value.isPressed)
        {
            wantToFire = true;
        }
        else
        {
            wantToFire = false;
        }
    }
    
}
