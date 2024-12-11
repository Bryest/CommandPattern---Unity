using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * speed/* Time.deltaTime*/, Space.World);
    }

    public void UndoMove(Vector3 direction)
    {
        transform.Translate(-direction * speed /* Time.deltaTime*/, Space.World);
    }
}