using System;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using System.IO;

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
    // TODO: Magic numbers
    private void DrawCube(int col, int row, JArray face) {
        // Draw tiles
        for ( int y = 0; y < 3; y++) {
            for ( int x = 0; x < 3; x++) {
                DrawTile( col + x * 6, row + y * 4, (string)face[y][x] );
            }
        }
    }

    // TODO: Magic Numbers
    private void DrawTile(int col, int row, string colour) {
        Console.SetCursorPosition(col, row);
        Console.Write("+-----+");
        for ( int j = 1; j <= 3; j++) {
            Console.SetCursorPosition(col, row + j);
            Console.Write("|     |");
            // Draw Tile Face, with this colour
            Console.SetCursorPosition(col + 1, row + j);
            ConsoleColor currentForegroundColor = Console.ForegroundColor;
            ConsoleColor tileColor;
            switch (colour) {
                case "R":
                    tileColor = ConsoleColor.Red;
                    break;

                case "W":
                    tileColor = ConsoleColor.White;
                    break;

                case "G":
                    tileColor = ConsoleColor.Green;
                    break;

                case "B":
                    tileColor = ConsoleColor.Blue;
                    break;

                case "Y":
                    tileColor = ConsoleColor.Yellow;
                    break;

                case "O":
                    tileColor = ConsoleColor.Magenta;
                    break;

                default:
                    tileColor = currentForegroundColor;
                    break;
            } 
            Console.ForegroundColor = tileColor;
            Console.Write("#####");
            Console.ForegroundColor = currentForegroundColor;
        }
        Console.SetCursorPosition(col, row + 4);
        Console.Write("+-----+");
    }

    SKColor GetTileColor(string tileColor) {
        SKColor thisColor = default(SKColor);

        switch (tileColor) {
            case "O":
                thisColor = SKColors.Orange;
                break;

            case "W":
                thisColor = SKColors.White;
                break;

            case "R":
                thisColor = SKColors.Red;
                break;
            
            case "G":
                thisColor = SKColors.Green;
                break;

            case "Y":
                thisColor = SKColors.Yellow;
                break;

            case "B":
                thisColor = SKColors.Blue;
                break;
        }

        return thisColor;
    }
}