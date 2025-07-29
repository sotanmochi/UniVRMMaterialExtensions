using System.IO;
using UnityEngine;

namespace UniVRM10.Extensions.Materials
{
    /// <summary>
    /// Generate lilToon serializer from json schema.
    /// </summary>
    public static class lilToonMaterialSerializerGenerator
    {
        private struct GenerateInfo
        {
            public string JsonSchema;
            public string FormatDir;
            public string SerializerDir;

            public GenerateInfo(string jsonSchema, string formatDir, string serializerDir)
            {
                JsonSchema = jsonSchema;
                FormatDir = formatDir;
                SerializerDir = serializerDir;
            }

            public GenerateInfo(string jsonSchema, string formatDir) : this(jsonSchema, formatDir, formatDir)
            {
            }
        }

        private static readonly string SpecificationsDir = "specifications";
        private static readonly string MaterialFormatGeneratedDir = $"Assets/VRM10.Extensions.Materials/Runtime/lilToon/Format";

        public static void Run(bool debug)
        {
            var projectRoot = Path.GetFullPath(Path.Combine(Application.dataPath, "../"));
            var repositoryRoot = Path.GetFullPath(Path.Combine(Application.dataPath, "../../../"));
            var gltf = new FileInfo(Path.Combine(repositoryRoot, SpecificationsDir, "glTF/specification/2.0/schema/glTF.schema.json"));

            var args = new GenerateInfo[]
            {
                // EXT_materials_liltoon_simple
                new GenerateInfo(
                    $"{repositoryRoot}/{SpecificationsDir}/EXT_materials_liltoon_simple/schema/EXT_materials_liltoon_simple.schema.json",
                    $"{projectRoot}/{MaterialFormatGeneratedDir}/Simple"
                ),
            };

            foreach (var arg in args)
            {
                var extensionSchemaPath = new FileInfo(arg.JsonSchema);
                var parser = new UniGLTF.JsonSchema.JsonSchemaParser(gltf.Directory, extensionSchemaPath.Directory);
                var extensionSchema = parser.Load(extensionSchemaPath, "");

                var formatDst = new DirectoryInfo(arg.FormatDir);
                Debug.Log($"Format.g Dir: {formatDst}");

                var serializerDst = new DirectoryInfo(arg.SerializerDir);
                Debug.Log($"Serializer/Deserializer.g Dir: {serializerDst}");

                if (debug)
                {
                    Debug.Log(extensionSchema.Dump());
                }
                else
                {
                    GenerateUniGLTFSerialization.Generator.GenerateTo(extensionSchema, formatDst, serializerDst);
                }
            }
        }
    }
}
