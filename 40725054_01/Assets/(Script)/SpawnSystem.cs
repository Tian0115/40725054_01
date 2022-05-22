using UnityEngine;

namespace Tian
{
    /// <summary>
    /// �ͦ��t��
    /// </summary>
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField, Header("�ͦ��ĤH����")]
        private GameObject goEnemy;
        [SerializeField, Header("�ĤH�ͦ��I")]
        private Transform[] traSpawn;
        [SerializeField, Header("�ͦ�����"), Range(0, 3)]
        private float delay = 1;
        [SerializeField, Header("�ͦ����j"), Range(0, 3)]
        private float interval = 0.7f;

        private void Awake()
        {
            //���ƩI�s(�覡�W�١A����ɶ��A���j�ɶ�)
            InvokeRepeating("Spawn", delay, interval);
        }

        /// <summary>
        /// �ͦ�
        /// </summary>
        private void Spawn()
        {
            int ran = Random.Range(0, traSpawn.Length);
            Instantiate(goEnemy, traSpawn[ran].position, Quaternion.identity);
        }
    }

}

