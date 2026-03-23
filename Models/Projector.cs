namespace APBD_TASK2.Models
{
    public class Projector : Equipment
    {
        public int Lumens { get; set; }
        public bool Is4K { get; set; }

        public Projector(string name, int lumens, bool is4K) : base(name)
        {
            Lumens = lumens;
            Is4K = is4K;
        }
    }
}