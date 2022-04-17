using UnityEngine;


//�R�W�Ŷ� �Ŷ��W��
// �h�H�}�o�i�H�ϥΩR�W�Ŷ��Ϲj�t���קK�Ĭ�
   namespace Tian
  {
    public class TopDownController : MonoBehaviour
    {
        #region ��ơG�O�s�t�λݭn���򥻸�ơG���ʳt�סB�ʵe�ѼƦW�ٻP����
        //
        [SerializeField, Header("���ʳt��"), Range(0, 100)]
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

        #region �ƥ�G�{���J�f (Unity)�A���Ѷ}�o���X�ʨt�Ϊ����f

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

        #region �覡�G���������\�� 
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

            #region �T���B��
            //�T���B��
            /*�x���� : https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/conditiional-operator  */
            //���L�� ? ���L�� = true : ���L�� = false
            //���� >=0 ���� 0 �_�h ���� 180
            //�ܧΤ���.�שԨ�(eulerAngles) = �s �T���V�q(x, y, z)
            #endregion

            transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0);

        }


        #endregion
    }
}


