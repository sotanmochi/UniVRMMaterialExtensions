using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UniGLTF.Extensions.EXT_materials_liltoon_simple;
using UnityEngine;
using ColorSpace = UniGLTF.ColorSpace;

namespace UniVRM10.Extensions.Materials.lilToon
{
    public static class lilToonSimpleMaterialImporter
    {
        public static bool TryCreateParam(GltfData data, int i, out MaterialDescriptor matDesc)
        {
            var material = data.GLTF.materials[i];

            if (!UniGLTF.Extensions.EXT_materials_liltoon_simple.GltfDeserializer.TryGet(material.extensions, out var lilToon))
            {
                // Fallback to MToon or glTF material, when lilToon extension does not exist.
                matDesc = default;
                return false;
            }

            var shaderName = (lilToon.RenderingMode, lilToon.UseOutline) switch
            {
                (RenderingMode.Opaque, true) => lilToonShaderNames.OpaqueOutlineShader,
                (RenderingMode.Opaque, false) => lilToonShaderNames.OpaqueShader,
                (RenderingMode.Cutout, true) => lilToonShaderNames.CutoutOutlineShader,
                (RenderingMode.Cutout, false) => lilToonShaderNames.CutoutShader,
                (RenderingMode.Transparent, true) => lilToonShaderNames.TransparentOutlineShader,
                (RenderingMode.Transparent, false) => lilToonShaderNames.TransparentShader,
                _ => lilToonShaderNames.OpaqueShader
            };

            var shader = Shader.Find(shaderName);
            if (shader == null)
            {
                Debug.LogError($"The '{shaderName}' shader is not found. Fallback to the default shader.");
                matDesc = default;
                return false;
            }

            var renderQueue = lilToon?.RenderQueue;

            // Use material.name, because material name may renamed in GltfParser.
            matDesc = new MaterialDescriptor(
                material.name,
                shader,
                renderQueue,
                lilToonTextureImporter.EnumerateAllTextures(data, lilToon).ToDictionary(tuple => tuple.key, tuple => tuple.Item2.Item2),
                TryGetAllFloats(lilToon).ToDictionary(tuple => tuple.key, tuple => tuple.value),
                TryGetAllColors(lilToon).ToDictionary(tuple => tuple.key, tuple => tuple.value),
                TryGetAllFloatArrays(lilToon).ToDictionary(tuple => tuple.key, tuple => tuple.value),
                new Action<Material>[]
                {
                    material =>
                    {
                        // Set hidden properties, keywords from float properties.
                        new lilToonValidator(material).Validate();
                    }
                });

            return true;
        }

        public static IEnumerable<(string key, Color value)> TryGetAllColors(EXT_materials_liltoon_simple lilToon)
        {
            const ColorSpace gltfColorSpace = ColorSpace.Linear;

            // Main Color
            var mainColor = lilToon?.MainColor?.ToColor4(gltfColorSpace, ColorSpace.sRGB);
            if (mainColor.HasValue)
            {
                yield return (lilToonPropertyType.MainColor.ToUnityShaderLabName(), mainColor.Value);
            }

            // Shadow
            var shadowColor = lilToon?.ShadowColor?.ToColor4(gltfColorSpace, ColorSpace.sRGB);
            if (shadowColor.HasValue)
            {
                yield return (lilToonPropertyType.ShadowColor.ToUnityShaderLabName(), shadowColor.Value);
            }

            var shadow2ndColor = lilToon?.Shadow2ndColor?.ToColor4(gltfColorSpace, ColorSpace.sRGB);
            if (shadow2ndColor.HasValue)
            {
                yield return (lilToonPropertyType.Shadow2ndColor.ToUnityShaderLabName(), shadow2ndColor.Value);
            }

            var Shadow3rdColor = lilToon?.Shadow3rdColor?.ToColor4(gltfColorSpace, ColorSpace.sRGB);
            if (Shadow3rdColor.HasValue)
            {
                yield return (lilToonPropertyType.Shadow3rdColor.ToUnityShaderLabName(), Shadow3rdColor.Value);
            }

            var ShadowBorderColor = lilToon?.ShadowBorderColor?.ToColor3(gltfColorSpace, ColorSpace.sRGB);
            if (ShadowBorderColor.HasValue)
            {
                yield return (lilToonPropertyType.ShadowBorderColor.ToUnityShaderLabName(), ShadowBorderColor.Value);
            }

            // Emission
            // Emissive factor should be stored in Linear space
            var emissionColor = lilToon?.EmissionColor?.ToColor4(gltfColorSpace, ColorSpace.Linear);
            if (emissionColor.HasValue)
            {
                yield return (lilToonPropertyType.EmissionColor.ToUnityShaderLabName(), emissionColor.Value);
            }

            var emission2ndColor = lilToon?.Emission2ndColor?.ToColor4(gltfColorSpace, ColorSpace.Linear);
            if (emission2ndColor.HasValue)
            {
                yield return (lilToonPropertyType.Emission2ndColor.ToUnityShaderLabName(), emission2ndColor.Value);
            }

            // MatCap
            var matCapColor = lilToon?.MatCapColor?.ToColor4(gltfColorSpace, ColorSpace.sRGB);
            if (matCapColor.HasValue)
            {
                yield return (lilToonPropertyType.MatCapColor.ToUnityShaderLabName(), matCapColor.Value);
            }

            var matCap2ndColor = lilToon?.MatCap2ndColor?.ToColor4(gltfColorSpace, ColorSpace.sRGB);
            if (matCap2ndColor.HasValue)
            {
                yield return (lilToonPropertyType.MatCap2ndColor.ToUnityShaderLabName(), matCap2ndColor.Value);
            }

            // Rim Light
            var rimColor = lilToon?.RimColor?.ToColor4(gltfColorSpace, ColorSpace.sRGB);
            if (rimColor.HasValue)
            {
                yield return (lilToonPropertyType.RimColor.ToUnityShaderLabName(), rimColor.Value);
            }

            var rimIndirColor = lilToon?.RimIndirColor?.ToColor4(gltfColorSpace, ColorSpace.sRGB);
            if (rimIndirColor.HasValue)
            {
                yield return (lilToonPropertyType.RimIndirColor.ToUnityShaderLabName(), rimIndirColor.Value);
            }

            // Outline
            var outlineColor = lilToon?.OutlineColor?.ToColor4(gltfColorSpace, ColorSpace.sRGB);
            if (outlineColor.HasValue)
            {
                yield return (lilToonPropertyType.OutlineColor.ToUnityShaderLabName(), outlineColor.Value);
            }
        }

        public static IEnumerable<(string key, float value)> TryGetAllFloats(EXT_materials_liltoon_simple lilToon)
        {
            // Base Settings
            var cutoff = lilToon?.Cutoff;
            if (cutoff.HasValue)
            {
                yield return (lilToonPropertyType.Cutoff.ToUnityShaderLabName(), cutoff.Value);
            }

            var cull = lilToon?.Cull;
            if (cull.HasValue)
            {
                yield return (lilToonPropertyType.Cull.ToUnityShaderLabName(), (float)cull.Value);
            }

            var invisible = lilToon?.Invisible;
            if (invisible.HasValue)
            {
                yield return (lilToonPropertyType.Invisible.ToUnityShaderLabName(), invisible.Value ? 1.0f : 0.0f);
            }

            var zwrite = lilToon?.ZWrite;
            if (zwrite.HasValue)
            {
                yield return (lilToonPropertyType.ZWrite.ToUnityShaderLabName(), zwrite.Value ? 1.0f : 0.0f);
            }
    
            var antiAliasStrength = lilToon?.AntiAliasStrength;
            if (antiAliasStrength.HasValue)
            {
                yield return (lilToonPropertyType.AntiAliasStrength.ToUnityShaderLabName(), antiAliasStrength.Value);
            }

            var useDither = lilToon?.UseDither;
            if (useDither.HasValue)
            {
                yield return (lilToonPropertyType.UseDither.ToUnityShaderLabName(), useDither.Value ? 1.0f : 0.0f);
            }

            var ditherMaxValue = lilToon?.DitherMaxValue;
            if (ditherMaxValue.HasValue)
            {
                yield return (lilToonPropertyType.DitherMaxValue.ToUnityShaderLabName(), ditherMaxValue.Value);
            }

            // Lighting Base Settings
            var lightMinLimit = lilToon?.LightMinLimit;
            if (lightMinLimit.HasValue)
            {
                yield return (lilToonPropertyType.LightMinLimit.ToUnityShaderLabName(), lightMinLimit.Value);
            }

            var lightMaxLimit = lilToon?.LightMaxLimit;
            if (lightMaxLimit.HasValue)
            {
                yield return (lilToonPropertyType.LightMaxLimit.ToUnityShaderLabName(), lightMaxLimit.Value);
            }

            var monochromeLighting = lilToon?.MonochromeLighting;
            if (monochromeLighting.HasValue)
            {
                yield return (lilToonPropertyType.MonochromeLighting.ToUnityShaderLabName(), monochromeLighting.Value);
            }

            var shadowEnvStrength = lilToon?.ShadowEnvStrength;
            if (shadowEnvStrength.HasValue)
            {
                yield return (lilToonPropertyType.ShadowEnvStrength.ToUnityShaderLabName(), shadowEnvStrength.Value);
            }

            // Main Color
            var mainGradationStrength = lilToon?.MainGradationStrength;
            if (mainGradationStrength.HasValue)
            {
                yield return (lilToonPropertyType.MainGradationStrength.ToUnityShaderLabName(), mainGradationStrength.Value);
            }

            // Alpha Mask
            var alphaMaskScale = lilToon?.AlphaMaskScale;
            if (alphaMaskScale.HasValue)
            {
                yield return (lilToonPropertyType.AlphaMaskScale.ToUnityShaderLabName(), alphaMaskScale.Value);
            }

            var alphaMaskValue = lilToon?.AlphaMaskValue;
            if (alphaMaskValue.HasValue)
            {
                yield return (lilToonPropertyType.AlphaMaskValue.ToUnityShaderLabName(), alphaMaskValue.Value);
            }

            // Shadow
            var useShadow = lilToon?.UseShadow;
            if (useShadow.HasValue)
            {
                yield return (lilToonPropertyType.UseShadow.ToUnityShaderLabName(), useShadow.Value ? 1.0f : 0.0f);
            }

            var shadowMaskType = lilToon?.ShadowMaskType;
            if (shadowMaskType.HasValue)
            {
                yield return (lilToonPropertyType.ShadowMaskType.ToUnityShaderLabName(), (float)shadowMaskType.Value);
            }

            var shadowStrength = lilToon?.ShadowStrength;
            if (shadowStrength.HasValue)
            {
                yield return (lilToonPropertyType.ShadowStrength.ToUnityShaderLabName(), shadowStrength.Value);
            }

            var shadowStrengthMaskLOD = lilToon?.ShadowStrengthMaskLOD;
            if (shadowStrengthMaskLOD.HasValue)
            {
                yield return (lilToonPropertyType.ShadowStrengthMaskLOD.ToUnityShaderLabName(), shadowStrengthMaskLOD.Value);
            }

            var shadowFlatBorder = lilToon?.ShadowFlatBorder;
            if (shadowFlatBorder.HasValue)
            {
                yield return (lilToonPropertyType.ShadowFlatBorder.ToUnityShaderLabName(), shadowFlatBorder.Value);
            }

            var shadowFlatBlur = lilToon?.ShadowFlatBlur;
            if (shadowFlatBlur.HasValue)
            {
                yield return (lilToonPropertyType.ShadowFlatBlur.ToUnityShaderLabName(), shadowFlatBlur.Value);
            }

            var shadowColorType = lilToon?.ShadowColorType;
            if (shadowColorType.HasValue)
            {
                yield return (lilToonPropertyType.ShadowColorType.ToUnityShaderLabName(), (float)shadowColorType.Value);
            }

            var shadowBorder = lilToon?.ShadowBorder;
            if (shadowBorder.HasValue)
            {
                yield return (lilToonPropertyType.ShadowBorder.ToUnityShaderLabName(), shadowBorder.Value);
            }

            var shadowBlur = lilToon?.ShadowBlur;
            if (shadowBlur.HasValue)
            {
                yield return (lilToonPropertyType.ShadowBlur.ToUnityShaderLabName(), shadowBlur.Value);
            }

            var shadowReceive = lilToon?.ShadowReceive;
            if (shadowReceive.HasValue)
            {
                yield return (lilToonPropertyType.ShadowReceive.ToUnityShaderLabName(), shadowReceive.Value);
            }

            var shadow2ndBorder = lilToon?.Shadow2ndBorder;
            if (shadow2ndBorder.HasValue)
            {
                yield return (lilToonPropertyType.Shadow2ndBorder.ToUnityShaderLabName(), shadow2ndBorder.Value);
            }

            var shadow2ndBlur = lilToon?.Shadow2ndBlur;
            if (shadow2ndBlur.HasValue)
            {
                yield return (lilToonPropertyType.Shadow2ndBlur.ToUnityShaderLabName(), shadow2ndBlur.Value);
            }

            var shadow2ndReceive = lilToon?.Shadow2ndReceive;
            if (shadow2ndReceive.HasValue)
            {
                yield return (lilToonPropertyType.Shadow2ndReceive.ToUnityShaderLabName(), shadow2ndReceive.Value);
            }

            var shadowBorderRange = lilToon?.ShadowBorderRange;
            if (shadowBorderRange.HasValue)
            {
                yield return (lilToonPropertyType.ShadowBorderRange.ToUnityShaderLabName(), shadowBorderRange.Value);
            }

            var shadowMainStrength = lilToon?.ShadowMainStrength;
            if (shadowMainStrength.HasValue)
            {
                yield return (lilToonPropertyType.ShadowMainStrength.ToUnityShaderLabName(), shadowMainStrength.Value);
            }

            // Emission
            var useEmission = lilToon?.UseEmission;
            if (useEmission.HasValue)
            {
                yield return (lilToonPropertyType.UseEmission.ToUnityShaderLabName(), useEmission.Value ? 1.0f : 0.0f);
            }

            var EmissionTexUVMode = lilToon?.EmissionTexUVMode;
            if (EmissionTexUVMode.HasValue)
            {
                yield return (lilToonPropertyType.EmissionTexUVMode.ToUnityShaderLabName(), (float)EmissionTexUVMode.Value);
            }

            var emissionMainStrength = lilToon?.EmissionMainStrength;
            if (emissionMainStrength.HasValue)
            {
                yield return (lilToonPropertyType.EmissionMainStrength.ToUnityShaderLabName(), emissionMainStrength.Value);
            }

            var emissionBlend = lilToon?.EmissionBlend;
            if (emissionBlend.HasValue)
            {
                yield return (lilToonPropertyType.EmissionBlend.ToUnityShaderLabName(), emissionBlend.Value);
            }

            var emissionBlendMode = lilToon?.EmissionBlendMode;
            if (emissionBlendMode.HasValue)
            {
                yield return (lilToonPropertyType.EmissionBlendMode.ToUnityShaderLabName(), (float)emissionBlendMode.Value);
            }

            var emissionFluorescence = lilToon?.EmissionFluorescence;
            if (emissionFluorescence.HasValue)
            {
                yield return (lilToonPropertyType.EmissionFluorescence.ToUnityShaderLabName(), emissionFluorescence.Value);
            }

            var useEmission2nd = lilToon?.UseEmission2nd;
            if (useEmission2nd.HasValue)
            {
                yield return (lilToonPropertyType.UseEmission2nd.ToUnityShaderLabName(), useEmission2nd.Value ? 1.0f : 0.0f);
            }

            var Emission2ndTexUVMode = lilToon?.Emission2ndTexUVMode;
            if (Emission2ndTexUVMode.HasValue)
            {
                yield return (lilToonPropertyType.Emission2ndTexUVMode.ToUnityShaderLabName(), (float)Emission2ndTexUVMode.Value);
            }

            var emission2ndMainStrength = lilToon?.Emission2ndMainStrength;
            if (emission2ndMainStrength.HasValue)
            {
                yield return (lilToonPropertyType.Emission2ndMainStrength.ToUnityShaderLabName(), emission2ndMainStrength.Value);
            }

            var emission2ndBlend = lilToon?.Emission2ndBlend;
            if (emission2ndBlend.HasValue)
            {
                yield return (lilToonPropertyType.Emission2ndBlend.ToUnityShaderLabName(), emission2ndBlend.Value);
            }

            var emission2ndBlendMode = lilToon?.Emission2ndBlendMode;
            if (emission2ndBlendMode.HasValue)
            {
                yield return (lilToonPropertyType.Emission2ndBlendMode.ToUnityShaderLabName(), (float)emission2ndBlendMode.Value);
            }

            var emission2ndFluorescence = lilToon?.Emission2ndFluorescence;
            if (emission2ndFluorescence.HasValue)
            {
                yield return (lilToonPropertyType.Emission2ndFluorescence.ToUnityShaderLabName(), emission2ndFluorescence.Value);
            }

            // Normal Map
            var useNormalMap = lilToon?.UseNormalMap;
            if (useNormalMap.HasValue)
            {
                yield return (lilToonPropertyType.UseNormalMap.ToUnityShaderLabName(), useNormalMap.Value ? 1.0f : 0.0f);
            }

            var normalTexScale = lilToon?.NormalTexScale;
            if (normalTexScale.HasValue)
            {
                yield return (lilToonPropertyType.NormalTexScale.ToUnityShaderLabName(), normalTexScale.Value);
            }

            var useNormal2ndMap = lilToon?.UseNormal2ndMap;
            if (useNormal2ndMap.HasValue)
            {
                yield return (lilToonPropertyType.UseNormal2ndMap.ToUnityShaderLabName(), useNormal2ndMap.Value ? 1.0f : 0.0f);
            }

            var Normal2ndTexUVMode = lilToon?.Normal2ndTexUVMode;
            if (Normal2ndTexUVMode.HasValue)
            {
                yield return (lilToonPropertyType.Normal2ndTexUVMode.ToUnityShaderLabName(), (float)Normal2ndTexUVMode.Value);
            }

            var normal2ndTexScale = lilToon?.Normal2ndTexScale;
            if (normal2ndTexScale.HasValue)
            {
                yield return (lilToonPropertyType.Normal2ndTexScale.ToUnityShaderLabName(), normal2ndTexScale.Value);
            }

            // MatCap
            var useMatCap = lilToon?.UseMatCap;
            if (useMatCap.HasValue)
            {
                yield return (lilToonPropertyType.UseMatCap.ToUnityShaderLabName(), useMatCap.Value ? 1.0f : 0.0f);
            }

            var matcapZRotCancel = lilToon?.MatCapZRotCancel;
            if (matcapZRotCancel.HasValue)
            {
                yield return (lilToonPropertyType.MatCapZRotCancel.ToUnityShaderLabName(), matcapZRotCancel.Value ? 1.0f : 0.0f);
            }

            var matcapPerspective = lilToon?.MatCapPerspective;
            if (matcapPerspective.HasValue)
            {
                yield return (lilToonPropertyType.MatCapPerspective.ToUnityShaderLabName(), matcapPerspective.Value ? 1.0f : 0.0f);
            }

            var matcapVRParallaxStrength = lilToon?.MatCapVRParallaxStrength;
            if (matcapVRParallaxStrength.HasValue)
            {
                yield return (lilToonPropertyType.MatCapVRParallaxStrength.ToUnityShaderLabName(), matcapVRParallaxStrength.Value);
            }

            var matcapBlend = lilToon?.MatCapBlend;
            if (matcapBlend.HasValue)
            {
                yield return (lilToonPropertyType.MatCapBlend.ToUnityShaderLabName(), matcapBlend.Value);
            }

            var matCapEnableLighting = lilToon?.MatCapEnableLighting;
            if (matCapEnableLighting.HasValue)
            {
                yield return (lilToonPropertyType.MatCapEnableLighting.ToUnityShaderLabName(), matCapEnableLighting.Value);
            }

            var matCapBlendMode = lilToon?.MatCapBlendMode;
            if (matCapBlendMode.HasValue)
            {
                yield return (lilToonPropertyType.MatCapBlendMode.ToUnityShaderLabName(), (float)matCapBlendMode.Value);
            }

            var useMatCap2nd = lilToon?.UseMatCap2nd;
            if (useMatCap2nd.HasValue)
            {
                yield return (lilToonPropertyType.UseMatCap2nd.ToUnityShaderLabName(), useMatCap2nd.Value ? 1.0f : 0.0f);
            }

            var matcap2ndZRotCancel = lilToon?.MatCap2ndZRotCancel;
            if (matcap2ndZRotCancel.HasValue)
            {
                yield return (lilToonPropertyType.MatCap2ndZRotCancel.ToUnityShaderLabName(), matcap2ndZRotCancel.Value ? 1.0f : 0.0f);
            }

            var matcap2ndPerspective = lilToon?.MatCap2ndPerspective;
            if (matcap2ndPerspective.HasValue)
            {
                yield return (lilToonPropertyType.MatCap2ndPerspective.ToUnityShaderLabName(), matcap2ndPerspective.Value ? 1.0f : 0.0f);
            }

            var matcap2ndVRParallaxStrength = lilToon?.MatCap2ndVRParallaxStrength;
            if (matcap2ndVRParallaxStrength.HasValue)
            {
                yield return (lilToonPropertyType.MatCap2ndVRParallaxStrength.ToUnityShaderLabName(), matcap2ndVRParallaxStrength.Value);
            }

            var matcap2ndBlend = lilToon?.MatCap2ndBlend;
            if (matcap2ndBlend.HasValue)
            {
                yield return (lilToonPropertyType.MatCap2ndBlend.ToUnityShaderLabName(), matcap2ndBlend.Value);
            }

            var matCap2ndEnableLighting = lilToon?.MatCap2ndEnableLighting;
            if (matCap2ndEnableLighting.HasValue)
            {
                yield return (lilToonPropertyType.MatCap2ndEnableLighting.ToUnityShaderLabName(), matCap2ndEnableLighting.Value);
            }

            var matCap2ndBlendMode = lilToon?.MatCap2ndBlendMode;
            if (matCap2ndBlendMode.HasValue)
            {
                yield return (lilToonPropertyType.MatCap2ndBlendMode.ToUnityShaderLabName(), (float)matCap2ndBlendMode.Value);
            }

            // Rim Light
            var useRim = lilToon?.UseRim;
            if (useRim.HasValue)
            {
                yield return (lilToonPropertyType.UseRim.ToUnityShaderLabName(), useRim.Value ? 1.0f : 0.0f);
            }

            var rimBorder = lilToon?.RimBorder;
            if (rimBorder.HasValue)
            {
                yield return (lilToonPropertyType.RimBorder.ToUnityShaderLabName(), rimBorder.Value);
            }

            var rimBlur = lilToon?.RimBlur;
            if (rimBlur.HasValue)
            {
                yield return (lilToonPropertyType.RimBlur.ToUnityShaderLabName(), rimBlur.Value);
            }

            var rimFresnelPower = lilToon?.RimFresnelPower;
            if (rimFresnelPower.HasValue)
            {
                yield return (lilToonPropertyType.RimFresnelPower.ToUnityShaderLabName(), rimFresnelPower.Value);
            }

            var rimDirStrength = lilToon?.RimDirStrength;
            if (rimDirStrength.HasValue)
            {
                yield return (lilToonPropertyType.RimDirStrength.ToUnityShaderLabName(), rimDirStrength.Value);
            }

            var rimDirRange = lilToon?.RimDirRange;
            if (rimDirRange.HasValue)
            {
                yield return (lilToonPropertyType.RimDirRange.ToUnityShaderLabName(), rimDirRange.Value);
            }

            var rimIndirRange = lilToon?.RimIndirRange;
            if (rimIndirRange.HasValue)
            {
                yield return (lilToonPropertyType.RimIndirRange.ToUnityShaderLabName(), rimIndirRange.Value);
            }

            var rimIndirBorder = lilToon?.RimIndirBorder;
            if (rimIndirBorder.HasValue)
            {
                yield return (lilToonPropertyType.RimIndirBorder.ToUnityShaderLabName(), rimIndirBorder.Value);
            }

            var rimIndirBlur = lilToon?.RimIndirBlur;
            if (rimIndirBlur.HasValue)
            {
                yield return (lilToonPropertyType.RimIndirBlur.ToUnityShaderLabName(), rimIndirBlur.Value);
            }

            var rimBlendMode = lilToon?.RimBlendMode;
            if (rimBlendMode.HasValue)
            {
                yield return (lilToonPropertyType.RimBlendMode.ToUnityShaderLabName(), (float)rimBlendMode.Value);
            }

            // Outline
            var outlineWidth = lilToon?.OutlineWidth;
            if (outlineWidth.HasValue)
            {
                yield return (lilToonPropertyType.OutlineWidth.ToUnityShaderLabName(), outlineWidth.Value);
            }
        }

        public static IEnumerable<(string key, Vector4 value)> TryGetAllFloatArrays(EXT_materials_liltoon_simple lilToon)
        {
            // Main Color
            var mainTexHSVG = lilToon?.MainTexHSVG;
            if (mainTexHSVG != null)
            {
                yield return (lilToonPropertyType.MainTexHSVG.ToUnityShaderLabName(), mainTexHSVG.ToVector4());
            }

            // Emission
            var emissionTexScrollRotate = lilToon?.EmissionTexScrollRotate;
            if (emissionTexScrollRotate != null)
            {
                yield return (lilToonPropertyType.EmissionTexScrollRotate.ToUnityShaderLabName(), emissionTexScrollRotate.ToVector4());
            }

            var emissionBlendMaskScrollRotate = lilToon?.EmissionBlendMaskScrollRotate;
            if (emissionBlendMaskScrollRotate != null)
            {
                yield return (lilToonPropertyType.EmissionBlendMaskScrollRotate.ToUnityShaderLabName(), emissionBlendMaskScrollRotate.ToVector4());
            }

            var emission2ndTexScrollRotate = lilToon?.Emission2ndTexScrollRotate;
            if (emission2ndTexScrollRotate != null)
            {
                yield return (lilToonPropertyType.Emission2ndTexScrollRotate.ToUnityShaderLabName(), emission2ndTexScrollRotate.ToVector4());
            }

            var emission2ndBlendMaskScrollRotate = lilToon?.Emission2ndBlendMaskScrollRotate;
            if (emission2ndBlendMaskScrollRotate != null)
            {
                yield return (lilToonPropertyType.Emission2ndBlendMaskScrollRotate.ToUnityShaderLabName(), emission2ndBlendMaskScrollRotate.ToVector4());
            }

            // MatCap
            var matCapBlendUV1 = lilToon?.MatCapBlendUV1;
            if (matCapBlendUV1 != null)
            {
                yield return (lilToonPropertyType.MatCapBlendUV1.ToUnityShaderLabName(), matCapBlendUV1.ToVector4());
            }

            var matCap2ndBlendUV1 = lilToon?.MatCap2ndBlendUV1;
            if (matCapBlendUV1 != null)
            {
                yield return (lilToonPropertyType.MatCap2ndBlendUV1.ToUnityShaderLabName(), matCap2ndBlendUV1.ToVector4());
            }

            // Outline
            var outlineTexScrollRotate = lilToon?.OutlineTexScrollRotate;
            if (outlineTexScrollRotate != null)
            {
                yield return (lilToonPropertyType.OutlineTexScrollRotate.ToUnityShaderLabName(), outlineTexScrollRotate.ToVector4());
            }
        }

        public static Vector4 ToVector4(this float[] floatArray)
        {
            if (floatArray.Length != 4)
            {
                throw new ArgumentOutOfRangeException();
            }
            return new Vector4(floatArray[0], floatArray[1], floatArray[2], floatArray[3]);
        }
    }
}
