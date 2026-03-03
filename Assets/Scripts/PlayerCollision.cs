using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerCollision : MonoBehaviour
{

    private GameManager _gameManager;

    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameObject.AddComponent<PolygonCollider2D>();
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall") && _gameManager != null && !_gameManager.IsGameOver)
        {

            _gameManager.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint") && _gameManager != null)
        {
            _gameManager.IncreasePlayerScore();

        }
    }

}
