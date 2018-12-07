using System;
using Newtonsoft.Json.Linq;
using cube_scrambler;

public class ConsoleCubeDrawer : ICubeDrawer {
    JArray[] _cube;

    public ConsoleCubeDrawer() {
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

        // Console.WriteLine(cubeJson);

        // int top = Console.WindowTop;
        // int left = Console.WindowLeft;
        // int right = Console.WindowWidth;
        // int bottom = Console.WindowHeight;

        // Console.WriteLine("{0} x {1} - {2} x {3}", top, left, bottom, right);

        // Console.WriteLine("Foreground: {0}; Background: {1}", Console.ForegroundColor, Console.BackgroundColor);

        // Console.WriteLine($"Buffer - Height: {Console.BufferHeight}; Width: {Console.BufferWidth}");

        // Draw Cube Frame
        // TODO: Magic Numbers
        int startRow = 5, startCol = 10;

        // Draw each face
        DrawCube(startCol + 18, startRow, _cube[4]);   // Up
        DrawCube(startCol, startRow + 12, _cube[0]);   // Left
        DrawCube(startCol + 18, startRow + 12, _cube[1]);   // Front
        DrawCube(startCol + 18, startRow + 24, _cube[5]);   // Down
        DrawCube(startCol + 36, startRow + 12, _cube[2]);   // Right
        DrawCube(startCol + 54, startRow + 12, _cube[3]);   // Back

        Console.SetCursorPosition(startCol, startRow + 38);
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
                case CubeHelper.RED:
                    tileColor = ConsoleColor.Red;
                    break;

                case CubeHelper.WHITE:
                    tileColor = ConsoleColor.White;
                    break;

                case CubeHelper.GREEN:
                    tileColor = ConsoleColor.Green;
                    break;

                case CubeHelper.BLUE:
                    tileColor = ConsoleColor.Blue;
                    break;

                case CubeHelper.YELLOW:
                    tileColor = ConsoleColor.Yellow;
                    break;

                case CubeHelper.ORANGE:
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
}