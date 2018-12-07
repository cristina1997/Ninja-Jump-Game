using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExportPackages : MonoBehaviour {

    [MenuItem("Export/MyExport")]
    static void Export()
    {
        AssetDatabase.ExportPackage(AssetDatabase.GetAllAssetPaths(), PlayerSettings.productName + ".unitypackage", ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies | ExportPackageOptions.IncludeLibraryAssets);
    }
}
