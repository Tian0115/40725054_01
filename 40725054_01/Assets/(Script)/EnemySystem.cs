using UnityEngine;

namespace Tian
{
    /// <summary>
    /// �ĤH�t��
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("�ĤH���")]
        private DataEnemy data;
        [SerializeField, Header("���a����W��")]
        private string namePlayer = "Player";

        private Transform traPlayer;
        /// <summary>
        /// �����p�ɾ�
        /// </summary>
        private float timerAttack;

        private Animator ani;
        private string parameterAttack = "Attack Trigger";

        private void Awake()
        {

            ani = GetComponent<Animator>();
            // ���a�ܧ� = �C������.��M(����W��) �� �ܧ�
            traPlayer = GameObject.Find(namePlayer).transform;

          /**  //�ƾ�.���� (A�AB�A�ʤ���)
            float result = Mathf.Lerp(0, 100, 0.5f);
            print("0 �P 100 �� 0.5 ���ȵ��G�G" + result);
          */
        }

        private void Update()
        {
            /** ���մ���
              a = Mathf.Lerp(a, b, 0.5f);
             print("���յ��G�G" + a);
            */
            MoveToPlayer();
        }

        /*private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.5f, 0, 0.5f);
            Gizmos.DrawSphere(transform.position, data.stopDistance);
        }*/

        /// <summary>
        /// ���ʨ쪱�a����m
        /// </summary>
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;   //A�I�G�ĤH�y��
            Vector3 posPlayer = traPlayer.position;    //B�I�G���a�y��

            float dis = Vector3.Distance(posEnemy, posPlayer);
            //print("<color=yellow>�Z���G" + dis + "</color>");

            if(dis < data.stopDistance)
            {
                Attack();
            }
            else
            {
                // �ĤH�y�� = ���� (�ĤH�y�СA���a�y�СA�ʤ��� * �t�� * �@�V���ɶ�)
                transform.position = Vector3.Lerp(posEnemy, posPlayer, 0.5f * data.speed * Time.deltaTime);

                float y = transform.position.x > traPlayer.position.x ? 180 : 0;
                transform.eulerAngles = new Vector3(0, y, 0);
            }

        }

        private void Attack()
        {
            if (timerAttack < data.cd)
            {
                timerAttack += Time.deltaTime;
                //print("<color=red>�����p�ɾ��G" + timerAttack + "</color>");
            }
            else
            {
                ani.SetTrigger(parameterAttack);
                timerAttack = 0;
            }
        }
    }
}

