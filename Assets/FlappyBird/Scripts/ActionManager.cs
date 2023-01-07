using System;

// Statyczna klasa jest ograniczeniem, które wyamga by każda zmienna i funkcja była statyczna
public static class ActionManager
{
    // Action to specjalny typ który trzyma referencję do innych funkcji
    // public static daja łatwy dostęp innym klasom do podpięcia swoich funkcji które majasię wywołać na koniec gry
    // event jest za to ograniczeniem - to znaczy że pomimo tego że Action jest dostepne publicznie, to tylko ta klasa może go wywołać
    public static event Action OnGameOver;
    
    public static event Action OnGameStart;

    public static void GameStart()
    {
        OnGameOver?.Invoke();
        OnGameStart?.Invoke();
    }
    
    public static void GameOver()
    {
        // Znak zapytania sprawia że Invoke jest wywołane tylko jeśli jakikolwiek inny skrypt się podpiął
        // Bez znaku zapytania wywołanie Invoke na OnGame Over mogłboy wyrzucić błąd
        OnGameOver?.Invoke();

        OnGameOver = null;
    }
}
