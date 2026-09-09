namespace Lab03_Stack
{
    class TextEditor
    {
        private string _current = "";
        private Stack<string> _undo = new Stack<string>();
        private Stack<string> _redo = new Stack<string>();

        public void Type(string text)
        {
            _undo.Push(_current);   // save current state before changing
            _current += text;
            _redo.Clear();          // any new action clears redo history
            Console.WriteLine($"  [TYPE]  Content: \"{_current}\"");
        }

        public void Undo()
        {
            if (!_undo.TryPop(out string prev))
            { Console.WriteLine("  [UNDO]  Nothing to undo."); return; }
            _redo.Push(_current);   // save current so redo can restore it
            _current = prev;
            Console.WriteLine($"  [UNDO]  Content: \"{_current}\"");
        }

        public void Redo()
        {
            if (!_redo.TryPop(out string next))
            { Console.WriteLine("  [REDO]  Nothing to redo."); return; }
            _undo.Push(_current);
            _current = next;
            Console.WriteLine($"  [REDO]  Content: \"{_current}\"");
        }

        public void Status()
        {
            Console.WriteLine($"  [INFO]  Current: \"{_current}\"  " +
                              $"| Undo stack: {_undo.Count}  " +
                              $"| Redo stack: {_redo.Count}");
        }
    }

}
