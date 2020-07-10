# UniJsonBuildReport

BuildReport を JSON 形式で出力できるようにする機能

## 使用例

```cs
using Kogane;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class Example : IPostprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPostprocessBuild( BuildReport report )
    {
        Debug.Log( JsonUtility.ToJson( new JsonBuildReport( report ), true ) );
    }
}
```
