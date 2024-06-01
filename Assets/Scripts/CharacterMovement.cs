
using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    public BoxCollider2D characterCollider;
    void Update()
    {
        bool doMoveRight = Input.GetKeyDown(KeyCode.D);
        if (doMoveRight)
        {
            if (
              Physics2D.BoxCast(
                characterCollider.bounds.center,
                characterCollider.size,
                0f,
                Vector2.right,
                1f
              )
            )
            {
                Debug.Log("The BoxCast hit something! Don't move.");
            }
            else
            {
                transform.Translate(Vector3.right);
            }
        }
    }
}