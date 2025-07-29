// This file is generated from JsonSchema. Don't modify this source code.
using System;
using System.Collections.Generic;


namespace UniGLTF.Extensions.EXT_materials_liltoon_simple
{

    public enum RenderingMode
    {
        Opaque,
        Cutout,
        Transparent,
        FakeShadow,

    }

    public enum TransparentMode
    {
        Normal,
        OnePass,
        TwoPass,

    }

    public enum Cull
    {
        Off,
        Front,
        Back,

    }

    public class TextureInfo
    {
        // Dictionary object with extension-specific objects.
        public object Extensions;

        // Application-specific data.
        public object Extras;

        // The index of the texture.
        public int? Index;

        // The set index of texture's TEXCOORD attribute used for texture coordinate mapping.
        public int? TexCoord;
    }

    public enum AlphaMaskMode
    {
        None,
        Replace,
        Multiply,
        Add,
        Subtract,

    }

    public enum ShadowMaskType
    {
        Strength,
        Flat,
        SDF,

    }

    public enum ShadowColorType
    {
        Normal,
        LUT,

    }

    public enum EmissionTexUVMode
    {
        UV0,
        UV1,
        UV2,
        UV3,
        Rim,

    }

    public enum EmissionBlendMode
    {
        Normal,
        Add,
        Screen,
        Multiply,

    }

    public enum NormalTexUVMode
    {
        UV0,
        UV1,
        UV2,
        UV3,

    }

    public enum MatCapBlendMode
    {
        Normal,
        Add,
        Screen,
        Multiply,

    }

    public enum RimBlendMode
    {
        Normal,
        Add,
        Screen,
        Multiply,

    }

    public class EXT_materials_liltoon_simple
    {
        public const string ExtensionName = "EXT_materials_liltoon_simple";

        // Dictionary object with extension-specific objects.
        public object Extensions;

        // Application-specific data.
        public object Extras;

        // Specification version of EXT_materials_liltoon_simple
        public string SpecVersion;

        public RenderingMode RenderingMode;

        public TransparentMode TransparentMode;

        public int? RenderQueue;

        // Base Setting
        public float? Cutoff;

        public Cull Cull;

        public bool? Invisible;

        public bool? ZWrite;

        public float? AntiAliasStrength;

        public bool? UseDither;

        public TextureInfo DitherTex;

        public float? DitherMaxValue;

        // Lighting Base Setting
        public float? LightMinLimit;

        public float? LightMaxLimit;

        public float? MonochromeLighting;

        public float? ShadowEnvStrength;

        // Main Color
        public float[] MainColor;

        public TextureInfo MainTex;

        public float[] MainTexHSVG;

        public float? MainGradationStrength;

        public TextureInfo MainGradationTex;

        public TextureInfo MainColorAdjustMask;

        // Alpha Mask
        public AlphaMaskMode AlphaMaskMode;

        public TextureInfo AlphaMask;

        public float? AlphaMaskScale;

        public float? AlphaMaskValue;

        // Shadow
        public bool? UseShadow;

        public ShadowMaskType ShadowMaskType;

        public float? ShadowStrength;

        public TextureInfo ShadowStrengthMask;

        public float? ShadowStrengthMaskLOD;

        public float? ShadowFlatBorder;

        public float? ShadowFlatBlur;

        public ShadowColorType ShadowColorType;

        public float[] ShadowColor;

        public TextureInfo ShadowColorTex;

        public float? ShadowBorder;

        public float? ShadowBlur;

        public float? ShadowReceive;

        public float[] Shadow2ndColor;

        public TextureInfo Shadow2ndColorTex;

        public float? Shadow2ndBorder;

        public float? Shadow2ndBlur;

        public float? Shadow2ndReceive;

        public float[] Shadow3rdColor;

        public TextureInfo Shadow3rdColorTex;

        public float[] ShadowBorderColor;

        public float? ShadowBorderRange;

        public float? ShadowMainStrength;

        // Emission
        public bool? UseEmission;

        public float[] EmissionColor;

        public TextureInfo EmissionTex;

        public float[] EmissionTexScrollRotate;

        public EmissionTexUVMode EmissionTexUVMode;

        public float? EmissionMainStrength;

        public float? EmissionBlend;

        public TextureInfo EmissionBlendMask;

        public float[] EmissionBlendMaskScrollRotate;

        public EmissionBlendMode EmissionBlendMode;

        public float? EmissionFluorescence;

        public bool? UseEmission2nd;

        public float[] Emission2ndColor;

        public TextureInfo Emission2ndTex;

        public float[] Emission2ndTexScrollRotate;

        public EmissionTexUVMode Emission2ndTexUVMode;

        public float? Emission2ndMainStrength;

        public float? Emission2ndBlend;

        public TextureInfo Emission2ndBlendMask;

        public float[] Emission2ndBlendMaskScrollRotate;

        public EmissionBlendMode Emission2ndBlendMode;

        public float? Emission2ndFluorescence;

        // NormalMap
        public bool? UseNormalMap;

        public TextureInfo NormalTex;

        public float? NormalTexScale;

        public bool? UseNormal2ndMap;

        public TextureInfo Normal2ndTex;

        public NormalTexUVMode Normal2ndTexUVMode;

        public float? Normal2ndTexScale;

        public TextureInfo Normal2ndTexScaleMask;

        // MatCap
        public bool? UseMatCap;

        public float[] MatCapColor;

        public TextureInfo MatCapTex;

        public float[] MatCapBlendUV1;

        public bool? MatCapZRotCancel;

        public bool? MatCapPerspective;

        public float? MatCapVRParallaxStrength;

        public float? MatCapBlend;

        public TextureInfo MatCapBlendMask;

        public float? MatCapEnableLighting;

        public MatCapBlendMode MatCapBlendMode;

        public bool? UseMatCap2nd;

        public float[] MatCap2ndColor;

        public TextureInfo MatCap2ndTex;

        public float[] MatCap2ndBlendUV1;

        public bool? MatCap2ndZRotCancel;

        public bool? MatCap2ndPerspective;

        public float? MatCap2ndVRParallaxStrength;

        public float? MatCap2ndBlend;

        public TextureInfo MatCap2ndBlendMask;

        public float? MatCap2ndEnableLighting;

        public MatCapBlendMode MatCap2ndBlendMode;

        // Rim Ligth
        public bool? UseRim;

        public float[] RimColor;

        public TextureInfo RimColorTex;

        public float? RimBorder;

        public float? RimBlur;

        public float? RimFresnelPower;

        public float? RimDirStrength;

        public float? RimDirRange;

        public float? RimIndirRange;

        public float[] RimIndirColor;

        public float? RimIndirBorder;

        public float? RimIndirBlur;

        public RimBlendMode RimBlendMode;

        // Outline
        public bool? UseOutline;

        public float[] OutlineColor;

        public TextureInfo OutlineTex;

        public float[] OutlineTexScrollRotate;

        public float? OutlineWidth;

        public TextureInfo OutlineWidthMask;
    }
}
