using UnityEngine;
using System.IO;

public static class JpgToSpriteConvert 
{
    public static Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
    {
        Texture2D SpriteTexture = LoadTexture(FilePath);
        Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit, 0, spriteType);

        return NewSprite;
    }

    static Texture2D LoadTexture(string filePath)
    {
        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(filePath))
        {
            FileData = File.ReadAllBytes(filePath);
            Tex2D = new Texture2D(2, 2);          
            if (Tex2D.LoadImage(FileData))           
                return Tex2D;                 
        }
        return null;                    
    }
}
