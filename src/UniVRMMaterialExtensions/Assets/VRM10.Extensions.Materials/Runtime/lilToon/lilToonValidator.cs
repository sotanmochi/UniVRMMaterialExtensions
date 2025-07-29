using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace UniVRM10.Extensions.Materials.lilToon
{
    public sealed class lilToonValidator
    {
        private readonly Material _material;

        public lilToonValidator(Material material)
        {
            _material = material;
        }

        public void Validate()
        {
            _material.SetFloat(lilToonPropertyType.ZWrite.ToUnityShaderLabName(), 1.0f);
        }
    }
}
