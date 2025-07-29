// This file is generated from JsonSchema. Don't modify this source code.
using UniJSON;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniGLTF.Extensions.EXT_materials_liltoon_simple {

public static class GltfDeserializer
{
    public static readonly Utf8String ExtensionNameUtf8 = Utf8String.From(EXT_materials_liltoon_simple.ExtensionName);

public static bool TryGet(UniGLTF.glTFExtension src, out EXT_materials_liltoon_simple extension)
{
    if(src is UniGLTF.glTFExtensionImport extensions)
    {
        foreach(var kv in extensions.ObjectItems())
        {
            if(kv.Key.GetUtf8String() == ExtensionNameUtf8)
            {
                extension = Deserialize(kv.Value);
                return true;
            }
        }
    }

    extension = default;
    return false;
}


public static EXT_materials_liltoon_simple Deserialize(JsonNode parsed)
{
    var value = new EXT_materials_liltoon_simple();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="specVersion"){
            value.SpecVersion = kv.Value.GetString();
            continue;
        }

        if(key=="renderingMode"){
            value.RenderingMode = (RenderingMode)Enum.Parse(typeof(RenderingMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="transparentMode"){
            value.TransparentMode = (TransparentMode)Enum.Parse(typeof(TransparentMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="renderQueue"){
            value.RenderQueue = kv.Value.GetInt32();
            continue;
        }

        if(key=="cutoff"){
            value.Cutoff = kv.Value.GetSingle();
            continue;
        }

        if(key=="cull"){
            value.Cull = (Cull)Enum.Parse(typeof(Cull), kv.Value.GetString(), true);
            continue;
        }

        if(key=="invisible"){
            value.Invisible = kv.Value.GetBoolean();
            continue;
        }

        if(key=="zWrite"){
            value.ZWrite = kv.Value.GetBoolean();
            continue;
        }

        if(key=="antiAliasStrength"){
            value.AntiAliasStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="useDither"){
            value.UseDither = kv.Value.GetBoolean();
            continue;
        }

        if(key=="ditherTex"){
            value.DitherTex = Deserialize_DitherTex(kv.Value);
            continue;
        }

        if(key=="ditherMaxValue"){
            value.DitherMaxValue = kv.Value.GetSingle();
            continue;
        }

        if(key=="lightMinLimit"){
            value.LightMinLimit = kv.Value.GetSingle();
            continue;
        }

        if(key=="lightMaxLimit"){
            value.LightMaxLimit = kv.Value.GetSingle();
            continue;
        }

        if(key=="monochromeLighting"){
            value.MonochromeLighting = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadowEnvStrength"){
            value.ShadowEnvStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="mainColor"){
            value.MainColor = Deserialize_MainColor(kv.Value);
            continue;
        }

        if(key=="mainTex"){
            value.MainTex = Deserialize_MainTex(kv.Value);
            continue;
        }

        if(key=="mainTexHSVG"){
            value.MainTexHSVG = Deserialize_MainTexHSVG(kv.Value);
            continue;
        }

        if(key=="mainGradationStrength"){
            value.MainGradationStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="mainGradationTex"){
            value.MainGradationTex = Deserialize_MainGradationTex(kv.Value);
            continue;
        }

        if(key=="mainColorAdjustMask"){
            value.MainColorAdjustMask = Deserialize_MainColorAdjustMask(kv.Value);
            continue;
        }

        if(key=="alphaMaskMode"){
            value.AlphaMaskMode = (AlphaMaskMode)Enum.Parse(typeof(AlphaMaskMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="alphaMask"){
            value.AlphaMask = Deserialize_AlphaMask(kv.Value);
            continue;
        }

        if(key=="alphaMaskScale"){
            value.AlphaMaskScale = kv.Value.GetSingle();
            continue;
        }

        if(key=="alphaMaskValue"){
            value.AlphaMaskValue = kv.Value.GetSingle();
            continue;
        }

        if(key=="useShadow"){
            value.UseShadow = kv.Value.GetBoolean();
            continue;
        }

        if(key=="shadowMaskType"){
            value.ShadowMaskType = (ShadowMaskType)Enum.Parse(typeof(ShadowMaskType), kv.Value.GetString(), true);
            continue;
        }

        if(key=="shadowStrength"){
            value.ShadowStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadowStrengthMask"){
            value.ShadowStrengthMask = Deserialize_ShadowStrengthMask(kv.Value);
            continue;
        }

        if(key=="shadowStrengthMaskLOD"){
            value.ShadowStrengthMaskLOD = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadowFlatBorder"){
            value.ShadowFlatBorder = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadowFlatBlur"){
            value.ShadowFlatBlur = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadowColorType"){
            value.ShadowColorType = (ShadowColorType)Enum.Parse(typeof(ShadowColorType), kv.Value.GetString(), true);
            continue;
        }

        if(key=="shadowColor"){
            value.ShadowColor = Deserialize_ShadowColor(kv.Value);
            continue;
        }

        if(key=="shadowColorTex"){
            value.ShadowColorTex = Deserialize_ShadowColorTex(kv.Value);
            continue;
        }

        if(key=="shadowBorder"){
            value.ShadowBorder = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadowBlur"){
            value.ShadowBlur = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadowReceive"){
            value.ShadowReceive = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadow2ndColor"){
            value.Shadow2ndColor = Deserialize_Shadow2ndColor(kv.Value);
            continue;
        }

        if(key=="shadow2ndColorTex"){
            value.Shadow2ndColorTex = Deserialize_Shadow2ndColorTex(kv.Value);
            continue;
        }

        if(key=="shadow2ndBorder"){
            value.Shadow2ndBorder = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadow2ndBlur"){
            value.Shadow2ndBlur = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadow2ndReceive"){
            value.Shadow2ndReceive = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadow3rdColor"){
            value.Shadow3rdColor = Deserialize_Shadow3rdColor(kv.Value);
            continue;
        }

        if(key=="shadow3rdColorTex"){
            value.Shadow3rdColorTex = Deserialize_Shadow3rdColorTex(kv.Value);
            continue;
        }

        if(key=="shadowBorderColor"){
            value.ShadowBorderColor = Deserialize_ShadowBorderColor(kv.Value);
            continue;
        }

        if(key=="shadowBorderRange"){
            value.ShadowBorderRange = kv.Value.GetSingle();
            continue;
        }

        if(key=="shadowMainStrength"){
            value.ShadowMainStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="useEmission"){
            value.UseEmission = kv.Value.GetBoolean();
            continue;
        }

        if(key=="emissionColor"){
            value.EmissionColor = Deserialize_EmissionColor(kv.Value);
            continue;
        }

        if(key=="emissionTex"){
            value.EmissionTex = Deserialize_EmissionTex(kv.Value);
            continue;
        }

        if(key=="emissionTexScrollRotate"){
            value.EmissionTexScrollRotate = Deserialize_EmissionTexScrollRotate(kv.Value);
            continue;
        }

        if(key=="emissionTexUVMode"){
            value.EmissionTexUVMode = (EmissionTexUVMode)Enum.Parse(typeof(EmissionTexUVMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="emissionMainStrength"){
            value.EmissionMainStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="emissionBlend"){
            value.EmissionBlend = kv.Value.GetSingle();
            continue;
        }

        if(key=="emissionBlendMask"){
            value.EmissionBlendMask = Deserialize_EmissionBlendMask(kv.Value);
            continue;
        }

        if(key=="emissionBlendMaskScrollRotate"){
            value.EmissionBlendMaskScrollRotate = Deserialize_EmissionBlendMaskScrollRotate(kv.Value);
            continue;
        }

        if(key=="emissionBlendMode"){
            value.EmissionBlendMode = (EmissionBlendMode)Enum.Parse(typeof(EmissionBlendMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="emissionFluorescence"){
            value.EmissionFluorescence = kv.Value.GetSingle();
            continue;
        }

        if(key=="useEmission2nd"){
            value.UseEmission2nd = kv.Value.GetBoolean();
            continue;
        }

        if(key=="emission2ndColor"){
            value.Emission2ndColor = Deserialize_Emission2ndColor(kv.Value);
            continue;
        }

        if(key=="emission2ndTex"){
            value.Emission2ndTex = Deserialize_Emission2ndTex(kv.Value);
            continue;
        }

        if(key=="emission2ndTexScrollRotate"){
            value.Emission2ndTexScrollRotate = Deserialize_Emission2ndTexScrollRotate(kv.Value);
            continue;
        }

        if(key=="emission2ndTexUVMode"){
            value.Emission2ndTexUVMode = (EmissionTexUVMode)Enum.Parse(typeof(EmissionTexUVMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="emission2ndMainStrength"){
            value.Emission2ndMainStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="emission2ndBlend"){
            value.Emission2ndBlend = kv.Value.GetSingle();
            continue;
        }

        if(key=="emission2ndBlendMask"){
            value.Emission2ndBlendMask = Deserialize_Emission2ndBlendMask(kv.Value);
            continue;
        }

        if(key=="emission2ndBlendMaskScrollRotate"){
            value.Emission2ndBlendMaskScrollRotate = Deserialize_Emission2ndBlendMaskScrollRotate(kv.Value);
            continue;
        }

        if(key=="emission2ndBlendMode"){
            value.Emission2ndBlendMode = (EmissionBlendMode)Enum.Parse(typeof(EmissionBlendMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="emission2ndFluorescence"){
            value.Emission2ndFluorescence = kv.Value.GetSingle();
            continue;
        }

        if(key=="useNormalMap"){
            value.UseNormalMap = kv.Value.GetBoolean();
            continue;
        }

        if(key=="normalTex"){
            value.NormalTex = Deserialize_NormalTex(kv.Value);
            continue;
        }

        if(key=="normalTexScale"){
            value.NormalTexScale = kv.Value.GetSingle();
            continue;
        }

        if(key=="useNormal2ndMap"){
            value.UseNormal2ndMap = kv.Value.GetBoolean();
            continue;
        }

        if(key=="normal2ndTex"){
            value.Normal2ndTex = Deserialize_Normal2ndTex(kv.Value);
            continue;
        }

        if(key=="normal2ndTexUVMode"){
            value.Normal2ndTexUVMode = (NormalTexUVMode)Enum.Parse(typeof(NormalTexUVMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="normal2ndTexScale"){
            value.Normal2ndTexScale = kv.Value.GetSingle();
            continue;
        }

        if(key=="normal2ndTexScaleMask"){
            value.Normal2ndTexScaleMask = Deserialize_Normal2ndTexScaleMask(kv.Value);
            continue;
        }

        if(key=="useMatCap"){
            value.UseMatCap = kv.Value.GetBoolean();
            continue;
        }

        if(key=="matCapColor"){
            value.MatCapColor = Deserialize_MatCapColor(kv.Value);
            continue;
        }

        if(key=="matCapTex"){
            value.MatCapTex = Deserialize_MatCapTex(kv.Value);
            continue;
        }

        if(key=="matCapBlendUV1"){
            value.MatCapBlendUV1 = Deserialize_MatCapBlendUV1(kv.Value);
            continue;
        }

        if(key=="matCapZRotCancel"){
            value.MatCapZRotCancel = kv.Value.GetBoolean();
            continue;
        }

        if(key=="matCapPerspective"){
            value.MatCapPerspective = kv.Value.GetBoolean();
            continue;
        }

        if(key=="matCapVRParallaxStrength"){
            value.MatCapVRParallaxStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="matCapBlend"){
            value.MatCapBlend = kv.Value.GetSingle();
            continue;
        }

        if(key=="matCapBlendMask"){
            value.MatCapBlendMask = Deserialize_MatCapBlendMask(kv.Value);
            continue;
        }

        if(key=="matCapEnableLighting"){
            value.MatCapEnableLighting = kv.Value.GetSingle();
            continue;
        }

        if(key=="matCapBlendMode"){
            value.MatCapBlendMode = (MatCapBlendMode)Enum.Parse(typeof(MatCapBlendMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="useMatCap2nd"){
            value.UseMatCap2nd = kv.Value.GetBoolean();
            continue;
        }

        if(key=="matCap2ndColor"){
            value.MatCap2ndColor = Deserialize_MatCap2ndColor(kv.Value);
            continue;
        }

        if(key=="matCap2ndTex"){
            value.MatCap2ndTex = Deserialize_MatCap2ndTex(kv.Value);
            continue;
        }

        if(key=="matCap2ndBlendUV1"){
            value.MatCap2ndBlendUV1 = Deserialize_MatCap2ndBlendUV1(kv.Value);
            continue;
        }

        if(key=="matCap2ndZRotCancel"){
            value.MatCap2ndZRotCancel = kv.Value.GetBoolean();
            continue;
        }

        if(key=="matCap2ndPerspective"){
            value.MatCap2ndPerspective = kv.Value.GetBoolean();
            continue;
        }

        if(key=="matCap2ndVRParallaxStrength"){
            value.MatCap2ndVRParallaxStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="matCap2ndBlend"){
            value.MatCap2ndBlend = kv.Value.GetSingle();
            continue;
        }

        if(key=="matCap2ndBlendMask"){
            value.MatCap2ndBlendMask = Deserialize_MatCap2ndBlendMask(kv.Value);
            continue;
        }

        if(key=="matCap2ndEnableLighting"){
            value.MatCap2ndEnableLighting = kv.Value.GetSingle();
            continue;
        }

        if(key=="matCap2ndBlendMode"){
            value.MatCap2ndBlendMode = (MatCapBlendMode)Enum.Parse(typeof(MatCapBlendMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="useRim"){
            value.UseRim = kv.Value.GetBoolean();
            continue;
        }

        if(key=="rimColor"){
            value.RimColor = Deserialize_RimColor(kv.Value);
            continue;
        }

        if(key=="rimColorTex"){
            value.RimColorTex = Deserialize_RimColorTex(kv.Value);
            continue;
        }

        if(key=="rimBorder"){
            value.RimBorder = kv.Value.GetSingle();
            continue;
        }

        if(key=="rimBlur"){
            value.RimBlur = kv.Value.GetSingle();
            continue;
        }

        if(key=="rimFresnelPower"){
            value.RimFresnelPower = kv.Value.GetSingle();
            continue;
        }

        if(key=="rimDirStrength"){
            value.RimDirStrength = kv.Value.GetSingle();
            continue;
        }

        if(key=="rimDirRange"){
            value.RimDirRange = kv.Value.GetSingle();
            continue;
        }

        if(key=="rimIndirRange"){
            value.RimIndirRange = kv.Value.GetSingle();
            continue;
        }

        if(key=="rimIndirColor"){
            value.RimIndirColor = Deserialize_RimIndirColor(kv.Value);
            continue;
        }

        if(key=="rimIndirBorder"){
            value.RimIndirBorder = kv.Value.GetSingle();
            continue;
        }

        if(key=="rimIndirBlur"){
            value.RimIndirBlur = kv.Value.GetSingle();
            continue;
        }

        if(key=="rimBlendMode"){
            value.RimBlendMode = (RimBlendMode)Enum.Parse(typeof(RimBlendMode), kv.Value.GetString(), true);
            continue;
        }

        if(key=="useOutline"){
            value.UseOutline = kv.Value.GetBoolean();
            continue;
        }

        if(key=="outlineColor"){
            value.OutlineColor = Deserialize_OutlineColor(kv.Value);
            continue;
        }

        if(key=="outlineTex"){
            value.OutlineTex = Deserialize_OutlineTex(kv.Value);
            continue;
        }

        if(key=="outlineTexScrollRotate"){
            value.OutlineTexScrollRotate = Deserialize_OutlineTexScrollRotate(kv.Value);
            continue;
        }

        if(key=="outlineWidth"){
            value.OutlineWidth = kv.Value.GetSingle();
            continue;
        }

        if(key=="outlineWidthMask"){
            value.OutlineWidthMask = Deserialize_OutlineWidthMask(kv.Value);
            continue;
        }

    }
    return value;
}

public static TextureInfo Deserialize_DitherTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_MainColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_MainTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_MainTexHSVG(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_MainGradationTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static TextureInfo Deserialize_MainColorAdjustMask(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static TextureInfo Deserialize_AlphaMask(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static TextureInfo Deserialize_ShadowStrengthMask(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_ShadowColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_ShadowColorTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_Shadow2ndColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_Shadow2ndColorTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_Shadow3rdColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_Shadow3rdColorTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_ShadowBorderColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static float[] Deserialize_EmissionColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_EmissionTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_EmissionTexScrollRotate(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_EmissionBlendMask(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_EmissionBlendMaskScrollRotate(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static float[] Deserialize_Emission2ndColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_Emission2ndTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_Emission2ndTexScrollRotate(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_Emission2ndBlendMask(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_Emission2ndBlendMaskScrollRotate(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_NormalTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static TextureInfo Deserialize_Normal2ndTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static TextureInfo Deserialize_Normal2ndTexScaleMask(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_MatCapColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_MatCapTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_MatCapBlendUV1(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_MatCapBlendMask(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_MatCap2ndColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_MatCap2ndTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_MatCap2ndBlendUV1(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_MatCap2ndBlendMask(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_RimColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_RimColorTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_RimIndirColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static float[] Deserialize_OutlineColor(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_OutlineTex(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

public static float[] Deserialize_OutlineTexScrollRotate(JsonNode parsed)
{
    var value = new float[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static TextureInfo Deserialize_OutlineWidthMask(JsonNode parsed)
{
    var value = new TextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var key = kv.Key.GetString();

        if(key=="extensions"){
            value.Extensions = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="extras"){
            value.Extras = new glTFExtensionImport(kv.Value);
            continue;
        }

        if(key=="index"){
            value.Index = kv.Value.GetInt32();
            continue;
        }

        if(key=="texCoord"){
            value.TexCoord = kv.Value.GetInt32();
            continue;
        }

    }
    return value;
}

} // GltfDeserializer
} // UniGLTF 
