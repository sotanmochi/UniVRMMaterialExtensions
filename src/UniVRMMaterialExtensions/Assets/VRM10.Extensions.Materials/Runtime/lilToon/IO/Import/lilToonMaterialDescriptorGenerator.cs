using UniGLTF;
using UnityEngine;

namespace UniVRM10.Extensions.Materials.lilToon
{
    public sealed class lilToonMaterialDescriptorGenerator : IMaterialDescriptorGenerator
    {
        public RenderPipelineType RenderPipelineType { get; } = RenderPipelineUtility.GetRenderPipelineType();
        public UrpGltfPbrMaterialImporter PbrMaterialImporter { get; } = new();
        public UrpGltfDefaultMaterialImporter DefaultMaterialImporter { get; } = new();

        public MaterialDescriptor Get(GltfData data, int i)
        {
            // lilToon
            if (lilToonSimpleMaterialImporter.TryCreateParam(data, i, out var matDesc)) return matDesc;
            // MToon
            if (RenderPipelineType == RenderPipelineType.BuiltinRenderPipeline)
            {
                if (BuiltInVrm10MToonMaterialImporter.TryCreateParam(data, i, out matDesc)) return matDesc;
            }
            else if (RenderPipelineType == RenderPipelineType.UniversalRenderPipeline)
            {
                if (UrpVrm10MToonMaterialImporter.TryCreateParam(data, i, out matDesc)) return matDesc;
            }
            // Unlit
            if (BuiltInGltfUnlitMaterialImporter.TryCreateParam(data, i, out matDesc)) return matDesc;
            // Pbr
            if (PbrMaterialImporter.TryCreateParam(data, i, out matDesc)) return matDesc;

            // NOTE: Fallback to default material
            if (Symbols.VRM_DEVELOP)
            {
                Debug.LogWarning($"material: {i} out of range. fallback");
            }
            return GetGltfDefault(GltfMaterialImportUtils.ImportMaterialName(i, null));
        }

        public MaterialDescriptor GetGltfDefault(string materialName = null) => DefaultMaterialImporter.CreateParam(materialName);
    }
}
