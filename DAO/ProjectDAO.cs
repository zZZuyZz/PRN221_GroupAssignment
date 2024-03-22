using BO.Models;

namespace DAO
{
    public class ProjectDAO
    {
        private readonly RealEstateManagementContext _context = new();

        private static ProjectDAO _instance = new();

        public static ProjectDAO Instance
        {
            get
            {
                _instance ??= new ProjectDAO();
                return _instance;
            }
        }

        public Project? GetById(Guid id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id.Equals(id));
        }
        public List<Project>? GetByProjectTitle(string name)
        {
            return _context.Projects.Where(p => p.ProjectTitle.Contains(name)).ToList();
        }
        public bool CreateProject(Project? booking)
        {
            bool result = false;
            try
            {
                _context.Projects.Add(booking);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
        public bool ApproveProject(Guid id)
        {
            bool result = false;
            try
            {
                var existingProject = _context.Projects.Find(id);
                if (existingProject == null)
                {
                    // Xử lý trường hợp dự án không tồn tại
                    return false;
                }

                // Cập nhật chỉ các thuộc tính cần thay đổi
                existingProject.ProjectStatus = "Đã duyệt";
                existingProject.StartDate = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
        public List<Project>? GetProjects()
        {
            return _context.Projects.ToList();
        }
        public List<Project>? GetProjectsByStatus()
        { 
            return _context.Projects.Where(x => x.ProjectStatus == "Đã duyệt").ToList();
        }
        public List<Project>? GetProjectsByInvestorId(Guid id)
        {
            return _context.Projects.Where(x => x.Id == id).ToList();
        }
    }
}
