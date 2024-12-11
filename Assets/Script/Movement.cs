
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected float speed;
    public abstract void Move(Vector3 direction);

    protected void RotateTowardsDirection(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }
}
