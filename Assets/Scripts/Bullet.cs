using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        this.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                this.gameObject.SetActive(false);
            }
        }
    }
}
