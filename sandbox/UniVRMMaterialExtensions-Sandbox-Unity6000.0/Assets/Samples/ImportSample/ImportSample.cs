using System.IO;
using UnityEngine;
using UniVRM10;
using UniVRM10.Extensions.Materials.lilToon;

namespace Sandbox
{
    public sealed class ImportSample : MonoBehaviour
    {
        [SerializeField] string _streamingAssetsPath = "VRM/Sample_Alpha_PerfectSync_lilToon.vrm";

        async void Start()
        {
            var filePath = Path.Combine(Application.streamingAssetsPath, _streamingAssetsPath);
            var materialGenerator = new lilToonMaterialDescriptorGenerator();

            await Vrm10.LoadPathAsync(
                path: filePath,
                canLoadVrm0X: true,
                showMeshes: true,
                materialGenerator: materialGenerator,
                ct: default);
        }
    }
}
