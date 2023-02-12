using System;
using UnityEditor;

namespace FUIEditor
{
    public class FUITextureImporterSetting : AssetPostprocessor
    {
        private void OnPreprocessTexture()
        {
            TextureImporter textureImporter=assetImporter as TextureImporter;
            if (textureImporter != null && textureImporter.assetPath.IndexOf("FUI")!=-1)
            {
                textureImporter.mipmapEnabled = false;
            }
        }
    }
}