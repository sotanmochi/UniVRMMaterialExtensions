using UniGLTF;
using UnityEngine;

namespace UniVRM10.Extensions.Materials.lilToon
{
    public class lilToonVrm10MaterialExporter : IMaterialExporter
    {
        public UrpGltfMaterialExporter GltfExporter { get; set; } = new();
        public UrpVrm10MToonMaterialExporter MToonExporter { get; set; } = new();
        public lilToonSimpleMaterialExporter lilToonSimpleExporter { get; set; } = new();

        public glTFMaterial ExportMaterial(Material m, ITextureExporter textureExporter, GltfExportSettings settings)
        {
            glTFMaterial dst;

            if (lilToonSimpleExporter.TryExportMaterial(m, textureExporter, out dst))
            {
                return dst;
            }
            else if (MToonExporter.TryExportMaterial(m, textureExporter, out dst))
            {
                return dst;
            }
            else
            {
                return GltfExporter.ExportMaterial(m, textureExporter, settings);
            }
        }
    }
}
