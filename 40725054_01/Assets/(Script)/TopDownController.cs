using UnityEngine;


//命名空間 空間名稱
// 多人開發可以使用命名空間區隔系統避免衝突
   namespace Tian
  {
    public class TopDownController : MonoBehaviour
    {
        #region 資料：保存系統需要的基本資料：移動速度、動畫參數名稱與元件等
        //
        [SerializeField, Header("移動速度"), Range(0, 100)]
        private float speed = 5f;
        private string parameterRun = "walk";
        //private string parameterDead = "dead";
        private string parameterFire = "fire";
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float v;

        private WeaponSystem weaponSystem;

        #endregion

        #region 事件：程式入口 (Unity)，提供開發者驅動系統的窗口

        private void Awake()
        {
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

        }
        private void Update()
        {
            GetInput();
            Move();

        }

        #endregion

        #region 方式：較複雜的功能 
        private void GetInput()
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        private void Move()
        {
            rig.velocity = new Vector2(h, v) * speed;

            ani.SetBool(parameterRun, h != 0 || v != 0);
            ani.SetBool(parameterFire, h != 0);

            #region 三元運算
            //三元運算
            /*官方文件 : https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/conditiional-operator  */
            //布林值 ? 布林值 = true : 布林值 = false
            //水平 >=0 角度 0 否則 角度 180
            //變形元件.尤拉角(eulerAngles) = 新 三維向量(x, y, z)
            #endregion

            transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0);

        }


        #endregion
    }
}


