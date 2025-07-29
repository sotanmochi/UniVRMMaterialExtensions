using UnityEngine;
using UnityEngine.Rendering;

namespace UniVRM10.Extensions.Materials
{
    public static class RenderPipelineUtility
    {
        public static RenderPipelineType GetRenderPipelineType()
        {
            var renderPipelineAsset = GraphicsSettings.currentRenderPipeline;
            if (renderPipelineAsset == null)
            {
                return RenderPipelineType.BuiltinRenderPipeline;
            }

            if (renderPipelineAsset.GetType().Name == "UniversalRenderPipelineAsset")
            {
                return RenderPipelineType.UniversalRenderPipeline;
            }

            if (renderPipelineAsset.GetType().Name == "HDRenderPipelineAsset")
            {
                return RenderPipelineType.HighDefinitionRenderPipeline;
            }

            return RenderPipelineType.Unknown;
        }
    }
    
    public enum RenderPipelineType
    {
        BuiltinRenderPipeline,
        UniversalRenderPipeline,
        HighDefinitionRenderPipeline,
        Unknown
    }
}