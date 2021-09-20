using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewProjectInputModel projectInputModel)
        {
            var project = new Project(projectInputModel.Title, projectInputModel.Description, projectInputModel.IdClient, projectInputModel.IdFreelancer, projectInputModel.TotalCost);
            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel createCommentInputModel)
        {
            var comment = new ProjectComment(createCommentInputModel.Content, createCommentInputModel.IdUser, createCommentInputModel.IdProject);
            _dbContext.ProjectComments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);

            project.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;
            var projectViewModel = projects
                .Select(p => new ProjectViewModel(p.Title, p.CreatedAt)).ToList();

            return projectViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            var projectDetailsViewModel = new ProjectDetailsViewModel(
                    project.Id,
                    project.Title,
                    project.Description,
                    project.TotalCost,
                    project.CreatedAt,
                    project.FinishedAt
                );
            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);

            project.Start();
        }

        public void Update(UpdateProjectInputModel updateProjectInputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == updateProjectInputModel.Id);
            project.Update(updateProjectInputModel.Title, updateProjectInputModel.Description, updateProjectInputModel.TotalCost);
        }
    }
}
