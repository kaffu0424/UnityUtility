using UnityEngine;

public enum DataType
{
    NULL,
    Scriptable,
    Prefab
    /* enum 값 필요하면 추가해주세요.
     * 생성하고싶은 폴더명을 추가해주세요.
     * DataType을 넣지않고 DataLoad를 호출하면
     * 제네릭타입 이름의 폴더에서 파일을 가져옵니다!
     */
}

public static class ResourcesLoader
{
    public static T DataLoad<T>(string fileName, DataType type = DataType.NULL) where T : UnityEngine.Object
    {
        // DataType을 할당하지않았을때 : 폴더명 typeof(T).Name
        // DataType을 할당했을때 : 폴더명 DataType.ToString();
        string folderName = type == DataType.NULL 
            ? $"{typeof(T).Name}" : type.ToString();

        string path = $"{folderName}/{fileName}";
        T data = Resources.Load<T>(path);

        if(data == null)
        {
            Debug.LogWarning($"[ResourcesLoader] {path} Error");
        }

        return data;
    }
}