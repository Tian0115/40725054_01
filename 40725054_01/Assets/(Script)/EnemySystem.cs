using UnityEngine;

namespace Tian
{
    /// <summary>
    /// 敵人系統
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;
        [SerializeField, Header("玩家物件名稱")]
        private string namePlayer = "Player";

        private Transform traPlayer;
        /// <summary>
        /// 攻擊計時器
        /// </summary>
        private float timerAttack;

        private Animator ani;
        private string parameterAttack = "Attack Trigger";

        private void Awake()
        {

            ani = GetComponent<Animator>();
            // 玩家變形 = 遊戲物件.找尋(物件名稱) 的 變形
            traPlayer = GameObject.Find(namePlayer).transform;

          /**  //數學.插值 (A，B，百分比)
            float result = Mathf.Lerp(0, 100, 0.5f);
            print("0 與 100 的 0.5 插值結果：" + result);
          */
        }

        private void Update()
        {
            /** 測試插值
              a = Mathf.Lerp(a, b, 0.5f);
             print("測試結果：" + a);
            */
            MoveToPlayer();
        }

        /*private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0.5f, 0, 0.5f);
            Gizmos.DrawSphere(transform.position, data.stopDistance);
        }*/

        /// <summary>
        /// 移動到玩家的位置
        /// </summary>
        private void MoveToPlayer()
        {
            Vector3 posEnemy = transform.position;   //A點：敵人座標
            Vector3 posPlayer = traPlayer.position;    //B點：玩家座標

            float dis = Vector3.Distance(posEnemy, posPlayer);
            //print("<color=yellow>距離：" + dis + "</color>");

            if(dis < data.stopDistance)
            {
                Attack();
            }
            else
            {
                // 敵人座標 = 插值 (敵人座標，玩家座標，百分比 * 速度 * 一幀的時間)
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
                //print("<color=red>攻擊計時器：" + timerAttack + "</color>");
            }
            else
            {
                ani.SetTrigger(parameterAttack);
                timerAttack = 0;
            }
        }
    }
}

