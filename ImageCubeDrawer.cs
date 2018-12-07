using System;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using System.IO;
using cube_scrambler;

public class ImageCubeDrawer : ICubeDrawer {
    JArray[] _cube;

    public ImageCubeDrawer() {
        _cube = new JArray[6];
    }

    public void Draw(string cubeJson) {

        // Parse Json
        JObject cubeObject = JObject.Parse(cubeJson);

        // Get arrays
        _cube[0] = (JArray)cubeObject["left"];
        _cube[1] = (JArray)cubeObject["front"];
        _cube[2] = (JArray)cubeObject["right"];
        _cube[3] = (JArray)cubeObject["back"];
        _cube[4] = (JArray)cubeObject["up"];
        _cube[5] = (JArray)cubeObject["down"];

        // create a surface to draw onto
        var info  = new SKImageInfo(256,256);
        using (var surface = SKSurface.Create(info)) {
            // draw onto the surface canvas
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            // draw left face
            DrawFace(25,62,_cube[0],canvas);
            // draw front face
            DrawFace(62,62,_cube[1],canvas);
            // draw right face
            DrawFace(99,62,_cube[2],canvas);
            // Draw back face
            DrawFace(136,62,_cube[3],canvas);
            // draw up face
            DrawFace(62,25,_cube[4],canvas);
            // draw down face
            DrawFace(62,99,_cube[5],canvas);

            // save the file
            using ( var image = surface.Snapshot() )
            using ( var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using ( var stream = File.OpenWrite($@"{Directory.GetCurrentDirectory()}\image.png")) {
                data.SaveTo(stream);
            }
            
        }
        
    }

    void DrawFace(int x, int y, JArray face, SKCanvas canvas) {
        // draw a line
            var outerLinePaint = new SKPaint {
                Color = SKColors.Black,
                StrokeWidth = 2,
                Style = SKPaintStyle.Stroke

            };

            var innerLinePaint = new SKPaint {
                Color = SKColors.Black,
                StrokeWidth = 1,
                Style = SKPaintStyle.Stroke
            };

            // outer lines
            var path = new SKPath();
            path.MoveTo(x,y);
            path.LineTo(x+37,y);
            path.LineTo(x+37,y+37);
            path.LineTo(x,y+37);
            path.LineTo(x,y-1);
            canvas.DrawPath(path, outerLinePaint);
            // inner lines
            canvas.DrawLine(x+12,y,x+12,y+37, innerLinePaint);
            canvas.DrawLine(x+24,y,x+24,y+37, innerLinePaint);
            canvas.DrawLine(x,y+12,x+37,y+12, innerLinePaint);
            canvas.DrawLine(x,y+24,x+37,y+24, innerLinePaint);
            // tiles
            SKPaint tilePaint = new SKPaint {
                Color = SKColors.Black,
                StrokeWidth = 1,
                Style = SKPaintStyle.StrokeAndFill
            };
            // select color based on tile
            // just draw left face
            // toprow
            tilePaint.Color = GetTileColor((string)face[0][0]);
            canvas.DrawRect(x+1,y+1,10,10, tilePaint);
            tilePaint.Color = GetTileColor((string)face[0][1]);
            canvas.DrawRect(x+13,y+1,10,10, tilePaint);
            tilePaint.Color = GetTileColor((string)face[0][2]);
            canvas.DrawRect(x+25,y+1,10,10, tilePaint);
            // middle row
            tilePaint.Color = GetTileColor((string)face[1][0]);
            canvas.DrawRect(x+1,y+13,10,10, tilePaint);
            tilePaint.Color = GetTileColor((string)face[1][1]);
            canvas.DrawRect(x+13,y+13,10,10, tilePaint);
            tilePaint.Color = GetTileColor((string)face[1][2]);
            canvas.DrawRect(x+25,y+13,10,10, tilePaint);
            // bottom row
            tilePaint.Color = GetTileColor((string)face[2][0]);
            canvas.DrawRect(x+1,y+25,10,10, tilePaint);
            tilePaint.Color = GetTileColor((string)face[2][1]);
            canvas.DrawRect(x+13,y+25,10,10, tilePaint);
            tilePaint.Color = GetTileColor((string)face[2][2]);
            canvas.DrawRect(x+25,y+25,10,10, tilePaint);
    }
    SKColor GetTileColor(string tileColor) {
        SKColor thisColor = default(SKColor);

        switch (tileColor) {
            case CubeHelper.ORANGE:
                thisColor = SKColors.Orange;
                break;

            case CubeHelper.WHITE:
                thisColor = SKColors.White;
                break;

            case CubeHelper.RED:
                thisColor = SKColors.Red;
                break;
            
            case CubeHelper.GREEN:
                thisColor = SKColors.Green;
                break;

            case CubeHelper.YELLOW:
                thisColor = SKColors.Yellow;
                break;

            case CubeHelper.BLUE:
                thisColor = SKColors.Blue;
                break;
        }

        return thisColor;
    }
}