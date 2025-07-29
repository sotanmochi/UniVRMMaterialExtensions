using UnityEngine;

namespace UniVRM10.Extensions.Materials.lilToon
{
    public sealed class lilToonContext
    {
        readonly Material _material;

        public lilToonContext(Material material)
        {
            _material = material;
        }

        public void Validate()
        {
            new lilToonValidator(_material).Validate();
        }

        public bool UseOutline => _material.shader == lilToonShaders.OpaqueOutlineShader ||
                                  _material.shader == lilToonShaders.CutoutOutlineShader ||
                                  _material.shader == lilToonShaders.TransparentOutlineShader;

        public lilToonRenderingMode RenderingMode { get; set; }

        public int RenderQueue
        {
            get => _material.renderQueue;
            set => _material.renderQueue = value;
        }

        // Base Settings
        public float Cutoff
        {
            get => _material.GetFloat(lilToonPropertyType.Cutoff.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.Cutoff.ToUnityShaderLabName(), value);
        }

        public lilToonCullMode Cull
        {
            get => (lilToonCullMode) _material.GetInt(lilToonPropertyType.Cull.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.Cull.ToUnityShaderLabName(), (int) value);
        }

        public bool Invisible
        {
            get => _material.GetInt(lilToonPropertyType.Invisible.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.Invisible.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public bool ZWrite
        {
            get => _material.GetInt(lilToonPropertyType.ZWrite.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.ZWrite.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public float AntiAliasStrength
        {
            get => _material.GetFloat(lilToonPropertyType.AntiAliasStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.AntiAliasStrength.ToUnityShaderLabName(), value);
        }

        public bool UseDither
        {
            get => _material.GetInt(lilToonPropertyType.UseDither.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.UseDither.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public Texture DitherTex
        {
            get => _material.GetTexture(lilToonPropertyType.DitherTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.DitherTex.ToUnityShaderLabName(), value);
        }

        public float DitherMaxValue
        {
            get => _material.GetFloat(lilToonPropertyType.DitherMaxValue.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.DitherMaxValue.ToUnityShaderLabName(), value);
        }

        // Lighting Base Settings
        public float LightMinLimit
        {
            get => _material.GetFloat(lilToonPropertyType.LightMinLimit.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.LightMinLimit.ToUnityShaderLabName(), value);
        }

        public float LightMaxLimit
        {
            get => _material.GetFloat(lilToonPropertyType.LightMaxLimit.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.LightMaxLimit.ToUnityShaderLabName(), value);
        }

        public float MonochromeLighting
        {
            get => _material.GetFloat(lilToonPropertyType.MonochromeLighting.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.MonochromeLighting.ToUnityShaderLabName(), value);
        }

        public float ShadowEnvStrength
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowEnvStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowEnvStrength.ToUnityShaderLabName(), value);
        }

        // Main Color
        public Color MainColorSrgb
        {
            get => _material.GetColor(lilToonPropertyType.MainColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.MainColor.ToUnityShaderLabName(), value);
        }

        public Texture MainTex
        {
            get => _material.GetTexture(lilToonPropertyType.MainTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.MainTex.ToUnityShaderLabName(), value);
        }

        public Vector4 MainTexHSVG
        {
            get => _material.GetVector(lilToonPropertyType.MainTexHSVG.ToUnityShaderLabName());
            set => _material.SetVector(lilToonPropertyType.MainTexHSVG.ToUnityShaderLabName(), value);
        }

        public float MainGradationStrength
        {
            get => _material.GetFloat(lilToonPropertyType.MainGradationStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.MainGradationStrength.ToUnityShaderLabName(), value);
        }

        public Texture MainGradationTex
        {
            get => _material.GetTexture(lilToonPropertyType.MainGradationTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.MainGradationTex.ToUnityShaderLabName(), value);
        }

        public Texture MainColorAdjustMask
        {
            get => _material.GetTexture(lilToonPropertyType.MainColorAdjustMask.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.MainColorAdjustMask.ToUnityShaderLabName(), value);
        }

        // Alpha Mask
        public lilToonAlphaMaskMode AlphaMaskMode
        {
            get => (lilToonAlphaMaskMode) _material.GetInt(lilToonPropertyType.AlphaMaskMode.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.AlphaMaskMode.ToUnityShaderLabName(), (int) value);
        }

        public Texture AlphaMask
        {
            get => _material.GetTexture(lilToonPropertyType.AlphaMask.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.AlphaMask.ToUnityShaderLabName(), value);
        }

        public float AlphaMaskScale
        {
            get => _material.GetFloat(lilToonPropertyType.AlphaMaskScale.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.AlphaMaskScale.ToUnityShaderLabName(), value);
        }

        public float AlphaMaskValue
        {
            get => _material.GetFloat(lilToonPropertyType.AlphaMaskValue.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.AlphaMaskValue.ToUnityShaderLabName(), value);
        }

        // Shadow
        public bool UseShadow
        {
            get => _material.GetInt(lilToonPropertyType.UseShadow.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.UseShadow.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public lilToonShadowMaskType ShadowMaskType
        {
            get => (lilToonShadowMaskType) _material.GetInt(lilToonPropertyType.ShadowMaskType.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.ShadowMaskType.ToUnityShaderLabName(), (int) value);
        }

        public float ShadowStrength
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowStrength.ToUnityShaderLabName(), value);
        }

        public Texture ShadowStrengthMask
        {
            get => _material.GetTexture(lilToonPropertyType.ShadowStrengthMask.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.ShadowStrengthMask.ToUnityShaderLabName(), value);
        }

        public float ShadowStrengthMaskLOD
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowStrengthMaskLOD.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowStrengthMaskLOD.ToUnityShaderLabName(), value);
        }

        public float ShadowFlatBorder
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowFlatBorder.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowFlatBorder.ToUnityShaderLabName(), value);
        }

        public float ShadowFlatBlur
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowFlatBlur.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowFlatBlur.ToUnityShaderLabName(), value);
        }

        public lilToonShadowColorType ShadowColorType
        {
            get => (lilToonShadowColorType) _material.GetInt(lilToonPropertyType.ShadowColorType.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.ShadowColorType.ToUnityShaderLabName(), (int) value);
        }

        public Color ShadowColorSrgb
        {
            get => _material.GetColor(lilToonPropertyType.ShadowColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.ShadowColor.ToUnityShaderLabName(), value);
        }

        public Texture ShadowColorTex
        {
            get => _material.GetTexture(lilToonPropertyType.ShadowColorTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.ShadowColorTex.ToUnityShaderLabName(), value);
        }

        public float ShadowBorder
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowBorder.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowBorder.ToUnityShaderLabName(), value);
        }

        public float ShadowBlur
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowBlur.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowBlur.ToUnityShaderLabName(), value);
        }

        public float ShadowReceive
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowReceive.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowReceive.ToUnityShaderLabName(), value);
        }

        public Color Shadow2ndColorSrgb
        {
            get => _material.GetColor(lilToonPropertyType.Shadow2ndColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.Shadow2ndColor.ToUnityShaderLabName(), value);
        }

        public Texture Shadow2ndColorTex
        {
            get => _material.GetTexture(lilToonPropertyType.Shadow2ndColorTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.Shadow2ndColorTex.ToUnityShaderLabName(), value);
        }

        public float Shadow2ndBorder
        {
            get => _material.GetFloat(lilToonPropertyType.Shadow2ndBorder.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.Shadow2ndBorder.ToUnityShaderLabName(), value);
        }

        public float Shadow2ndBlur
        {
            get => _material.GetFloat(lilToonPropertyType.Shadow2ndBlur.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.Shadow2ndBlur.ToUnityShaderLabName(), value);
        }

        public float Shadow2ndReceive
        {
            get => _material.GetFloat(lilToonPropertyType.Shadow2ndReceive.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.Shadow2ndReceive.ToUnityShaderLabName(), value);
        }

        public Color Shadow3rdColorSrgb
        {
            get => _material.GetColor(lilToonPropertyType.Shadow3rdColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.Shadow3rdColor.ToUnityShaderLabName(), value);
        }

        public Texture Shadow3rdColorTex
        {
            get => _material.GetTexture(lilToonPropertyType.Shadow3rdColorTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.Shadow3rdColorTex.ToUnityShaderLabName(), value);
        }

        public Color ShadowBorderColorSrgb
        {
            get => _material.GetColor(lilToonPropertyType.ShadowBorderColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.ShadowBorderColor.ToUnityShaderLabName(), value);
        }

        public float ShadowBorderRange
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowBorderRange.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowBorderRange.ToUnityShaderLabName(), value);
        }

        public float ShadowMainStrength
        {
            get => _material.GetFloat(lilToonPropertyType.ShadowMainStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.ShadowMainStrength.ToUnityShaderLabName(), value);
        }

        // Emission
        public bool UseEmission
        {
            get => _material.GetInt(lilToonPropertyType.UseEmission.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.UseEmission.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public Color EmissionColorLinear
        {
            // Emissive factor is stored in Linear space
            get => _material.GetColor(lilToonPropertyType.EmissionColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.EmissionColor.ToUnityShaderLabName(), value);
        }

        public Texture EmissionTex
        {
            get => _material.GetTexture(lilToonPropertyType.EmissionTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.EmissionTex.ToUnityShaderLabName(), value);
        }

        public Vector4 EmissionTexScrollRotate
        {
            get => _material.GetVector(lilToonPropertyType.EmissionTexScrollRotate.ToUnityShaderLabName());
            set => _material.SetVector(lilToonPropertyType.EmissionTexScrollRotate.ToUnityShaderLabName(), value);
        }

        public lilToonEmissionTexUVMode EmissionTexUVMode
        {
            get => (lilToonEmissionTexUVMode) _material.GetInt(lilToonPropertyType.EmissionTexUVMode.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.EmissionTexUVMode.ToUnityShaderLabName(), (int) value);
        }

        public float EmissionMainStrength
        {
            get => _material.GetFloat(lilToonPropertyType.EmissionMainStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.EmissionMainStrength.ToUnityShaderLabName(), value);
        }

        public float EmissionBlend
        {
            get => _material.GetFloat(lilToonPropertyType.EmissionBlend.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.EmissionBlend.ToUnityShaderLabName(), value);
        }

        public Texture EmissionBlendMask
        {
            get => _material.GetTexture(lilToonPropertyType.EmissionBlendMask.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.EmissionBlendMask.ToUnityShaderLabName(), value);
        }

        public Vector4 EmissionBlendMaskScrollRotate
        {
            get => _material.GetVector(lilToonPropertyType.EmissionBlendMaskScrollRotate.ToUnityShaderLabName());
            set => _material.SetVector(lilToonPropertyType.EmissionBlendMaskScrollRotate.ToUnityShaderLabName(), value);
        }

        public lilToonEmissionBlendMode EmissionBlendMode
        {
            get => (lilToonEmissionBlendMode) _material.GetInt(lilToonPropertyType.EmissionBlendMode.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.EmissionBlendMode.ToUnityShaderLabName(), (int) value);
        }

        public float EmissionFluorescence
        {
            get => _material.GetFloat(lilToonPropertyType.EmissionFluorescence.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.EmissionFluorescence.ToUnityShaderLabName(), value);
        }

        public bool UseEmission2nd
        {
            get => _material.GetInt(lilToonPropertyType.UseEmission2nd.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.UseEmission2nd.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public Color Emission2ndColorLinear
        {
            // Emissive factor is stored in Linear space
            get => _material.GetColor(lilToonPropertyType.Emission2ndColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.Emission2ndColor.ToUnityShaderLabName(), value);
        }

        public Texture Emission2ndTex
        {
            get => _material.GetTexture(lilToonPropertyType.Emission2ndTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.Emission2ndTex.ToUnityShaderLabName(), value);
        }

        public Vector4 Emission2ndTexScrollRotate
        {
            get => _material.GetVector(lilToonPropertyType.Emission2ndTexScrollRotate.ToUnityShaderLabName());
            set => _material.SetVector(lilToonPropertyType.Emission2ndTexScrollRotate.ToUnityShaderLabName(), value);
        }

        public lilToonEmissionTexUVMode Emission2ndTexUVMode
        {
            get => (lilToonEmissionTexUVMode) _material.GetInt(lilToonPropertyType.Emission2ndTexUVMode.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.Emission2ndTexUVMode.ToUnityShaderLabName(), (int) value);
        }

        public float Emission2ndMainStrength
        {
            get => _material.GetFloat(lilToonPropertyType.Emission2ndMainStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.Emission2ndMainStrength.ToUnityShaderLabName(), value);
        }

        public float Emission2ndBlend
        {
            get => _material.GetFloat(lilToonPropertyType.Emission2ndBlend.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.Emission2ndBlend.ToUnityShaderLabName(), value);
        }

        public Texture Emission2ndBlendMask
        {
            get => _material.GetTexture(lilToonPropertyType.Emission2ndBlendMask.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.Emission2ndBlendMask.ToUnityShaderLabName(), value);
        }

        public Vector4 Emission2ndBlendMaskScrollRotate
        {
            get => _material.GetVector(lilToonPropertyType.Emission2ndBlendMaskScrollRotate.ToUnityShaderLabName());
            set => _material.SetVector(lilToonPropertyType.Emission2ndBlendMaskScrollRotate.ToUnityShaderLabName(), value);
        }

        public lilToonEmissionBlendMode Emission2ndBlendMode
        {
            get => (lilToonEmissionBlendMode) _material.GetInt(lilToonPropertyType.Emission2ndBlendMode.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.Emission2ndBlendMode.ToUnityShaderLabName(), (int) value);
        }

        public float Emission2ndFluorescence
        {
            get => _material.GetFloat(lilToonPropertyType.Emission2ndFluorescence.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.Emission2ndFluorescence.ToUnityShaderLabName(), value);
        }

        // Normal Map
        public bool UseNormalMap
        {
            get => _material.GetInt(lilToonPropertyType.UseNormalMap.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.UseNormalMap.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public Texture NormalTex
        {
            get => _material.GetTexture(lilToonPropertyType.NormalTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.NormalTex.ToUnityShaderLabName(), value);
        }

        public float NormalTexScale
        {
            get => _material.GetFloat(lilToonPropertyType.NormalTexScale.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.NormalTexScale.ToUnityShaderLabName(), value);
        }

        public bool UseNormal2ndMap
        {
            get => _material.GetInt(lilToonPropertyType.UseNormal2ndMap.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.UseNormal2ndMap.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public Texture Normal2ndTex
        {
            get => _material.GetTexture(lilToonPropertyType.Normal2ndTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.Normal2ndTex.ToUnityShaderLabName(), value);
        }

        public lilToonNormalTexUVMode Normal2ndTexUVMode
        {
            get => (lilToonNormalTexUVMode) _material.GetInt(lilToonPropertyType.Normal2ndTexUVMode.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.Normal2ndTexUVMode.ToUnityShaderLabName(), (int) value);
        }

        public float Normal2ndTexScale
        {
            get => _material.GetFloat(lilToonPropertyType.Normal2ndTexScale.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.Normal2ndTexScale.ToUnityShaderLabName(), value);
        }

        public Texture Normal2ndTexScaleMask
        {
            get => _material.GetTexture(lilToonPropertyType.Normal2ndTexScaleMask.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.Normal2ndTexScaleMask.ToUnityShaderLabName(), value);
        }

        // MatCap
        public bool UseMatCap
        {
            get => _material.GetInt(lilToonPropertyType.UseMatCap.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.UseMatCap.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public Color MatCapColor
        {
            get => _material.GetColor(lilToonPropertyType.MatCapColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.MatCapColor.ToUnityShaderLabName(), value);
        }

        public Texture MatCapTex
        {
            get => _material.GetTexture(lilToonPropertyType.MatCapTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.MatCapTex.ToUnityShaderLabName(), value);
        }

        public Vector4 MatCapBlendUV1
        {
            get => _material.GetVector(lilToonPropertyType.MatCapBlendUV1.ToUnityShaderLabName());
            set => _material.SetVector(lilToonPropertyType.MatCapBlendUV1.ToUnityShaderLabName(), value);
        }

        public bool MatCapZRotCancel
        {
            get => _material.GetInt(lilToonPropertyType.MatCapZRotCancel.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.MatCapZRotCancel.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public bool MatCapPerspective
        {
            get => _material.GetInt(lilToonPropertyType.MatCapPerspective.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.MatCapPerspective.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public float MatCapVRParallaxStrength
        {
            get => _material.GetFloat(lilToonPropertyType.MatCapVRParallaxStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.MatCapVRParallaxStrength.ToUnityShaderLabName(), value);
        }

        public float MatCapBlend
        {
            get => _material.GetFloat(lilToonPropertyType.MatCapBlend.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.MatCapBlend.ToUnityShaderLabName(), value);
        }

        public Texture MatCapBlendMask
        {
            get => _material.GetTexture(lilToonPropertyType.MatCapBlendMask.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.MatCapBlendMask.ToUnityShaderLabName(), value);
        }

        public float MatCapEnableLighting
        {
            get => _material.GetFloat(lilToonPropertyType.MatCapEnableLighting.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.MatCapEnableLighting.ToUnityShaderLabName(), value);
        }

        public lilToonMatCapBlendMode MatCapBlendMode
        {
            get => (lilToonMatCapBlendMode) _material.GetInt(lilToonPropertyType.MatCapBlendMode.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.MatCapBlendMode.ToUnityShaderLabName(), (int) value);
        }

        public bool UseMatCap2nd
        {
            get => _material.GetInt(lilToonPropertyType.UseMatCap2nd.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.UseMatCap2nd.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public Color MatCap2ndColor
        {
            get => _material.GetColor(lilToonPropertyType.MatCap2ndColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.MatCap2ndColor.ToUnityShaderLabName(), value);
        }

        public Texture MatCap2ndTex
        {
            get => _material.GetTexture(lilToonPropertyType.MatCap2ndTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.MatCap2ndTex.ToUnityShaderLabName(), value);
        }

        public Vector4 MatCap2ndBlendUV1
        {
            get => _material.GetVector(lilToonPropertyType.MatCap2ndBlendUV1.ToUnityShaderLabName());
            set => _material.SetVector(lilToonPropertyType.MatCap2ndBlendUV1.ToUnityShaderLabName(), value);
        }

        public bool MatCap2ndZRotCancel
        {
            get => _material.GetInt(lilToonPropertyType.MatCap2ndZRotCancel.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.MatCap2ndZRotCancel.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public bool MatCap2ndPerspective
        {
            get => _material.GetInt(lilToonPropertyType.MatCap2ndPerspective.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.MatCap2ndPerspective.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public float MatCap2ndVRParallaxStrength
        {
            get => _material.GetFloat(lilToonPropertyType.MatCap2ndVRParallaxStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.MatCap2ndVRParallaxStrength.ToUnityShaderLabName(), value);
        }

        public float MatCap2ndBlend
        {
            get => _material.GetFloat(lilToonPropertyType.MatCap2ndBlend.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.MatCap2ndBlend.ToUnityShaderLabName(), value);
        }

        public Texture MatCap2ndBlendMask
        {
            get => _material.GetTexture(lilToonPropertyType.MatCap2ndBlendMask.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.MatCap2ndBlendMask.ToUnityShaderLabName(), value);
        }

        public float MatCap2ndEnableLighting
        {
            get => _material.GetFloat(lilToonPropertyType.MatCap2ndEnableLighting.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.MatCap2ndEnableLighting.ToUnityShaderLabName(), value);
        }

        public lilToonMatCapBlendMode MatCap2ndBlendMode
        {
            get => (lilToonMatCapBlendMode) _material.GetInt(lilToonPropertyType.MatCap2ndBlendMode.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.MatCap2ndBlendMode.ToUnityShaderLabName(), (int) value);
        }

        // Rim Light
        public bool UseRim
        {
            get => _material.GetInt(lilToonPropertyType.UseRim.ToUnityShaderLabName()) != 0;
            set => _material.SetInt(lilToonPropertyType.UseRim.ToUnityShaderLabName(), value ? 1 : 0);
        }

        public Color RimColor
        {
            get => _material.GetColor(lilToonPropertyType.RimColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.RimColor.ToUnityShaderLabName(), value);
        }

        public Texture RimColorTex
        {
            get => _material.GetTexture(lilToonPropertyType.RimColorTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.RimColorTex.ToUnityShaderLabName(), value);
        }

        public float RimBorder
        {
            get => _material.GetFloat(lilToonPropertyType.RimBorder.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.RimBorder.ToUnityShaderLabName(), value);
        }

        public float RimBlur
        {
            get => _material.GetFloat(lilToonPropertyType.RimBlur.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.RimBlur.ToUnityShaderLabName(), value);
        }

        public float RimFresnelPower
        {
            get => _material.GetFloat(lilToonPropertyType.RimFresnelPower.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.RimFresnelPower.ToUnityShaderLabName(), value);
        }
        
        public float RimEnableLighting
        {
            get => _material.GetFloat(lilToonPropertyType.RimEnableLighting.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.RimEnableLighting.ToUnityShaderLabName(), value);
        }

        public float RimDirStrength
        {
            get => _material.GetFloat(lilToonPropertyType.RimDirStrength.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.RimDirStrength.ToUnityShaderLabName(), value);
        }

        public float RimDirRange
        {
            get => _material.GetFloat(lilToonPropertyType.RimDirRange.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.RimDirRange.ToUnityShaderLabName(), value);
        }

        public float RimIndirRange
        {
            get => _material.GetFloat(lilToonPropertyType.RimIndirRange.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.RimIndirRange.ToUnityShaderLabName(), value);
        }

        public Color RimIndirColor
        {
            get => _material.GetColor(lilToonPropertyType.RimIndirColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.RimIndirColor.ToUnityShaderLabName(), value);
        }

        public float RimIndirBorder
        {
            get => _material.GetFloat(lilToonPropertyType.RimIndirBorder.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.RimIndirBorder.ToUnityShaderLabName(), value);
        }

        public float RimIndirBlur
        {
            get => _material.GetFloat(lilToonPropertyType.RimIndirBlur.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.RimIndirBlur.ToUnityShaderLabName(), value);
        }

        public lilToonRimBlendMode RimBlendMode
        {
            get => (lilToonRimBlendMode) _material.GetInt(lilToonPropertyType.RimBlendMode.ToUnityShaderLabName());
            set => _material.SetInt(lilToonPropertyType.RimBlendMode.ToUnityShaderLabName(), (int) value);
        }

        // Outline
        public Color OutlineColor
        {
            get => _material.GetColor(lilToonPropertyType.OutlineColor.ToUnityShaderLabName());
            set => _material.SetColor(lilToonPropertyType.OutlineColor.ToUnityShaderLabName(), value);
        }

        public Texture OutlineTex
        {
            get => _material.GetTexture(lilToonPropertyType.OutlineTex.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.OutlineTex.ToUnityShaderLabName(), value);
        }

        public Vector4 OutlineTexScrollRotate
        {
            get => _material.GetVector(lilToonPropertyType.OutlineTexScrollRotate.ToUnityShaderLabName());
            set => _material.SetVector(lilToonPropertyType.OutlineTexScrollRotate.ToUnityShaderLabName(), value);
        }

        public float OutlineWidth
        {
            get => _material.GetFloat(lilToonPropertyType.OutlineWidth.ToUnityShaderLabName());
            set => _material.SetFloat(lilToonPropertyType.OutlineWidth.ToUnityShaderLabName(), value);
        }

        public Texture OutlineWidthMask
        {
            get => _material.GetTexture(lilToonPropertyType.OutlineWidthMask.ToUnityShaderLabName());
            set => _material.SetTexture(lilToonPropertyType.OutlineWidthMask.ToUnityShaderLabName(), value);
        }
    }
}
