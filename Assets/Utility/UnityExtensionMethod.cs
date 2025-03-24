using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtensionMethod
{
    /// <summary>
    /// Transform.gameObject 하기싫어서 만든 확장메서드
    /// </summary>
    /// <param name="tf">Transform</param>
    /// <param name="active">활성화 상태</param>
    public static void SetActive(this Transform tf, bool active)
    {
        tf.gameObject.SetActive(active);
    }
}