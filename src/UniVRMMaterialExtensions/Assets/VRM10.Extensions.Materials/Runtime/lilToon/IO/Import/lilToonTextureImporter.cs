using System;
using System.Collections.Generic;
using UniGLTF;
using UniGLTF.Extensions.EXT_materials_liltoon_simple;
using UnityEngine;

namespace UniVRM10.Extensions.Materials.lilToon
{
    public static class lilToonTextureImporter
    {
        public static IEnumerable<(string key, (SubAssetKey, TextureDescriptor))> EnumerateAllTextures(GltfData data, EXT_materials_liltoon_simple lilToon)
        {
            if (TryGetDitherTexture(data, lilToon, out var key, out var desc))
            {
                yield return (lilToonPropertyType.DitherTex.ToUnityShaderLabName(), (key, desc));
            }

            // Main Color
            if (TryGetMainColorTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.MainTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetMainGradationTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.MainGradationTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetMainColorAdjustMaskTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.MainColorAdjustMask.ToUnityShaderLabName(), (key, desc));
            }

            // Alpha
            if (TryGetAlphaMaskTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.AlphaMask.ToUnityShaderLabName(), (key, desc));
            }

            // Shadow
            if (TryGetShadowStrengthMaskTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.ShadowStrengthMask.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetShadowColorTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.ShadowColorTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetShadow2ndColorTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.Shadow2ndColorTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetShadow3rdColorTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.Shadow3rdColorTex.ToUnityShaderLabName(), (key, desc));
            }

            // Emission
            if (TryGetEmissionTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.EmissionTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetEmissionBlendMaskTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.EmissionBlendMask.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetEmission2ndTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.Emission2ndTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetEmission2ndBlendMaskTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.Emission2ndBlendMask.ToUnityShaderLabName(), (key, desc));
            }

            // Normal
            if (TryGetNormalTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.NormalTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetNormal2ndTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.Normal2ndTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetNormal2ndTexScaleMaskTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.Normal2ndTexScaleMask.ToUnityShaderLabName(), (key, desc));
            }

            // MatCap
            if (TryGetMatCapTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.MatCapTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetMatCapBlendMaskTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.MatCapBlendMask.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetMatCap2ndTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.MatCap2ndTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetMatCap2ndBlendMaskTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.MatCap2ndBlendMask.ToUnityShaderLabName(), (key, desc));
            }

            // Rim Lighting
            if (TryGetRimColorTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.RimColorTex.ToUnityShaderLabName(), (key, desc));
            }

            // Outline
            if (TryGetOutlineTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.OutlineTex.ToUnityShaderLabName(), (key, desc));
            }

            if (TryGetOutlineWithMaskTexture(data, lilToon, out key, out desc))
            {
                yield return (lilToonPropertyType.OutlineWidthMask.ToUnityShaderLabName(), (key, desc));
            }
        }

        private static bool TryGetDitherTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.DitherTex), out key, out desc);
        }

        // Main Color
        private static bool TryGetMainColorTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.MainTex), out key, out desc);
        }

        private static bool TryGetMainGradationTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.MainGradationTex), out key, out desc);
        }

        private static bool TryGetMainColorAdjustMaskTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.MainColorAdjustMask), out key, out desc);
        }

        // Alpha
        private static bool TryGetAlphaMaskTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.AlphaMask), out key, out desc);
        }

        // Shadow
        private static bool TryGetShadowStrengthMaskTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.ShadowStrengthMask), out key, out desc);
        }

        private static bool TryGetShadowColorTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.ShadowColorTex), out key, out desc);
        }

        private static bool TryGetShadow2ndColorTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.Shadow2ndColorTex), out key, out desc);
        }

        private static bool TryGetShadow3rdColorTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.Shadow3rdColorTex), out key, out desc);
        }

        // Emission
        private static bool TryGetEmissionTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.EmissionTex), out key, out desc);
        }

        private static bool TryGetEmissionBlendMaskTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.EmissionBlendMask), out key, out desc);
        }

        private static bool TryGetEmission2ndTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.Emission2ndTex), out key, out desc);
        }

        private static bool TryGetEmission2ndBlendMaskTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.Emission2ndBlendMask), out key, out desc);
        }

        // Normal
        private static bool TryGetNormalTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetLinearTexture(data, new Vrm10TextureInfo(lilToon.NormalTex), out key, out desc);
        }

        private static bool TryGetNormal2ndTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetLinearTexture(data, new Vrm10TextureInfo(lilToon.Normal2ndTex), out key, out desc);
        }

        private static bool TryGetNormal2ndTexScaleMaskTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetLinearTexture(data, new Vrm10TextureInfo(lilToon.Normal2ndTexScaleMask), out key, out desc);
        }

        // MatCap
        private static bool TryGetMatCapTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.MatCapTex), out key, out desc);
        }

        private static bool TryGetMatCapBlendMaskTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.MatCapBlendMask), out key, out desc);
        }

        private static bool TryGetMatCap2ndTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.MatCap2ndTex), out key, out desc);
        }

        private static bool TryGetMatCap2ndBlendMaskTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.MatCap2ndBlendMask), out key, out desc);
        }

        // Rim Lighting
        private static bool TryGetRimColorTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.RimColorTex), out key, out desc);
        }

        // Outline
        private static bool TryGetOutlineTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.OutlineTex), out key, out desc);
        }

        private static bool TryGetOutlineWithMaskTexture(GltfData data, EXT_materials_liltoon_simple lilToon, out SubAssetKey key, out TextureDescriptor desc)
        {
            return TryGetSRGBTexture(data, new Vrm10TextureInfo(lilToon.OutlineWidthMask), out key, out desc);
        }

        private static bool TryGetSRGBTexture(GltfData data, Vrm10TextureInfo info, out SubAssetKey key, out TextureDescriptor desc)
        {
            try
            {
                var (offset, scale) = GetTextureOffsetAndScale(info);
                return GltfTextureImporter.TryCreateSrgb(data, info.index, offset, scale, out key, out desc);
            }
            catch (NullReferenceException)
            {
                key = default;
                desc = default;
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                key = default;
                desc = default;
                return false;
            }
        }

        private static bool TryGetLinearTexture(GltfData data, Vrm10TextureInfo info, out SubAssetKey key, out TextureDescriptor desc)
        {
            try
            {
                var (offset, scale) = GetTextureOffsetAndScale(info);
                return GltfTextureImporter.TryCreateLinear(data, info.index, offset, scale, out key, out desc);
            }
            catch (NullReferenceException)
            {
                key = default;
                desc = default;
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                key = default;
                desc = default;
                return false;
            }
        }

        private static (Vector2, Vector2) GetTextureOffsetAndScale(Vrm10TextureInfo textureInfo)
        {
            if (glTF_KHR_texture_transform.TryGet(textureInfo, out var textureTransform))
            {
                return GltfTextureImporter.GetTextureOffsetAndScale(textureTransform);
            }
            return (new Vector2(0, 0), new Vector2(1, 1));
        }

        private sealed class Vrm10TextureInfo : glTFTextureInfo
        {
            public Vrm10TextureInfo(TextureInfo info)
            {
                if (info == null) return;

                index = info.Index ?? -1;
                texCoord = info.TexCoord ?? -1;
                extensions = info.Extensions as glTFExtension;
                extras = info.Extras as glTFExtension;
            }
        }
    }
}
