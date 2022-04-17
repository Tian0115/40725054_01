using UnityEngine;

namespace Tian
{
    /* Description
     
    武器系統：
     1.設定玩家取得的武器
     2.生成武器
     3.發射武器
     4.攻擊力儲存

     */
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("武器資料")]
        private DataWeapon dataWeapon;


        //計時器
        private float timer;

        /* Description
         繪製圖示事件 ODG
        ODG 在編輯器內輔助用，執行檔中會自動隱藏
        //輔助開發
         */
        private void OnDrawGizmos()
        {
            //1.  決定圖示顏色
            //Color(red, green, blue, transparent) - 0 ~ 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            //2.  繪製圖示
            // 圖示. 繪製球體(中心點，半徑)
            // 取得陣列資料語法：陣列資料名稱[索引值]

            // for 迴圈  ： 重複處理程式區塊
            //   初始值; 條件; 迴圈結束會執行程式
            for (int i = 0; i < dataWeapon.v3SpawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(transform.position + dataWeapon.v3SpawnPoint[i], 0.1f);
            }



        }

        private void Update()
        {
            SpawnWeapon();
        }
        /*  Description
         生成武器
         1.    計算時間
         2.    時間累積到間隔時間
         3.    生成武器
         4.    指定生成位置上
         5.    發射武器
         6.    賦予武器攻擊力
         
         */
        private void SpawnWeapon()
        {
            // Time.deltaTime 一個影格的時間
            timer += Time.deltaTime;

            //print("經過的時間：" + timer);

            //如果計時器 大於等於 間格時間  就生成  武器

            if (timer >= dataWeapon.interval)
            {
                print("生成武器");
                timer = 0;
            }
        }

    }
}

