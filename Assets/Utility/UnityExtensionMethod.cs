using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtensionMethod
{
    /// <summary>
    /// Transform.gameObject �ϱ�Ⱦ ���� Ȯ��޼���
    /// </summary>
    /// <param name="tf">Transform</param>
    /// <param name="active">Ȱ��ȭ ����</param>
    public static void SetActive(this Transform tf, bool active)
    {
        tf.gameObject.SetActive(active);
    }
}