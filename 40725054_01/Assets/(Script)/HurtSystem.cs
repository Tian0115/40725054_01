using UnityEngine;

namespace Tian
{
    /// <summary>
    /// ���˨t��
    /// ��q�B���˩M���`
    /// </summary>
    public class HurtSystem : MonoBehaviour
    {
        //1. public ���}�G�Ҧ����O���i�s��
        //2. private �p�H�G�ȭ������O�i�s��
        //3. protected �O�@�G�ȭ������O�P��l���O�i�s��

        [SerializeField, Header("��q"), Range(0, 10000)]
        protected float hp = 50;

        //vartual �����G���\�l���O�ϥ� override �мg������
        ///<summary>
        ///����ˮ`
        ///</summary>
        ///<param name="damage">���쪺�ˮ`��</param>
        public virtual void GetHurt(float damage)
        {
            if (hp <= 0) return;
            
            hp -= damage;
            //print("<color=#887700>����ˮ`�G" + damage + "</color>");

            if (hp <= 0) Dead();
        }
        /// <summary>
        /// ���`
        /// </summary>
        protected virtual void Dead()
        {
            hp = 0;
            //print("<color = #887700>���⦺�`�G" + gameObject + "</color>");
        }
    }
}

