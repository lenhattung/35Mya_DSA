record Ticket(int Id, string Customer, string Issue, DateTime Created);

namespace Lab03._Queue
{
    public class TicketSystem
    {
        private Queue<Ticket> _queue = new Queue<Ticket>();
        private int _nextId = 1;

        public void Submit(string customer, string issue)
        {
            var t = new Ticket(_nextId++, customer, issue, DateTime.Now);
            _queue.Enqueue(t);
            Console.WriteLine($"  [SUBMITTED]  #{t.Id:D3}  {customer}  — {issue}");
        }

        public void ProcessNext()
        {
            if (!_queue.TryDequeue(out Ticket t))
            {
                Console.WriteLine("  No tickets in queue.");
                return;
            }
            Console.WriteLine($"  [PROCESSING] #{t.Id:D3}  {t.Customer}  — {t.Issue}");
        }
        public void ShowQueue()
        {
            if (_queue.Count == 0) { Console.WriteLine("  Queue is empty."); return; }
            Console.WriteLine($"  Pending tickets ({_queue.Count}):");
            int pos = 1;
            foreach (Ticket t in _queue)
                Console.WriteLine($"    {pos++}. #{t.Id:D3}  {t.Customer}  — {t.Issue}");
        }

        public void ShowNext()
        {
            if (_queue.TryPeek(out Ticket t))
                Console.WriteLine($"  Next up: #{t.Id:D3}  {t.Customer}");
            else
                Console.WriteLine("  Queue is empty.");
        }
    }

}
