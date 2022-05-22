using UnityEngine;

namespace Tian
{
    /* Description
     
    �Z���t�ΡG
     1.�]�w���a���o���Z��
     2.�ͦ��Z��
     3.�o�g�Z��
     4.�����O�x�s

     */
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField, Header("�Z�����")]
        private DataWeapon dataWeapon;
        private Animator ani;
        private string paraneterFire = "Fire";

        /*[SerializeField, Header("�Z���R���ɶ�"), Range(0, 10)]
        public float destoryWeaponTime = 3;*/



        //�p�ɾ�
        private float timer;

        /* Description
         ø�s�ϥܨƥ� ODG
        ODG �b�s�边�����U�ΡA�����ɤ��|�۰�����
        //���U�}�o
         */
        private void OnDrawGizmos()
        {
            //1.  �M�w�ϥ��C��
            //Color(red, green, blue, transparent) - 0 ~ 1
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            //2.  ø�s�ϥ�
            // �ϥ�. ø�s�y��(�����I�A�b�|)
            // ���o�}�C��ƻy�k�G�}�C��ƦW��[���ޭ�]

            // for �j��  �G ���ƳB�z�{���϶�
            //   ��l��; ����; �j�鵲���|����{��
            for (int i = 0; i < dataWeapon.v3SpawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(transform.position + dataWeapon.v3SpawnPoint[i], 0.1f);
            }



        }

        private void Start()
        {
            //2D ���z  �����ϼh�I�� (�ϼh�s���A�ϼh�s��)
            Physics2D.IgnoreLayerCollision(3, 6);
            Physics2D.IgnoreLayerCollision(6, 6);
            Physics2D.IgnoreLayerCollision(6, 7);


        }
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            SpawnWeapon();
            //Fire();
        }
        /*  Description
         �ͦ��Z��
         1.    �p��ɶ�
         2.    �ɶ��ֿn�춡�j�ɶ�
         3.    �ͦ��Z��
         4.    ���w�ͦ���m�W
         5.    �o�g�Z��
         6.    �ᤩ�Z�������O
         
         */
        private void SpawnWeapon()
        {
            // Time.deltaTime �@�Ӽv�檺�ɶ�
            timer += Time.deltaTime;

            //print("�g�L���ɶ��G" + timer);

            //�p�G�p�ɾ� �j�󵥩� ����ɶ�  �N�ͦ�  �Z��

            if (timer >= dataWeapon.interval)
            {
                //print("�ͦ��Z��");
                // �H���� = �H��.�d�� (�̤p�ȡA�̤j��)  -  ��Ƥ��]�t�̤j��
                int random = Random.Range(0, dataWeapon.v3SpawnPoint.Length);
                // �y��
                Vector3 pos = transform.position + dataWeapon.v3SpawnPoint[random];

                //Quaternion �|�줸�G�������׸�T����
                //Quaternion.identity �s����( 0, 0, 0)
                //�ͦ�(����A�y�СA����)
                GameObject temp = Instantiate(dataWeapon.goWeapon, pos, Quaternion.identity);
                timer = 0;

                // �Ȧs�Z�� . ���o����<����>().�K�[���O (��V * �t��)
                temp.GetComponent<Rigidbody2D>().AddForce(dataWeapon.v3Direction * dataWeapon.speed);
                ani.SetBool(paraneterFire, true);

                //�R������(�n�R��������A����R���ɶ�)
                Destroy(temp, dataWeapon.bulletsTime);

                //���o�Z���B�����O = �Z����ơB�����O
                temp.GetComponent<Weapon>().attack = dataWeapon.attack;
            } else if ( timer <= dataWeapon.interval)
            {
                ani.SetBool(paraneterFire, false);
            }

        }
        private void Fire()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnWeapon();
            }
        }

    }
}

