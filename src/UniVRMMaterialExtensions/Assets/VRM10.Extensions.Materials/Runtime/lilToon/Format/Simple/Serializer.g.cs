// This file is generated from JsonSchema. Don't modify this source code.
using System;
using System.Collections.Generic;
using System.Linq;
using UniJSON;

namespace UniGLTF.Extensions.EXT_materials_liltoon_simple {

    static public class GltfSerializer
    {

        public static void SerializeTo(ref UniGLTF.glTFExtension dst, EXT_materials_liltoon_simple extension)
        {
            if (dst is glTFExtensionImport)
            {
                throw new NotImplementedException();
            }

            if (!(dst is glTFExtensionExport extensions))
            {
                extensions = new glTFExtensionExport();
                dst = extensions;
            }

            var f = new JsonFormatter();
            Serialize(f, extension);
            extensions.Add(EXT_materials_liltoon_simple.ExtensionName, f.GetStoreBytes());
        }


public static void Serialize(JsonFormatter f, EXT_materials_liltoon_simple value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(!string.IsNullOrEmpty(value.SpecVersion)){
        f.Key("specVersion");                
        f.Value(value.SpecVersion);
    }

    if(true){
        f.Key("renderingMode");                
        f.Value(value.RenderingMode.ToString());
    }

    if(true){
        f.Key("transparentMode");                
        f.Value(value.TransparentMode.ToString());
    }

    if(value.RenderQueue.HasValue){
        f.Key("renderQueue");                
        f.Value(value.RenderQueue.GetValueOrDefault());
    }

    if(value.Cutoff.HasValue){
        f.Key("cutoff");                
        f.Value(value.Cutoff.GetValueOrDefault());
    }

    if(true){
        f.Key("cull");                
        f.Value(value.Cull.ToString());
    }

    if(value.Invisible.HasValue){
        f.Key("invisible");                
        f.Value(value.Invisible.GetValueOrDefault());
    }

    if(value.ZWrite.HasValue){
        f.Key("zWrite");                
        f.Value(value.ZWrite.GetValueOrDefault());
    }

    if(value.AntiAliasStrength.HasValue){
        f.Key("antiAliasStrength");                
        f.Value(value.AntiAliasStrength.GetValueOrDefault());
    }

    if(value.UseDither.HasValue){
        f.Key("useDither");                
        f.Value(value.UseDither.GetValueOrDefault());
    }

    if(value.DitherTex!=null){
        f.Key("ditherTex");                
        Serialize_DitherTex(f, value.DitherTex);
    }

    if(value.DitherMaxValue.HasValue){
        f.Key("ditherMaxValue");                
        f.Value(value.DitherMaxValue.GetValueOrDefault());
    }

    if(value.LightMinLimit.HasValue){
        f.Key("lightMinLimit");                
        f.Value(value.LightMinLimit.GetValueOrDefault());
    }

    if(value.LightMaxLimit.HasValue){
        f.Key("lightMaxLimit");                
        f.Value(value.LightMaxLimit.GetValueOrDefault());
    }

    if(value.MonochromeLighting.HasValue){
        f.Key("monochromeLighting");                
        f.Value(value.MonochromeLighting.GetValueOrDefault());
    }

    if(value.ShadowEnvStrength.HasValue){
        f.Key("shadowEnvStrength");                
        f.Value(value.ShadowEnvStrength.GetValueOrDefault());
    }

    if(value.MainColor!=null&&value.MainColor.Count()>=4){
        f.Key("mainColor");                
        Serialize_MainColor(f, value.MainColor);
    }

    if(value.MainTex!=null){
        f.Key("mainTex");                
        Serialize_MainTex(f, value.MainTex);
    }

    if(value.MainTexHSVG!=null&&value.MainTexHSVG.Count()>=4){
        f.Key("mainTexHSVG");                
        Serialize_MainTexHSVG(f, value.MainTexHSVG);
    }

    if(value.MainGradationStrength.HasValue){
        f.Key("mainGradationStrength");                
        f.Value(value.MainGradationStrength.GetValueOrDefault());
    }

    if(value.MainGradationTex!=null){
        f.Key("mainGradationTex");                
        Serialize_MainGradationTex(f, value.MainGradationTex);
    }

    if(value.MainColorAdjustMask!=null){
        f.Key("mainColorAdjustMask");                
        Serialize_MainColorAdjustMask(f, value.MainColorAdjustMask);
    }

    if(true){
        f.Key("alphaMaskMode");                
        f.Value(value.AlphaMaskMode.ToString());
    }

    if(value.AlphaMask!=null){
        f.Key("alphaMask");                
        Serialize_AlphaMask(f, value.AlphaMask);
    }

    if(value.AlphaMaskScale.HasValue){
        f.Key("alphaMaskScale");                
        f.Value(value.AlphaMaskScale.GetValueOrDefault());
    }

    if(value.AlphaMaskValue.HasValue){
        f.Key("alphaMaskValue");                
        f.Value(value.AlphaMaskValue.GetValueOrDefault());
    }

    if(value.UseShadow.HasValue){
        f.Key("useShadow");                
        f.Value(value.UseShadow.GetValueOrDefault());
    }

    if(true){
        f.Key("shadowMaskType");                
        f.Value(value.ShadowMaskType.ToString());
    }

    if(value.ShadowStrength.HasValue){
        f.Key("shadowStrength");                
        f.Value(value.ShadowStrength.GetValueOrDefault());
    }

    if(value.ShadowStrengthMask!=null){
        f.Key("shadowStrengthMask");                
        Serialize_ShadowStrengthMask(f, value.ShadowStrengthMask);
    }

    if(value.ShadowStrengthMaskLOD.HasValue){
        f.Key("shadowStrengthMaskLOD");                
        f.Value(value.ShadowStrengthMaskLOD.GetValueOrDefault());
    }

    if(value.ShadowFlatBorder.HasValue){
        f.Key("shadowFlatBorder");                
        f.Value(value.ShadowFlatBorder.GetValueOrDefault());
    }

    if(value.ShadowFlatBlur.HasValue){
        f.Key("shadowFlatBlur");                
        f.Value(value.ShadowFlatBlur.GetValueOrDefault());
    }

    if(true){
        f.Key("shadowColorType");                
        f.Value(value.ShadowColorType.ToString());
    }

    if(value.ShadowColor!=null&&value.ShadowColor.Count()>=4){
        f.Key("shadowColor");                
        Serialize_ShadowColor(f, value.ShadowColor);
    }

    if(value.ShadowColorTex!=null){
        f.Key("shadowColorTex");                
        Serialize_ShadowColorTex(f, value.ShadowColorTex);
    }

    if(value.ShadowBorder.HasValue){
        f.Key("shadowBorder");                
        f.Value(value.ShadowBorder.GetValueOrDefault());
    }

    if(value.ShadowBlur.HasValue){
        f.Key("shadowBlur");                
        f.Value(value.ShadowBlur.GetValueOrDefault());
    }

    if(value.ShadowReceive.HasValue){
        f.Key("shadowReceive");                
        f.Value(value.ShadowReceive.GetValueOrDefault());
    }

    if(value.Shadow2ndColor!=null&&value.Shadow2ndColor.Count()>=4){
        f.Key("shadow2ndColor");                
        Serialize_Shadow2ndColor(f, value.Shadow2ndColor);
    }

    if(value.Shadow2ndColorTex!=null){
        f.Key("shadow2ndColorTex");                
        Serialize_Shadow2ndColorTex(f, value.Shadow2ndColorTex);
    }

    if(value.Shadow2ndBorder.HasValue){
        f.Key("shadow2ndBorder");                
        f.Value(value.Shadow2ndBorder.GetValueOrDefault());
    }

    if(value.Shadow2ndBlur.HasValue){
        f.Key("shadow2ndBlur");                
        f.Value(value.Shadow2ndBlur.GetValueOrDefault());
    }

    if(value.Shadow2ndReceive.HasValue){
        f.Key("shadow2ndReceive");                
        f.Value(value.Shadow2ndReceive.GetValueOrDefault());
    }

    if(value.Shadow3rdColor!=null&&value.Shadow3rdColor.Count()>=4){
        f.Key("shadow3rdColor");                
        Serialize_Shadow3rdColor(f, value.Shadow3rdColor);
    }

    if(value.Shadow3rdColorTex!=null){
        f.Key("shadow3rdColorTex");                
        Serialize_Shadow3rdColorTex(f, value.Shadow3rdColorTex);
    }

    if(value.ShadowBorderColor!=null&&value.ShadowBorderColor.Count()>=3){
        f.Key("shadowBorderColor");                
        Serialize_ShadowBorderColor(f, value.ShadowBorderColor);
    }

    if(value.ShadowBorderRange.HasValue){
        f.Key("shadowBorderRange");                
        f.Value(value.ShadowBorderRange.GetValueOrDefault());
    }

    if(value.ShadowMainStrength.HasValue){
        f.Key("shadowMainStrength");                
        f.Value(value.ShadowMainStrength.GetValueOrDefault());
    }

    if(value.UseEmission.HasValue){
        f.Key("useEmission");                
        f.Value(value.UseEmission.GetValueOrDefault());
    }

    if(value.EmissionColor!=null&&value.EmissionColor.Count()>=4){
        f.Key("emissionColor");                
        Serialize_EmissionColor(f, value.EmissionColor);
    }

    if(value.EmissionTex!=null){
        f.Key("emissionTex");                
        Serialize_EmissionTex(f, value.EmissionTex);
    }

    if(value.EmissionTexScrollRotate!=null&&value.EmissionTexScrollRotate.Count()>=4){
        f.Key("emissionTexScrollRotate");                
        Serialize_EmissionTexScrollRotate(f, value.EmissionTexScrollRotate);
    }

    if(true){
        f.Key("emissionTexUVMode");                
        f.Value(value.EmissionTexUVMode.ToString());
    }

    if(value.EmissionMainStrength.HasValue){
        f.Key("emissionMainStrength");                
        f.Value(value.EmissionMainStrength.GetValueOrDefault());
    }

    if(value.EmissionBlend.HasValue){
        f.Key("emissionBlend");                
        f.Value(value.EmissionBlend.GetValueOrDefault());
    }

    if(value.EmissionBlendMask!=null){
        f.Key("emissionBlendMask");                
        Serialize_EmissionBlendMask(f, value.EmissionBlendMask);
    }

    if(value.EmissionBlendMaskScrollRotate!=null&&value.EmissionBlendMaskScrollRotate.Count()>=4){
        f.Key("emissionBlendMaskScrollRotate");                
        Serialize_EmissionBlendMaskScrollRotate(f, value.EmissionBlendMaskScrollRotate);
    }

    if(true){
        f.Key("emissionBlendMode");                
        f.Value(value.EmissionBlendMode.ToString());
    }

    if(value.EmissionFluorescence.HasValue){
        f.Key("emissionFluorescence");                
        f.Value(value.EmissionFluorescence.GetValueOrDefault());
    }

    if(value.UseEmission2nd.HasValue){
        f.Key("useEmission2nd");                
        f.Value(value.UseEmission2nd.GetValueOrDefault());
    }

    if(value.Emission2ndColor!=null&&value.Emission2ndColor.Count()>=4){
        f.Key("emission2ndColor");                
        Serialize_Emission2ndColor(f, value.Emission2ndColor);
    }

    if(value.Emission2ndTex!=null){
        f.Key("emission2ndTex");                
        Serialize_Emission2ndTex(f, value.Emission2ndTex);
    }

    if(value.Emission2ndTexScrollRotate!=null&&value.Emission2ndTexScrollRotate.Count()>=4){
        f.Key("emission2ndTexScrollRotate");                
        Serialize_Emission2ndTexScrollRotate(f, value.Emission2ndTexScrollRotate);
    }

    if(true){
        f.Key("emission2ndTexUVMode");                
        f.Value(value.Emission2ndTexUVMode.ToString());
    }

    if(value.Emission2ndMainStrength.HasValue){
        f.Key("emission2ndMainStrength");                
        f.Value(value.Emission2ndMainStrength.GetValueOrDefault());
    }

    if(value.Emission2ndBlend.HasValue){
        f.Key("emission2ndBlend");                
        f.Value(value.Emission2ndBlend.GetValueOrDefault());
    }

    if(value.Emission2ndBlendMask!=null){
        f.Key("emission2ndBlendMask");                
        Serialize_Emission2ndBlendMask(f, value.Emission2ndBlendMask);
    }

    if(value.Emission2ndBlendMaskScrollRotate!=null&&value.Emission2ndBlendMaskScrollRotate.Count()>=4){
        f.Key("emission2ndBlendMaskScrollRotate");                
        Serialize_Emission2ndBlendMaskScrollRotate(f, value.Emission2ndBlendMaskScrollRotate);
    }

    if(true){
        f.Key("emission2ndBlendMode");                
        f.Value(value.Emission2ndBlendMode.ToString());
    }

    if(value.Emission2ndFluorescence.HasValue){
        f.Key("emission2ndFluorescence");                
        f.Value(value.Emission2ndFluorescence.GetValueOrDefault());
    }

    if(value.UseNormalMap.HasValue){
        f.Key("useNormalMap");                
        f.Value(value.UseNormalMap.GetValueOrDefault());
    }

    if(value.NormalTex!=null){
        f.Key("normalTex");                
        Serialize_NormalTex(f, value.NormalTex);
    }

    if(value.NormalTexScale.HasValue){
        f.Key("normalTexScale");                
        f.Value(value.NormalTexScale.GetValueOrDefault());
    }

    if(value.UseNormal2ndMap.HasValue){
        f.Key("useNormal2ndMap");                
        f.Value(value.UseNormal2ndMap.GetValueOrDefault());
    }

    if(value.Normal2ndTex!=null){
        f.Key("normal2ndTex");                
        Serialize_Normal2ndTex(f, value.Normal2ndTex);
    }

    if(true){
        f.Key("normal2ndTexUVMode");                
        f.Value(value.Normal2ndTexUVMode.ToString());
    }

    if(value.Normal2ndTexScale.HasValue){
        f.Key("normal2ndTexScale");                
        f.Value(value.Normal2ndTexScale.GetValueOrDefault());
    }

    if(value.Normal2ndTexScaleMask!=null){
        f.Key("normal2ndTexScaleMask");                
        Serialize_Normal2ndTexScaleMask(f, value.Normal2ndTexScaleMask);
    }

    if(value.UseMatCap.HasValue){
        f.Key("useMatCap");                
        f.Value(value.UseMatCap.GetValueOrDefault());
    }

    if(value.MatCapColor!=null&&value.MatCapColor.Count()>=4){
        f.Key("matCapColor");                
        Serialize_MatCapColor(f, value.MatCapColor);
    }

    if(value.MatCapTex!=null){
        f.Key("matCapTex");                
        Serialize_MatCapTex(f, value.MatCapTex);
    }

    if(value.MatCapBlendUV1!=null&&value.MatCapBlendUV1.Count()>=4){
        f.Key("matCapBlendUV1");                
        Serialize_MatCapBlendUV1(f, value.MatCapBlendUV1);
    }

    if(value.MatCapZRotCancel.HasValue){
        f.Key("matCapZRotCancel");                
        f.Value(value.MatCapZRotCancel.GetValueOrDefault());
    }

    if(value.MatCapPerspective.HasValue){
        f.Key("matCapPerspective");                
        f.Value(value.MatCapPerspective.GetValueOrDefault());
    }

    if(value.MatCapVRParallaxStrength.HasValue){
        f.Key("matCapVRParallaxStrength");                
        f.Value(value.MatCapVRParallaxStrength.GetValueOrDefault());
    }

    if(value.MatCapBlend.HasValue){
        f.Key("matCapBlend");                
        f.Value(value.MatCapBlend.GetValueOrDefault());
    }

    if(value.MatCapBlendMask!=null){
        f.Key("matCapBlendMask");                
        Serialize_MatCapBlendMask(f, value.MatCapBlendMask);
    }

    if(value.MatCapEnableLighting.HasValue){
        f.Key("matCapEnableLighting");                
        f.Value(value.MatCapEnableLighting.GetValueOrDefault());
    }

    if(true){
        f.Key("matCapBlendMode");                
        f.Value(value.MatCapBlendMode.ToString());
    }

    if(value.UseMatCap2nd.HasValue){
        f.Key("useMatCap2nd");                
        f.Value(value.UseMatCap2nd.GetValueOrDefault());
    }

    if(value.MatCap2ndColor!=null&&value.MatCap2ndColor.Count()>=4){
        f.Key("matCap2ndColor");                
        Serialize_MatCap2ndColor(f, value.MatCap2ndColor);
    }

    if(value.MatCap2ndTex!=null){
        f.Key("matCap2ndTex");                
        Serialize_MatCap2ndTex(f, value.MatCap2ndTex);
    }

    if(value.MatCap2ndBlendUV1!=null&&value.MatCap2ndBlendUV1.Count()>=4){
        f.Key("matCap2ndBlendUV1");                
        Serialize_MatCap2ndBlendUV1(f, value.MatCap2ndBlendUV1);
    }

    if(value.MatCap2ndZRotCancel.HasValue){
        f.Key("matCap2ndZRotCancel");                
        f.Value(value.MatCap2ndZRotCancel.GetValueOrDefault());
    }

    if(value.MatCap2ndPerspective.HasValue){
        f.Key("matCap2ndPerspective");                
        f.Value(value.MatCap2ndPerspective.GetValueOrDefault());
    }

    if(value.MatCap2ndVRParallaxStrength.HasValue){
        f.Key("matCap2ndVRParallaxStrength");                
        f.Value(value.MatCap2ndVRParallaxStrength.GetValueOrDefault());
    }

    if(value.MatCap2ndBlend.HasValue){
        f.Key("matCap2ndBlend");                
        f.Value(value.MatCap2ndBlend.GetValueOrDefault());
    }

    if(value.MatCap2ndBlendMask!=null){
        f.Key("matCap2ndBlendMask");                
        Serialize_MatCap2ndBlendMask(f, value.MatCap2ndBlendMask);
    }

    if(value.MatCap2ndEnableLighting.HasValue){
        f.Key("matCap2ndEnableLighting");                
        f.Value(value.MatCap2ndEnableLighting.GetValueOrDefault());
    }

    if(true){
        f.Key("matCap2ndBlendMode");                
        f.Value(value.MatCap2ndBlendMode.ToString());
    }

    if(value.UseRim.HasValue){
        f.Key("useRim");                
        f.Value(value.UseRim.GetValueOrDefault());
    }

    if(value.RimColor!=null&&value.RimColor.Count()>=4){
        f.Key("rimColor");                
        Serialize_RimColor(f, value.RimColor);
    }

    if(value.RimColorTex!=null){
        f.Key("rimColorTex");                
        Serialize_RimColorTex(f, value.RimColorTex);
    }

    if(value.RimBorder.HasValue){
        f.Key("rimBorder");                
        f.Value(value.RimBorder.GetValueOrDefault());
    }

    if(value.RimBlur.HasValue){
        f.Key("rimBlur");                
        f.Value(value.RimBlur.GetValueOrDefault());
    }

    if(value.RimFresnelPower.HasValue){
        f.Key("rimFresnelPower");                
        f.Value(value.RimFresnelPower.GetValueOrDefault());
    }

    if(value.RimDirStrength.HasValue){
        f.Key("rimDirStrength");                
        f.Value(value.RimDirStrength.GetValueOrDefault());
    }

    if(value.RimDirRange.HasValue){
        f.Key("rimDirRange");                
        f.Value(value.RimDirRange.GetValueOrDefault());
    }

    if(value.RimIndirRange.HasValue){
        f.Key("rimIndirRange");                
        f.Value(value.RimIndirRange.GetValueOrDefault());
    }

    if(value.RimIndirColor!=null&&value.RimIndirColor.Count()>=4){
        f.Key("rimIndirColor");                
        Serialize_RimIndirColor(f, value.RimIndirColor);
    }

    if(value.RimIndirBorder.HasValue){
        f.Key("rimIndirBorder");                
        f.Value(value.RimIndirBorder.GetValueOrDefault());
    }

    if(value.RimIndirBlur.HasValue){
        f.Key("rimIndirBlur");                
        f.Value(value.RimIndirBlur.GetValueOrDefault());
    }

    if(true){
        f.Key("rimBlendMode");                
        f.Value(value.RimBlendMode.ToString());
    }

    if(value.UseOutline.HasValue){
        f.Key("useOutline");                
        f.Value(value.UseOutline.GetValueOrDefault());
    }

    if(value.OutlineColor!=null&&value.OutlineColor.Count()>=4){
        f.Key("outlineColor");                
        Serialize_OutlineColor(f, value.OutlineColor);
    }

    if(value.OutlineTex!=null){
        f.Key("outlineTex");                
        Serialize_OutlineTex(f, value.OutlineTex);
    }

    if(value.OutlineTexScrollRotate!=null&&value.OutlineTexScrollRotate.Count()>=4){
        f.Key("outlineTexScrollRotate");                
        Serialize_OutlineTexScrollRotate(f, value.OutlineTexScrollRotate);
    }

    if(value.OutlineWidth.HasValue){
        f.Key("outlineWidth");                
        f.Value(value.OutlineWidth.GetValueOrDefault());
    }

    if(value.OutlineWidthMask!=null){
        f.Key("outlineWidthMask");                
        Serialize_OutlineWidthMask(f, value.OutlineWidthMask);
    }

    f.EndMap();
}

public static void Serialize_DitherTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_MainColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_MainTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_MainTexHSVG(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_MainGradationTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_MainColorAdjustMask(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_AlphaMask(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_ShadowStrengthMask(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_ShadowColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_ShadowColorTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_Shadow2ndColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_Shadow2ndColorTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_Shadow3rdColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_Shadow3rdColorTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_ShadowBorderColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_EmissionColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_EmissionTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_EmissionTexScrollRotate(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_EmissionBlendMask(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_EmissionBlendMaskScrollRotate(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_Emission2ndColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_Emission2ndTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_Emission2ndTexScrollRotate(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_Emission2ndBlendMask(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_Emission2ndBlendMaskScrollRotate(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_NormalTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_Normal2ndTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_Normal2ndTexScaleMask(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_MatCapColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_MatCapTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_MatCapBlendUV1(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_MatCapBlendMask(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_MatCap2ndColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_MatCap2ndTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_MatCap2ndBlendUV1(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_MatCap2ndBlendMask(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_RimColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_RimColorTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_RimIndirColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_OutlineColor(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_OutlineTex(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

public static void Serialize_OutlineTexScrollRotate(JsonFormatter f, float[] value)
{
    f.BeginList();

    foreach(var item in value)
    {
    f.Value(item);

    }
    f.EndList();
}

public static void Serialize_OutlineWidthMask(JsonFormatter f, TextureInfo value)
{
    f.BeginMap();


    if(value.Extensions!=null){
        f.Key("extensions");                
        (value.Extensions as glTFExtension).Serialize(f);
    }

    if(value.Extras!=null){
        f.Key("extras");                
        (value.Extras as glTFExtension).Serialize(f);
    }

    if(value.Index.HasValue){
        f.Key("index");                
        f.Value(value.Index.GetValueOrDefault());
    }

    if(value.TexCoord.HasValue){
        f.Key("texCoord");                
        f.Value(value.TexCoord.GetValueOrDefault());
    }

    f.EndMap();
}

    } // class
} // namespace
