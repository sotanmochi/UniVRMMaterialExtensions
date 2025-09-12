using UniGLTF;
using UnityEngine;
using UniVRM10.Extensions.Materials.lilToon;
#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif


namespace UniVRM10.Extensions.Materials
{
    [ScriptedImporter(1, null, new[] { "vrm" })] // Optional Importer
    public class VrmScriptedImporter : ScriptedImporter
    {
        [SerializeField]
        public bool MigrateToVrm1 = true;

        [SerializeField]
        public ImportMaterialTypes MaterialType = default;

        public override void OnImportAsset(AssetImportContext ctx)
        {
            VrmScriptedImporterImpl.Import(this, ctx, MigrateToVrm1, GetMaterialDescriptorGenerator);
        }

        public IMaterialDescriptorGenerator GetMaterialDescriptorGenerator()
        {
            return MaterialType switch
            {
                ImportMaterialTypes.lilToon => new lilToonMaterialDescriptorGenerator(),
                ImportMaterialTypes.MToon_UniversalRenderPipeline => Vrm10MaterialDescriptorGeneratorUtility.GetVrm10MaterialDescriptorGenerator(RenderPipelineTypes.UniversalRenderPipeline),
                ImportMaterialTypes.MToon_BuiltinRenderPipeline => Vrm10MaterialDescriptorGeneratorUtility.GetVrm10MaterialDescriptorGenerator(RenderPipelineTypes.BuiltinRenderPipeline),
                _ => Vrm10MaterialDescriptorGeneratorUtility.GetValidVrm10MaterialDescriptorGenerator(),
            };
        }
    }
}
