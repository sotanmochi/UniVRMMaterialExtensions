using System;
using UniGLTF;
using UniGLTF.Extensions.EXT_materials_liltoon_simple;
using UniGLTF.Extensions.VRMC_materials_mtoon;
using UnityEngine;
using UnityEngine.Rendering;
using VRM10.MToon10;
using ColorSpace = UniGLTF.ColorSpace;
using lilToonTextureInfo = UniGLTF.Extensions.EXT_materials_liltoon_simple.TextureInfo;
using MToonTextureInfo = UniGLTF.Extensions.VRMC_materials_mtoon.TextureInfo;

namespace UniVRM10.Extensions.Materials.lilToon
{
    public enum lilToonAlphaMode
    {
        Opaque,
        Cutout,
        Transparent,
    }

    public class lilToonSimpleMaterialExporter
    {
        public bool TryExportMaterial(Material src, ITextureExporter textureExporter, out glTFMaterial dst)
        {
            if (src.shader == null)
            {
                Debug.Log($"<color=cyan>[lilToonSimpleMaterialExporter] The shader is not found.</color>");
                dst = null;
                return false;
            }

            if (src.shader != lilToonShaders.OpaqueShader &&
                src.shader != lilToonShaders.CutoutShader &&
                src.shader != lilToonShaders.TransparentShader &&
                src.shader != lilToonShaders.OpaqueOutlineShader &&
                src.shader != lilToonShaders.CutoutOutlineShader &&
                src.shader != lilToonShaders.TransparentOutlineShader)
            {
                Debug.Log($"<color=cyan>[lilToonSimpleMaterialExporter] The shader '{src.shader.name}' is not supported.</color>");
                dst = null;
                return false;
            }

            var renderingMode = lilToonRenderingMode.Opaque;
            if (src.shader == lilToonShaders.OpaqueShader)
            {
                renderingMode = lilToonRenderingMode.Opaque;
            }
            else if (src.shader == lilToonShaders.CutoutShader)
            {
                renderingMode = lilToonRenderingMode.Cutout;
            }
            else if (src.shader == lilToonShaders.TransparentShader)
            {
                renderingMode = lilToonRenderingMode.Transparent;
            }
            else if (src.shader == lilToonShaders.OpaqueOutlineShader)
            {
                renderingMode = lilToonRenderingMode.Opaque;
            }
            else if (src.shader == lilToonShaders.CutoutOutlineShader)
            {
                renderingMode = lilToonRenderingMode.Cutout;
            }
            else if (src.shader == lilToonShaders.TransparentOutlineShader)
            {
                renderingMode = lilToonRenderingMode.Transparent;
            }

            var context = new lilToonContext(src);
            context.RenderingMode = renderingMode;
            context.Validate();

            // base material
            dst = glTF_KHR_materials_unlit.CreateDefault();
            dst.name = src.name;

            // MToon material
            var mToon = new UniGLTF.Extensions.VRMC_materials_mtoon.VRMC_materials_mtoon();
            mToon.SpecVersion = Vrm10Exporter.MTOON_SPEC_VERSION;

            // lilToon material
            var lilToon = new UniGLTF.Extensions.EXT_materials_liltoon_simple.EXT_materials_liltoon_simple();
            // lilToon.SpecVersion = Exporter.LILTOON_SPEC_VERSION;

            // Rendering Mode
            dst.alphaMode = ExportAlphaMode(context.RenderingMode);
            lilToon.RenderingMode = ExportRenderingMode(context.RenderingMode);

            // Base Settings
            dst.alphaCutoff = Mathf.Max(0, context.Cutoff);
            lilToon.Cutoff = Mathf.Max(0, context.Cutoff);

            dst.doubleSided = context.Cull == lilToonCullMode.Off;
            lilToon.Cull = ExportCullMode(context.Cull);

            mToon.TransparentWithZWrite = context.ZWrite;
            lilToon.ZWrite = context.ZWrite;

            mToon.RenderQueueOffsetNumber = ExportMToonRenderQueueOffset(context.RenderQueue, context.RenderingMode, context.ZWrite);
            lilToon.RenderQueue = context.RenderQueue;

            lilToon.Invisible = context.Invisible;
            lilToon.AntiAliasStrength = context.AntiAliasStrength;
            lilToon.UseDither = context.UseDither;
            lilToon.DitherMaxValue = context.DitherMaxValue;
            var ditherTextureIndex = textureExporter.RegisterExportingAsLinear(context.DitherTex, needsAlpha: false);
            if (ditherTextureIndex != -1)
            {
                lilToon.DitherTex = new lilToonTextureInfo
                {
                    Index = ditherTextureIndex,
                };
            }

            // Lighting Base Settings
            lilToon.LightMinLimit = context.LightMinLimit;
            lilToon.LightMaxLimit = context.LightMaxLimit;
            lilToon.MonochromeLighting = context.MonochromeLighting;
            lilToon.ShadowEnvStrength = context.ShadowEnvStrength;

            ExportMainColor(context, textureExporter, dst, mToon, lilToon);
            ExportAlphaMask(context, textureExporter, dst, mToon, lilToon);
            ExportShadow(context, textureExporter, dst, mToon, lilToon);
            ExportEmission(context, textureExporter, dst, mToon, lilToon);
            ExportNormalMap(context, textureExporter, dst, mToon, lilToon);
            ExportMatCap(context, textureExporter, dst, mToon, lilToon);
            ExportRimLight(context, textureExporter, dst, mToon, lilToon);
            ExportOutline(context, textureExporter, dst, mToon, lilToon);

            UniGLTF.Extensions.VRMC_materials_mtoon.GltfSerializer.SerializeTo(ref dst.extensions, mToon);
            UniGLTF.Extensions.EXT_materials_liltoon_simple.GltfSerializer.SerializeTo(ref dst.extensions, lilToon);

            return true;
        }

        private static void ExportMainColor(lilToonContext context, ITextureExporter textureExporter, glTFMaterial gltf, VRMC_materials_mtoon mToon, EXT_materials_liltoon_simple lilToon)
        {
            gltf.pbrMetallicRoughness = new glTFPbrMetallicRoughness();

            var mainColor = context.MainColorSrgb.ToFloat4(ColorSpace.sRGB, ColorSpace.Linear);
            gltf.pbrMetallicRoughness.baseColorFactor = mainColor;
            lilToon.MainColor = mainColor;

            var baseColorTextureIndex = textureExporter.RegisterExportingAsSRgb(context.MainTex, context.RenderingMode != lilToonRenderingMode.Opaque);
            if (baseColorTextureIndex != -1)
            {
                gltf.pbrMetallicRoughness.baseColorTexture = new glTFMaterialBaseColorTextureInfo
                {
                    index = baseColorTextureIndex,
                };

                lilToon.MainTex = new lilToonTextureInfo
                {
                    Index = baseColorTextureIndex,
                };
            }

            lilToon.MainTexHSVG = new float[]
            {
                context.MainTexHSVG.x, context.MainTexHSVG.y, context.MainTexHSVG.z, context.MainTexHSVG.w,
            };
            lilToon.MainGradationStrength = context.MainGradationStrength;
            lilToon.MainGradationTex = new lilToonTextureInfo
            {
                Index = textureExporter.RegisterExportingAsSRgb(context.MainGradationTex, needsAlpha: false),
            };
            lilToon.MainColorAdjustMask = new lilToonTextureInfo
            {
                Index = textureExporter.RegisterExportingAsSRgb(context.MainColorAdjustMask, needsAlpha: false),
            };
        }

        private static void ExportAlphaMask(lilToonContext context, ITextureExporter textureExporter, glTFMaterial gltf, VRMC_materials_mtoon mToon, EXT_materials_liltoon_simple lilToon)
        {
            lilToon.AlphaMaskMode = ExportAlphaMaskMode(context.AlphaMaskMode);
            lilToon.AlphaMaskScale = context.AlphaMaskScale;
            lilToon.AlphaMaskValue = context.AlphaMaskValue;
            lilToon.AlphaMask = new lilToonTextureInfo
            {
                Index = textureExporter.RegisterExportingAsSRgb(context.AlphaMask, needsAlpha: false),
            };
        }

        private static void ExportShadow(lilToonContext context, ITextureExporter textureExporter, glTFMaterial gltf, VRMC_materials_mtoon mToon, EXT_materials_liltoon_simple lilToon)
        {
            lilToon.UseShadow = context.UseShadow;

            var shadowColor = context.ShadowColorSrgb.ToFloat4(ColorSpace.sRGB, ColorSpace.Linear);
            mToon.ShadeColorFactor = shadowColor;
            lilToon.ShadowColor = shadowColor;

            var shadowColorTextureIndex = textureExporter.RegisterExportingAsSRgb(context.ShadowColorTex, needsAlpha: false);
            if (shadowColorTextureIndex != -1)
            {
                mToon.ShadeMultiplyTexture = new MToonTextureInfo
                {
                    Index = shadowColorTextureIndex,
                };
                lilToon.ShadowColorTex = new lilToonTextureInfo
                {
                    Index = shadowColorTextureIndex,
                };
            }
            else
            {
                var baseColorTextureIndex = textureExporter.RegisterExportingAsSRgb(context.MainTex, context.RenderingMode != lilToonRenderingMode.Opaque);
                if (baseColorTextureIndex != -1)
                {
                    mToon.ShadeMultiplyTexture = new MToonTextureInfo
                    {
                        Index = baseColorTextureIndex,
                    };
                }
            }

            var shadingShift = (Mathf.Clamp01(context.ShadowBorder - (context.ShadowBlur * 0.5f)) * 2.0f) - 1.0f;
            var shadingToony = (2.0f - (Mathf.Clamp01(context.ShadowBorder + (context.ShadowBlur * 0.5f)) * 2.0f)) / (1.0f - shadingShift);
            mToon.ShadingShiftFactor = shadingShift;
            mToon.ShadingToonyFactor = shadingToony;

            lilToon.ShadowBorder = context.ShadowBorder;
            lilToon.ShadowBlur = context.ShadowBlur;
            lilToon.ShadowReceive = context.ShadowReceive;

            lilToon.Shadow2ndColor = context.Shadow2ndColorSrgb.ToFloat4(ColorSpace.sRGB, ColorSpace.Linear);
            var shadow2ndColorTextureIndex = textureExporter.RegisterExportingAsSRgb(context.Shadow2ndColorTex, needsAlpha: false);
            if (shadow2ndColorTextureIndex != -1)
            {
                lilToon.Shadow2ndColorTex = new lilToonTextureInfo
                {
                    Index = shadow2ndColorTextureIndex,
                };
            }
            lilToon.Shadow2ndBorder = context.Shadow2ndBorder;
            lilToon.Shadow2ndBlur = context.Shadow2ndBlur;
            lilToon.Shadow2ndReceive = context.Shadow2ndReceive;

            lilToon.Shadow3rdColor = context.Shadow3rdColorSrgb.ToFloat4(ColorSpace.sRGB, ColorSpace.Linear);
            var shadow3rdColorTextureIndex = textureExporter.RegisterExportingAsSRgb(context.Shadow3rdColorTex, needsAlpha: false);
            if (shadow3rdColorTextureIndex != -1)
            {
                lilToon.Shadow3rdColorTex = new lilToonTextureInfo
                {
                    Index = shadow3rdColorTextureIndex,
                };
            }

            lilToon.ShadowBorderColor = context.ShadowBorderColorSrgb.ToFloat3(ColorSpace.sRGB, ColorSpace.Linear);
            lilToon.ShadowBorderRange = context.ShadowBorderRange;
            lilToon.ShadowMainStrength = context.ShadowMainStrength;

            lilToon.ShadowMaskType = ExportShadowMaskType(context.ShadowMaskType);
            lilToon.ShadowStrength = context.ShadowStrength;
            lilToon.ShadowStrengthMask = new lilToonTextureInfo
            {
                Index = textureExporter.RegisterExportingAsSRgb(context.ShadowStrengthMask, needsAlpha: false),
            };
            lilToon.ShadowStrengthMaskLOD = context.ShadowStrengthMaskLOD;
            lilToon.ShadowFlatBorder = context.ShadowFlatBorder;
            lilToon.ShadowFlatBlur = context.ShadowFlatBlur;
            lilToon.ShadowColorType = ExportShadowColorType(context.ShadowColorType);
        }

        private static void ExportEmission(lilToonContext context, ITextureExporter textureExporter, glTFMaterial gltf, VRMC_materials_mtoon mToon, EXT_materials_liltoon_simple lilToon)
        {
            lilToon.UseEmission = context.UseEmission;

            var emissiveFactor = context.EmissionColorLinear;
            var maxColorComponent = emissiveFactor.maxColorComponent;
            if (maxColorComponent > 1.0f)
            {
                UniGLTF.glTF_KHR_materials_emissive_strength.Serialize(ref gltf.extensions, maxColorComponent);
                emissiveFactor /= maxColorComponent;
            }
            gltf.emissiveFactor = emissiveFactor.ToFloat3(ColorSpace.Linear, ColorSpace.Linear);
            lilToon.EmissionColor = emissiveFactor.ToFloat4(ColorSpace.Linear, ColorSpace.Linear);

            var emissionTextureIndex = textureExporter.RegisterExportingAsSRgb(context.EmissionTex, needsAlpha: false);
            if (emissionTextureIndex != -1)
            {
                gltf.emissiveTexture = new glTFMaterialEmissiveTextureInfo
                {
                    index = emissionTextureIndex,
                };
                lilToon.EmissionTex = new lilToonTextureInfo
                {
                    Index = emissionTextureIndex,
                };
            }
            lilToon.EmissionTexScrollRotate = new float[]
            {
                context.EmissionTexScrollRotate.x,
                context.EmissionTexScrollRotate.y,
                context.EmissionTexScrollRotate.z,
                context.EmissionTexScrollRotate.w
            };
            lilToon.EmissionTexUVMode = ExportEmissionTexUVMode(context.EmissionTexUVMode);
            lilToon.EmissionMainStrength = context.EmissionMainStrength;
            lilToon.EmissionBlend = context.EmissionBlend;
            lilToon.EmissionBlendMask = new lilToonTextureInfo
            {
                Index = textureExporter.RegisterExportingAsSRgb(context.EmissionBlendMask, needsAlpha: false),
            };
            lilToon.Emission2ndBlendMaskScrollRotate = new float[]
            {
                context.Emission2ndBlendMaskScrollRotate.x,
                context.Emission2ndBlendMaskScrollRotate.y,
                context.Emission2ndBlendMaskScrollRotate.z,
                context.Emission2ndBlendMaskScrollRotate.w
            };
            lilToon.EmissionBlendMode = ExportEmissionBlendMode(context.EmissionBlendMode);
            lilToon.EmissionFluorescence = context.EmissionFluorescence;

            // Emission 2nd
            lilToon.UseEmission2nd = context.UseEmission2nd;
            lilToon.Emission2ndColor = context.Emission2ndColorLinear.ToFloat4(ColorSpace.Linear, ColorSpace.Linear);
            var emission2ndTextureIndex = textureExporter.RegisterExportingAsSRgb(context.Emission2ndTex, needsAlpha: false);
            if (emission2ndTextureIndex != -1)
            {
                lilToon.Emission2ndTex = new lilToonTextureInfo
                {
                    Index = emission2ndTextureIndex,
                };
            }
            lilToon.Emission2ndTexScrollRotate = new float[]
            {
                context.Emission2ndTexScrollRotate.x,
                context.Emission2ndTexScrollRotate.y,
                context.Emission2ndTexScrollRotate.z,
                context.Emission2ndTexScrollRotate.w
            };
            lilToon.Emission2ndTexUVMode = ExportEmissionTexUVMode(context.Emission2ndTexUVMode);
            lilToon.Emission2ndMainStrength = context.Emission2ndMainStrength;
            lilToon.Emission2ndBlend = context.Emission2ndBlend;
            lilToon.Emission2ndBlendMask = new lilToonTextureInfo
            {
                Index = textureExporter.RegisterExportingAsSRgb(context.Emission2ndBlendMask, needsAlpha: false),
            };
            lilToon.Emission2ndBlendMaskScrollRotate = new float[]
            {
                context.Emission2ndBlendMaskScrollRotate.x,
                context.Emission2ndBlendMaskScrollRotate.y,
                context.Emission2ndBlendMaskScrollRotate.z,
                context.Emission2ndBlendMaskScrollRotate.w
            };
            lilToon.Emission2ndBlendMode = ExportEmissionBlendMode(context.Emission2ndBlendMode);
            lilToon.Emission2ndFluorescence = context.Emission2ndFluorescence;
        }

        private static void ExportNormalMap(lilToonContext context, ITextureExporter textureExporter, glTFMaterial gltf, VRMC_materials_mtoon mToon, EXT_materials_liltoon_simple lilToon)
        {
            lilToon.UseNormalMap = context.UseNormalMap;
            var normalTextureIndex = textureExporter.RegisterExportingAsNormal(context.NormalTex);
            if (normalTextureIndex != -1)
            {
                gltf.normalTexture = new glTFMaterialNormalTextureInfo
                {
                    index = normalTextureIndex,
                    scale = context.NormalTexScale,
                };
                lilToon.NormalTex = new lilToonTextureInfo
                {
                    Index = normalTextureIndex,
                    // Scale = context.NormalTexScale,
                };
            }

            lilToon.UseNormal2ndMap = context.UseNormal2ndMap;
            var normal2ndTextureIndex = textureExporter.RegisterExportingAsNormal(context.Normal2ndTex);
            if (normal2ndTextureIndex != -1)
            {
                lilToon.Normal2ndTex = new lilToonTextureInfo
                {
                    Index = normal2ndTextureIndex
                    // scale = context.Normal2ndTextureScale,
                };
            }
            lilToon.Normal2ndTexUVMode = ExportNormalTexUVMode(context.Normal2ndTexUVMode);
            var normal2ndTexScaleMaskIndex = textureExporter.RegisterExportingAsSRgb(context.Normal2ndTexScaleMask, needsAlpha: false);
            lilToon.Normal2ndTexScaleMask = new lilToonTextureInfo
            {
                Index = normal2ndTexScaleMaskIndex
            };
        }

        private static void ExportMatCap(lilToonContext context, ITextureExporter textureExporter, glTFMaterial gltf, VRMC_materials_mtoon mToon, EXT_materials_liltoon_simple lilToon)
        {
            lilToon.UseMatCap = context.UseMatCap;
            lilToon.MatCapColor = context.MatCapColor.ToFloat4(ColorSpace.sRGB, ColorSpace.Linear);
            mToon.MatcapFactor = context.MatCapColor.ToFloat3(ColorSpace.sRGB, ColorSpace.Linear);

            var matCapTextureIndex = textureExporter.RegisterExportingAsSRgb(context.MatCapTex, needsAlpha: false);
            if (matCapTextureIndex != -1)
            {
                lilToon.MatCapTex = new lilToonTextureInfo
                {
                    Index = matCapTextureIndex,
                };
                mToon.MatcapTexture = new MToonTextureInfo
                {
                    Index = matCapTextureIndex,
                };
            }

            lilToon.MatCapBlendUV1 = new float[]
            {
                context.MatCapBlendUV1.x,
                context.MatCapBlendUV1.y,
                context.MatCapBlendUV1.z,
                context.MatCapBlendUV1.w
            };
            lilToon.MatCapZRotCancel = context.MatCapZRotCancel;
            lilToon.MatCapPerspective = context.MatCapPerspective;
            lilToon.MatCapVRParallaxStrength = context.MatCapVRParallaxStrength;
            lilToon.MatCapBlend = context.MatCapBlend;
            lilToon.MatCapBlendMask = new lilToonTextureInfo
            {
                Index = textureExporter.RegisterExportingAsSRgb(context.MatCapBlendMask, needsAlpha: false),
            };
            lilToon.MatCapEnableLighting = context.MatCapEnableLighting;
            lilToon.MatCapBlendMode = ExportMatCapBlendMode(context.MatCapBlendMode);

            lilToon.UseMatCap2nd = context.UseMatCap2nd;
            lilToon.MatCap2ndColor = context.MatCap2ndColor.ToFloat4(ColorSpace.sRGB, ColorSpace.Linear);
            var matCap2ndTextureIndex = textureExporter.RegisterExportingAsSRgb(context.MatCap2ndTex, needsAlpha: false);
            if (matCap2ndTextureIndex != -1)
            {
                lilToon.MatCap2ndTex = new lilToonTextureInfo
                {
                    Index = matCap2ndTextureIndex,
                };
            }
            lilToon.MatCap2ndBlendUV1 = new float[]
            {
                context.MatCap2ndBlendUV1.x,
                context.MatCap2ndBlendUV1.y,
                context.MatCap2ndBlendUV1.z,
                context.MatCap2ndBlendUV1.w
            };
            lilToon.MatCap2ndZRotCancel = context.MatCap2ndZRotCancel;
            lilToon.MatCap2ndPerspective = context.MatCap2ndPerspective;
            lilToon.MatCap2ndVRParallaxStrength = context.MatCap2ndVRParallaxStrength;
            lilToon.MatCap2ndBlend = context.MatCap2ndBlend;
            lilToon.MatCap2ndBlendMask = new lilToonTextureInfo
            {
                Index = textureExporter.RegisterExportingAsSRgb(context.MatCap2ndBlendMask, needsAlpha: false),
            };
            lilToon.MatCap2ndEnableLighting = context.MatCap2ndEnableLighting;
            lilToon.MatCap2ndBlendMode = ExportMatCapBlendMode(context.MatCap2ndBlendMode);
        }

        private static void ExportRimLight(lilToonContext context, ITextureExporter textureExporter, glTFMaterial gltf, VRMC_materials_mtoon mToon, EXT_materials_liltoon_simple lilToon)
        {
            // lilToon properties
            lilToon.UseRim = context.UseRim;
            lilToon.RimColor = context.RimColor.ToFloat4(ColorSpace.sRGB, ColorSpace.Linear);
            var rimColorTextureIndex = textureExporter.RegisterExportingAsSRgb(context.RimColorTex, needsAlpha: false);
            if (rimColorTextureIndex != -1)
            {
                lilToon.RimColorTex = new lilToonTextureInfo
                {
                    Index = rimColorTextureIndex,
                };
            }
            lilToon.RimBorder = context.RimBorder;
            lilToon.RimBlur = context.RimBlur;
            lilToon.RimFresnelPower = context.RimFresnelPower;
            lilToon.RimDirStrength = context.RimDirStrength;
            lilToon.RimDirRange = context.RimDirRange;
            lilToon.RimIndirRange = context.RimIndirRange;
            lilToon.RimIndirColor = context.RimIndirColor.ToFloat4(ColorSpace.sRGB, ColorSpace.Linear);
            lilToon.RimIndirBorder = context.RimIndirBorder;
            lilToon.RimIndirBlur = context.RimIndirBlur;
            lilToon.RimBlendMode = ExportRimBlendMode(context.RimBlendMode);

            // MToon properties
            mToon.ParametricRimColorFactor = context.RimColor.ToFloat3(ColorSpace.sRGB, ColorSpace.Linear);
            var rimMultiplyTextureIndex = textureExporter.RegisterExportingAsSRgb(context.RimColorTex, needsAlpha: false);
            if (rimMultiplyTextureIndex != -1)
            {
                mToon.RimMultiplyTexture = new MToonTextureInfo
                {
                    Index = rimMultiplyTextureIndex,
                };
            }
            mToon.RimLightingMixFactor = context.RimEnableLighting;
        }

        private static void ExportOutline(lilToonContext context, ITextureExporter textureExporter, glTFMaterial gltf, VRMC_materials_mtoon mToon, EXT_materials_liltoon_simple lilToon)
        {
            // lilToon properties
            lilToon.UseOutline = context.UseOutline;

            var outlineColor = context.OutlineColor.ToFloat4(ColorSpace.sRGB, ColorSpace.Linear);
            lilToon.OutlineColor = outlineColor;
            mToon.OutlineColorFactor = outlineColor;

            var outlineColorTextureIndex = textureExporter.RegisterExportingAsSRgb(context.OutlineTex, needsAlpha: false);
            if (outlineColorTextureIndex != -1)
            {
                lilToon.OutlineTex = new lilToonTextureInfo
                {
                    Index = outlineColorTextureIndex,
                };
            }
            lilToon.OutlineTexScrollRotate = new float[]
            {
                context.OutlineTexScrollRotate.x,
                context.OutlineTexScrollRotate.y,
                context.OutlineTexScrollRotate.z,
                context.OutlineTexScrollRotate.w
            };
            lilToon.OutlineWidth = context.OutlineWidth;
            var outlineWidthTextureIndex = textureExporter.RegisterExportingAsSRgb(context.OutlineWidthMask, needsAlpha: false);
            if (outlineWidthTextureIndex != -1)
            {
                lilToon.OutlineWidthMask = new lilToonTextureInfo
                {
                    Index = outlineWidthTextureIndex,
                };
            }

            // MToon properties
            mToon.OutlineWidthMode = context.UseOutline ? OutlineWidthMode.worldCoordinates : OutlineWidthMode.none;
            mToon.OutlineWidthFactor = context.OutlineWidth / 100.0f;
            var outlineWidthMultiplyTextureIndex = textureExporter.RegisterExportingAsLinear(context.OutlineWidthMask, needsAlpha: false);
            if (outlineWidthMultiplyTextureIndex != -1)
            {
                mToon.OutlineWidthMultiplyTexture = new MToonTextureInfo
                {
                    Index = outlineWidthMultiplyTextureIndex,
                };
            }
            mToon.OutlineColorFactor = context.OutlineColor.ToFloat3(ColorSpace.sRGB, ColorSpace.Linear);
            mToon.OutlineLightingMixFactor = 1.0f;
        }

        private static RenderingMode ExportRenderingMode(lilToonRenderingMode renderingMode)
        {
            switch (renderingMode)
            {
                case lilToonRenderingMode.Opaque:
                    return RenderingMode.Opaque;
                case lilToonRenderingMode.Cutout:
                    return RenderingMode.Cutout;
                case lilToonRenderingMode.Transparent:
                    return RenderingMode.Transparent;
                default:
                    throw new ArgumentOutOfRangeException(nameof(renderingMode), renderingMode, null);
            }
        }

        private static string ExportAlphaMode(lilToonRenderingMode renderingMode)
        {
            switch (renderingMode)
            {
                case lilToonRenderingMode.Opaque:
                    return "OPAQUE";
                case lilToonRenderingMode.Cutout:
                    return "MASK";
                case lilToonRenderingMode.Transparent:
                    return "BLEND";
                default:
                    throw new ArgumentOutOfRangeException(nameof(renderingMode), renderingMode, null);
            }
        }

        private static Cull ExportCullMode(lilToonCullMode cullMode)
        {
            switch (cullMode)
            {
                case lilToonCullMode.Off:
                    return Cull.Off;
                case lilToonCullMode.Front:
                    return Cull.Front;
                case lilToonCullMode.Back:
                    return Cull.Back;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cullMode), cullMode, null);
            }
        }

        private static int ExportMToonRenderQueueOffset(int renderQueue, lilToonRenderingMode renderingMode, bool zwrite)
        {
            switch (renderingMode)
            {
                case lilToonRenderingMode.Opaque:
                    return renderQueue - (int)RenderQueue.Geometry;
                case lilToonRenderingMode.Cutout:
                    return renderQueue - (int)RenderQueue.AlphaTest;
                case lilToonRenderingMode.Transparent:
                    return zwrite ? renderQueue - (int)RenderQueue.GeometryLast + 1 
                                  : renderQueue - (int)RenderQueue.Transparent;
                default:
                    throw new ArgumentOutOfRangeException(nameof(renderingMode), renderingMode, null);
            }
        }

        private static AlphaMaskMode ExportAlphaMaskMode(lilToonAlphaMaskMode mode)
        {
            switch (mode)
            {
                case lilToonAlphaMaskMode.None:
                    return AlphaMaskMode.None;
                case lilToonAlphaMaskMode.Replace:
                    return AlphaMaskMode.Replace;
                case lilToonAlphaMaskMode.Multiply:
                    return AlphaMaskMode.Multiply;
                case lilToonAlphaMaskMode.Add:
                    return AlphaMaskMode.Add;
                case lilToonAlphaMaskMode.Subtract:
                    return AlphaMaskMode.Subtract;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        private static ShadowMaskType ExportShadowMaskType(lilToonShadowMaskType type)
        {
            switch (type)
            {
                case lilToonShadowMaskType.Strength:
                    return ShadowMaskType.Strength;
                case lilToonShadowMaskType.Flat:
                    return ShadowMaskType.Flat;
                case lilToonShadowMaskType.SDF:
                    return ShadowMaskType.SDF;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static ShadowColorType ExportShadowColorType(lilToonShadowColorType type)
        {
            switch (type)
            {
                case lilToonShadowColorType.Normal:
                    return ShadowColorType.Normal;
                case lilToonShadowColorType.LUT:
                    return ShadowColorType.LUT;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static EmissionTexUVMode ExportEmissionTexUVMode(lilToonEmissionTexUVMode mode)
        {
            switch (mode)
            {
                case lilToonEmissionTexUVMode.UV0:
                    return EmissionTexUVMode.UV0;
                case lilToonEmissionTexUVMode.UV1:
                    return EmissionTexUVMode.UV1;
                case lilToonEmissionTexUVMode.UV2:
                    return EmissionTexUVMode.UV2;
                case lilToonEmissionTexUVMode.UV3:
                    return EmissionTexUVMode.UV3;
                case lilToonEmissionTexUVMode.Rim:
                    return EmissionTexUVMode.Rim;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        private static EmissionBlendMode ExportEmissionBlendMode(lilToonEmissionBlendMode mode)
        {
            switch (mode)
            {
                case lilToonEmissionBlendMode.Normal:
                    return EmissionBlendMode.Normal;
                case lilToonEmissionBlendMode.Add:
                    return EmissionBlendMode.Add;
                case lilToonEmissionBlendMode.Screen:
                    return EmissionBlendMode.Screen;
                case lilToonEmissionBlendMode.Multiply:
                    return EmissionBlendMode.Multiply;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        private static NormalTexUVMode ExportNormalTexUVMode(lilToonNormalTexUVMode mode)
        {
            switch (mode)
            {
                case lilToonNormalTexUVMode.UV0:
                    return NormalTexUVMode.UV0;
                case lilToonNormalTexUVMode.UV1:
                    return NormalTexUVMode.UV1;
                case lilToonNormalTexUVMode.UV2:
                    return NormalTexUVMode.UV2;
                case lilToonNormalTexUVMode.UV3:
                    return NormalTexUVMode.UV3;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        private static MatCapBlendMode ExportMatCapBlendMode(lilToonMatCapBlendMode mode)
        {
            switch (mode)
            {
                case lilToonMatCapBlendMode.Normal:
                    return MatCapBlendMode.Normal;
                case lilToonMatCapBlendMode.Add:
                    return MatCapBlendMode.Add;
                case lilToonMatCapBlendMode.Screen:
                    return MatCapBlendMode.Screen;
                case lilToonMatCapBlendMode.Multiply:
                    return MatCapBlendMode.Multiply;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        private static RimBlendMode ExportRimBlendMode(lilToonRimBlendMode mode)
        {
            switch (mode)
            {
                case lilToonRimBlendMode.Normal:
                    return RimBlendMode.Normal;
                case lilToonRimBlendMode.Add:
                    return RimBlendMode.Add;
                case lilToonRimBlendMode.Screen:
                    return RimBlendMode.Screen;
                case lilToonRimBlendMode.Multiply:
                    return RimBlendMode.Multiply;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}