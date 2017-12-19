#if UNITY_EDITOR
using UnityEditor;

internal sealed class CustomAssetImporter : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        var importer = assetImporter as TextureImporter;

        importer.alphaIsTransparency = importer.DoesSourceTextureHaveAlpha();

    }

    private void OnPreprocessModel()
    {
        var importer = assetImporter as ModelImporter;

        // If it is static we don't want any kind of animation imported
        importer.animationType = ModelImporterAnimationType.None;
        importer.importAnimation = false;
        importer.generateSecondaryUV = true;
        importer.addCollider = true;


        importer.materialSearch = ModelImporterMaterialSearch.Local;
        importer.materialName = ModelImporterMaterialName.BasedOnMaterialName;
    }
}
#endif