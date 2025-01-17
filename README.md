# Flappy-Bird-Recreation-in-WPF
This project is a faithful recreation of the iconic game Flappy Bird, developed using C# and the WPF framework. It features the original game’s visuals and aims to capture the classic gameplay experience. As one of my first major projects with WPF, this endeavor has been a great opportunity to deepen my understanding of the framework while tackling a fun and nostalgic challenge.

Intial Entry:
Initial setup: Added project structure, parallax background, and placeholder ball for the bird.

First Update:
Reworked the Bird class and added them to the main grid to appear on the screen. Reworked the background to also work with the canvas (Where the bird object is a child of).

Second Update:
I cleaned up the code for the MainWindow.xaml.cs by introducing the background class that will take care of creating background objects, assigning layers by reference and setting its layer. I also reworked the bird class to do the same. This allows for the main window file to be less cluttered, much more organized, and legible. 
