// This static class is used to store global variables of the game
// such as game pause/resume

public static class gameState{
    public static bool gamePaused = false;

    // pause/resume the game based on current status
    
    public static void togglePause(){
        gamePaused = !gamePaused;
    }
}


