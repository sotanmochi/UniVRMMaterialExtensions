using UniGLTF.MeshUtility;
using UnityEditor;
using UniVRM10;

namespace UniVRM10.Extensions.Materials
{
    public static class Vrm10TopMenuExtension
    {
        private const string UserMenuPrefix = VRM10SpecVersion.MENU;
        private const string DevelopmentMenuPrefix = VRM10SpecVersion.MENU + "/Development";

        [MenuItem(UserMenuPrefix + "/" + ModifiedExportDialog.MENU_NAME, priority = 10)]
        private static void OpenExportDialog() => ModifiedExportDialog.Open();

#if VRM_MATERIAL_EXTENSIONS_DEVELOP
        [MenuItem(DevelopmentMenuPrefix + "/Generate lilToon serializer from JsonSchema", false, 1000)]
        private static void GenerateLilToon() => lilToonMaterialSerializerGenerator.Run(debug: false);

        [MenuItem(DevelopmentMenuPrefix + "/Generate lilToon serializer from JsonSchema(debug)", false, 1001)]
        private static void ParseLilToon() => lilToonMaterialSerializerGenerator.Run(debug: true);
#endif
    }
}
