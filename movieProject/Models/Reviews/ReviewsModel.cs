namespace movieProject.Models.Reviews
{
    public class Reviews
    {
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public string Reviewer { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
