using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private GameObject _cloudPoofPrefab;

    private void OnCollisionEnter2D(Collision2D other) {
        Bird bird = other.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_cloudPoofPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy enemy = other.collider.GetComponent<Enemy>();
        if (enemy != null) return;

        if (other.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudPoofPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
