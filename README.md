# Guess-Game
This is simple guessing game with a few rules and a very simple UI, implemented with focus on demonstraiting OO design, clean code, unit testing with TDD approach.   
    
The specifications are as follows:    
* A white screen with 4 boxes on the 4 corners of the screen.   
* Each box will have a text on it reading ""Japanese"", ""Chinese"", ""Korean"" and ""Thai"".   
* From the middle top of the screen, the photo of a person should drop and slowly go to the bottom of the screen within 3 seconds.    
* As the image is dropping down, the user should guess the nationality of the person before it reaches the bottom, and throw it towards one of the 4 nationality boxes by panning it.   
* If the user guessed correctly, it will be a positive 20 points.If it was wrong it will be -5 points.    
* The total points should be displayed at the bottom of the screen.   
* Immediately after the picture has disappeared, the next picture should drop.    
* This should continue for 10 or more pictures and then the game will stop, showing the user's total score, with a button to play again.    
