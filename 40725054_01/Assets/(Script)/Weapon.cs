using UnityEngine;
namespace Tian
{
    /// <summary>
    /// �Z���G���[�b�Z������W
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        public float attack;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag =="Enemy")
            {
               // print("<color=red>���˼ĤH�G" + collision.gameObject + "</color>");
                collision.gameObject.GetComponent<HurtSystem>().GetHurt(attack);
            }
        }
    }
}

