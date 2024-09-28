namespace Api.Responses
{
    public class SingleQuizResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int PointRewards { get; set; }
        public List<int> questionsIds { get; set; }
    }
}
