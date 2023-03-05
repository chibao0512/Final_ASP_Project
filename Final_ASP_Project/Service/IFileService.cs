namespace Final_ASP_Project.Service
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imgFile);
        public bool Delete(string imgFile);
    }
}
