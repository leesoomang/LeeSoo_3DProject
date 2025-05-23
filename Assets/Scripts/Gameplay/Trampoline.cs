using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trampoline : MonoBehaviour
{
    public float bounceForce;

    void OnTriggerEnter(Collider other)
    {
        var rb = other.attachedRigidbody;
        if (rb != null)
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}
