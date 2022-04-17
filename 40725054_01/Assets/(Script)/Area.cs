
using UnityEngine;

namespace Tian
{
    public class Area : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider)
            {
                print("Boom");
                Destroy(GameObject.FindGameObjectWithTag("Bullet"));
            }
        }
    }
}

