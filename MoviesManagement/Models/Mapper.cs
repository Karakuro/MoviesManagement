using MoviesManagement.Data;

namespace MoviesManagement.Models
{
    public class Mapper
    {
        #region MapEntityToModel

        public EmployeeModel MapEntityToModel(Employee entity)
        {
            EmployeeModel model = new EmployeeModel()
            {
                Id = entity.EmployeeId,
                Name = entity.Name,
                Surname = entity.Surname,
                IsDeleted = entity.IsDeleted
            };

            return model;
        }

        public MovieModel MapEntityToModel(Movie entity)
        {
            MovieModel model = new MovieModel()
            {
                Id = entity.MovieId,
                Title = entity.Title,
                AgeLimitId = entity.AgeLimitId,
                AgeLimit = entity.AgeLimit?.Description,
                DurationMins = entity.DurationMins,
                ImdbId = entity.ImdbId,
                IsDeleted = entity.IsDeleted,
                Technologies = entity.Technologies?.ConvertAll(MapEntityToModel),
                Projections = entity.Projections?.ConvertAll(MapEntityToModel)
            };
            return model;
        }

        public MovieProjectionModel MapEntityToModel(Projection entity)
        {
            MovieProjectionModel model = new MovieProjectionModel()
            {
                Id = entity.ProjectionId,
                FreeBy = entity.FreeBy,
                Start = entity.Start,
                RoomId = entity.RoomId,
                IsDeleted = entity.IsDeleted,
                RoomName = entity.Room?.Name
            };
            return model;
        }

        public ProjectionModel MapEntityToFullModel(Projection entity)
        {
            throw new NotImplementedException();
        }

        public ItemModel MapEntityToModel(Technology entity)
        {
            ItemModel model = new ItemModel()
            {
                Id = entity.TechnologyId,
                Name = entity.Name,
                Description = entity.TechnologyType
            };
            return model;
        }

        #endregion

        #region MapModelToEntity

        public Employee MapModelToEntity(EmployeeModel model)
        {
            Employee entity = new Employee()
            {
                EmployeeId = model.Id,
                Name = model.Name,
                Surname = model.Surname
            };

            return entity;
        }

        #endregion
    }
}
