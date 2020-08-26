using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] public Transform target;
    [SerializeField] public Camera cam;
    // Update is called once per frame
    void LateUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector3 direction = (target.position - cam.transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        lookRotation.x = transform.rotation.x;
        lookRotation.z = transform.rotation.z;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 100);
        transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * speed);
    }
}
