using UnityEngine;

namespace Tian
{
    /* Data����
     �Z�����
    1.����t��
    2.�����O
    3.�_�l�ƶq
    4.�̤j�ƶq
    5.���j�ɶ�
    6.�ͦ���m
    7.�Z���w�s��
    8.�����V
    //ScriptableObject �}���ƪ���
    //�@�ΡG�N�}��������ܦ������x�s�� Project �� (�X�R�M���@�ʨ�)
    //CreateAssetMenu �P ScriptableObject �f�t�ϥ�
    //�@�ΡG�bProject �إߦ��}���ƪ��󪺿��P�ɮצW��
    //menuName ���W�١BfileName �ɮצW��
     */
    [CreateAssetMenu(menuName = "Tian/Data Weapon", fileName = "Data Weapon")]
    public class DataWeapon : ScriptableObject
    {
        [Header("����t��"), Range(0, 5000)]
        public float speed = 500;
        [Header("�����O"), Range(0, 100)]
        public float attack = 10;
        [Header("�_�l�ƶq"), Range(1, 30)]
        public int countStart = 15;
        [Header("�̤j�ƶq"), Range(1, 100)]
        public int countMax = 25;
        [Header("���j�ɶ�"), Range(0, 3)]
        public float interval = 1.2f;
        [Header("�l�u�g�{"), Range(0, 10)]
        public float bulletsTime;

        /* ����
        �������[]  �}�C  -  ��Ƶ��c
        �@�ΡG�x�s�h���ۦP���������
        */
        [Header("�ͦ���m")]
        public Vector3[] v3SpawnPoint;
        [Header("�Z���w�s��")]
        public GameObject goWeapon;
        [Header("�����V")]
        public Vector3 v3Direction;

    }

}

