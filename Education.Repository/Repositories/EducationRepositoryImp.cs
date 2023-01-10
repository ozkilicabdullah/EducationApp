using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Education.Repository.Repositories
{
    public class EducationRepositoryImp : GenericRepository<Core.Models.Education>, IEducationRepository
    {
        public EducationRepositoryImp(EducationDbContext context) : base(context)
        {
        }
        /// <summary>
        /// Kullanıcıya atana eğitimleri döner
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<GetMyAssignedEducationDto>> GetMyAssignedEducations(int userId)
        {
            List<GetMyAssignedEducationDto> responseModel = new();
            var param = new SqlParameter("@userId", userId);
            var connection = (SqlConnection)_context.Database.GetDbConnection();
            await connection.OpenAsync();

            using (var command = connection.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAssignedEducationForUser";
                command.Parameters.Add(param);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GetMyAssignedEducationDto item = new();
                    item.EducationId = Convert.ToInt32(reader["EducationId"].ToString());
                    item.AssignedEducationStatus = (UserEducationStatus)Convert.ToInt32(reader["AssignedEducationStatus"].ToString());
                    item.EducationCategoryName = reader["EducationCategoryName"].ToString();
                    item.Title = reader["Tittle"].ToString();
                    item.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    item.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    item.EducationTime = Convert.ToInt32(reader["EducationTime"].ToString());
                    item.Description = reader["Description"].ToString();
                    item.Educator = reader["Educator"].ToString();
                    item.EducationType = (EducationType)Convert.ToInt32(reader["EducationType"].ToString());
                    responseModel.Add(item);
                }
            }
            await connection.CloseAsync();

            return responseModel;
        }
    }
}
