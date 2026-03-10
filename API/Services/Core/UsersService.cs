using API.DAL.Interfaces;
using API.Models.Core;
using API.Services.Interfaces;


namespace API.Services.Core
{
    public class UsersService: IUsersService
    {
        private readonly IUsersDAL _userDAL;
        private readonly IAuthDAL _authDAL;
        public UsersService(IUsersDAL userDAL, IAuthDAL authDAL) 
        {
            _userDAL = userDAL;
            _authDAL = authDAL;
        }

        public async Task<List<Users>> GetUsersData(FilterData filterData)
        {
            try
            {
                var response = await _userDAL.GetUsersData(filterData);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// This service method to insert user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Response> InsertUser(UsersDto user)
        {
            try
            {
                var response = new Response();
                // Convert plain password into hash + salt
                _authDAL.CreatePasswordHash(user.Password, out byte[] hash, out byte[] salt);

                user.PasswordHash = hash;
                user.PasswordSalt = salt;

                user.Password = null;
                response = await _userDAL.InsertUser(user);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> GetById(Guid RecordId)
        {
            try
            {
                var response = await _userDAL.GetById(RecordId);
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
