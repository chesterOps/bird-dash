using UnityEngine;

public class BlockContainer : MonoBehaviour
{
    [SerializeField] private float _blockSpeed;

    void Update()
    {
        // Move the block container leftwards
        Move();
        // Disable the block container if it goes off-screen
        if (transform.position.x <= -26f)
        {
            Disable();
        }
    }


    void Move()
    {
        Vector3 positionChange = _blockSpeed * Time.deltaTime * new Vector3(-1, 0, 0);
        transform.position += positionChange;
    }

    void Disable()
    {
        transform.gameObject.SetActive(false);
    }

}
