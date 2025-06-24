namespace investmentsManagement.Server.Data.Models.ViewModels
{
    public class ProjectsDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectType { get; set; }
        /// <summary>
        /// In Marla
        /// </summary>
        public int Size { get; set; }
    }
}
