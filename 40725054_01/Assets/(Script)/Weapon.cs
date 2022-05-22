using UnityEngine;
namespace Tian
{
    /// <summary>
    /// 武器：附加在武器物件上
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        public float attack;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag =="Enemy")
            {
               // print("<color=red>打倒敵人：" + collision.gameObject + "</color>");
                collision.gameObject.GetComponent<HurtSystem>().GetHurt(attack);
            }
        }
    }
}

