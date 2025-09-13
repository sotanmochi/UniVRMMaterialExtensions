// This is a modified version of the VrmScriptedImporterImpl class from UniVRM package.
//
// The original source code is available on GitHub.
// https://github.com/vrm-c/UniVRM/blob/v0.128.1/Assets/VRM10/Editor/ScriptedImporter/VrmScriptedImporterImpl.cs
//
// ---
// Copyright (c) 2020 VRM Consortium
// Licensed under the MIT License.
// ---

using System.Linq;
using UnityEngine;
using UniGLTF;
using System;

#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif


namespace UniVRM10.Extensions.Materials
{
    public static class VrmScriptedImporterImpl
    {
        /// <summary>
        /// Vrm-1.0 の Asset にアイコンを付与する
        /// </summary>
        static Texture2D _AssetIcon = null;
        static Texture2D AssetIcon
        {
            get
            {
                if (_AssetIcon == null)
                {
                    // try package
                    _AssetIcon = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.vrmc.vrm/Icons/vrm-48x48.png");
                }
                if (_AssetIcon == null)
                {
                    // try assets
                    _AssetIcon = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/VRM10/Icons/vrm-48x48.png");
                }
                return _AssetIcon;
            }
        }

        static void Process(Vrm10Data result, ScriptedImporter scriptedImporter, AssetImportContext context, Func<IMaterialDescriptorGenerator> materialGeneratorFactory)
        {
            //
            // Import(create unity objects)
            //
            var extractedObjects = scriptedImporter.GetExternalObjectMap()
                .Where(kv => kv.Value != null)
                .ToDictionary(kv => new SubAssetKey(kv.Value.GetType(), kv.Key.name), kv => kv.Value);

            var materialGenerator = materialGeneratorFactory.Invoke();

            using (var loader = new Vrm10Importer(result, 
                externalObjectMap: extractedObjects, 
                materialGenerator: materialGenerator,
                isAssetImport: true))
            {
                // settings TextureImporters
                foreach (var textureInfo in loader.TextureDescriptorGenerator.Get().GetEnumerable())
                {
                    TextureImporterConfigurator.Configure(textureInfo, loader.TextureFactory.ExternalTextures);
                }

                var loaded = loader.Load();
                loaded.ShowMeshes();

                loaded.TransferOwnership((key, o) =>
                {
                    context.AddObjectToAsset(key.Name, o);
                });
                var root = loaded.Root;
                GameObject.DestroyImmediate(loaded);

                context.AddObjectToAsset(root.name, root, AssetIcon);
                context.SetMainObject(root);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scriptedImporter"></param>
        /// <param name="context"></param>
        /// <param name="doMigrate">vrm0 だった場合に vrm1 化する</param>
        /// <param name="renderPipeline"></param>
        /// <param name="doNormalize">normalize する</param>
        public static void Import(ScriptedImporter scriptedImporter, AssetImportContext context, bool doMigrate, Func<IMaterialDescriptorGenerator> materialGeneratorFactory)
        {
            if (Symbols.VRM_DEVELOP)
            {
                Debug.Log("OnImportAsset to " + scriptedImporter.assetPath);
            }

            // 1st parse as vrm1
            using (var data = new GlbFileParser(scriptedImporter.assetPath).Parse())
            {
                var vrm1Data = Vrm10Data.Parse(data);
                if (vrm1Data != null)
                {
                    // successfully parsed vrm-1.0
                    Process(vrm1Data, scriptedImporter, context, materialGeneratorFactory);
                }

                if (!doMigrate)
                {
                    return;
                }

                // try migration...
                MigrationData migration;
                using (var migrated = Vrm10Data.Migrate(data, out vrm1Data, out migration))
                {
                    if (vrm1Data != null)
                    {
                        Process(vrm1Data, scriptedImporter, context, materialGeneratorFactory);
                    }
                }

                // fail to migrate...
                if (migration != null)
                {
                    Debug.LogWarning(migration.Message);
                }
                return;
            }
        }
    }
}