using UnityEngine;

namespace Tian
{
    /// <summary>
    /// 受傷系統
    /// 血量、受傷和死亡
    /// </summary>
    public class HurtSystem : MonoBehaviour
    {
        //1. public 公開：所有類別都可存取
        //2. private 私人：僅限此類別可存取
        //3. protected 保護：僅限此類別與其子類別可存取

        [SerializeField, Header("血量"), Range(0, 10000)]
        protected float hp = 50;

        //vartual 虛擬：允許子類別使用 override 覆寫此成員
        ///<summary>
        ///受到傷害
        ///</summary>
        ///<param name="damage">受到的傷害值</param>
        public virtual void GetHurt(float damage)
        {
            if (hp <= 0) return;
            
            hp -= damage;
            //print("<color=#887700>受到傷害：" + damage + "</color>");

            if (hp <= 0) Dead();
        }
        /// <summary>
        /// 死亡
        /// </summary>
        protected virtual void Dead()
        {
            hp = 0;
            //print("<color = #887700>角色死亡：" + gameObject + "</color>");
        }
    }
}

