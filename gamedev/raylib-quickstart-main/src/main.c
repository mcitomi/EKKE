/*
Raylib example file.
This is an example main file for a simple raylib project.
Use this as a starting point or replace it with your code.

by Jeffery Myers is marked with CC0 1.0. To view a copy of this license, visit https://creativecommons.org/publicdomain/zero/1.0/

*/

#include "raylib.h"

#include "resource_dir.h"	// utility header for SearchAndSetResourceDir

int main ()
{
	// Tell the window to use vsync and work on high DPI displays
	SetConfigFlags(FLAG_VSYNC_HINT | FLAG_WINDOW_HIGHDPI);

	// Create the window and OpenGL context
	InitWindow(1280, 800, "SZIA Raylib");

	// Utility function from resource_dir.h to find the resources folder and set it as the current working directory so we can load from it
	SearchAndSetResourceDir("resources");

	SetTargetFPS(60);

	// Load a texture from the resources directory
	Texture yuumi = LoadTexture("yuumi.png");
	Texture tree = LoadTexture("tree.png");
	Texture2D bg = LoadTexture("bg.png");

	Vector2 player = {250, 250};
	Vector2 treePos = {700, 400};
	
	// game loop
	while (!WindowShouldClose())		// run the loop untill the user presses ESCAPE or presses the Close button on the window
	{
		// --- Input check ---
		if (IsKeyDown(KEY_RIGHT)) player.x += 5.0f;
        if (IsKeyDown(KEY_LEFT)) player.x -= 5.0f;
        if (IsKeyDown(KEY_UP)) player.y -= 5.0f;
        if (IsKeyDown(KEY_DOWN)) player.y += 5.0f;

		Rectangle playerRect = { player.x, player.y, (float)yuumi.width, (float)yuumi.height };
        Rectangle treeRect   = { treePos.x, treePos.y, (float)tree.width, (float)tree.height };

        // --- Collision check ---
        bool collision = CheckCollisionRecs(playerRect, treeRect);
		
		// drawing
		BeginDrawing();

		// Setup the back buffer for drawing (clear color and depth buffers)
		ClearBackground(BLACK);
		DrawTexture(bg, 0, 0, WHITE);

		// draw some text using the default font
		DrawText("Szia Raylib", 200,200,20,WHITE);

		// draw our texture to the screen
		if (collision)
        {
            DrawTexture(yuumi, player.x, player.y, RED);
            DrawText("COLLISION!", 500, 200, 40, YELLOW);
        }
        else
        {
            DrawTexture(yuumi, player.x, player.y, WHITE);
        }

		DrawTexture(tree, treePos.x, treePos.y, WHITE);
		
		
		// end the frame and get ready for the next one  (display frame, poll input, etc...)
		EndDrawing();
	}

	// cleanup
	// unload our texture so it can be cleaned up
	UnloadTexture(yuumi);
	UnloadTexture(tree);

	// destroy the window and cleanup the OpenGL context
	CloseWindow();
	return 0;
}
