using UnityEngine;

//命名空間 空間名稱
// 多人開發可以使用命名空間區隔系統避免衝突
   namespace Tian
  {
    public class TopDownController : MonoBehaviour
    {
        #region 資料：保存系統需要的基本資料：移動速度、動畫參數名稱與元件等
        //
        private float speed = 10.5f;
        private string parameterRun = "開關跑步";
        private string parameterDead = "開關死亡";
        private Animator ani;
        private Rigidbody2D rig;
        #endregion

        #region 事件：程式入口 (Unity)，提供開發者驅動系統的窗口

        #endregion

        #region 方式：較複雜的功能

        #endregion
    }
}


