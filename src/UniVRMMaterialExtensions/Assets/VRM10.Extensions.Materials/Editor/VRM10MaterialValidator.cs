using System.Collections.Generic;
using UnityEngine;

namespace UniVRM10.Extensions.Materials
{
    class VRM10MaterialValidator : UniGLTF.DefaultMaterialValidator
    {
        const string MTOON_SHADER_NAME = "VRM10/MToon10";

        public override string GetGltfMaterialTypeFromUnityShaderName(string shaderName)
        {
            switch (shaderName)
            {
                case MTOON_SHADER_NAME:
                    return "VRMC_materials_mtoon";
            }

            return base.GetGltfMaterialTypeFromUnityShaderName(shaderName);
        }

        public override IEnumerable<(string propertyName, Texture texture)> EnumerateTextureProperties(Material m)
        {
            if (m.shader.name == MTOON_SHADER_NAME)
            {
            }
            else
            {
                foreach (var x in base.EnumerateTextureProperties(m))
                {
                    yield return x;
                }
            }
        }
    }
}
