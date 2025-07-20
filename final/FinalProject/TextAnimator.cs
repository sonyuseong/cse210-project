using System;
using System.Threading;

class TextAnimator {
    public static void Show(string text, int delay = 30) {
        foreach (char c in text) {
            Console.Write(c);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
    }
}
