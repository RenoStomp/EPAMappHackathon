using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.DTO.Update;

namespace EPAMapp.Services.Update
{
    public static class UpdateUser
    {


        public static async Task Update(User user, DTOUpdateUser userModel)
        {
            user.Name = userModel.Name;
            user.Surname = userModel.Surname;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
        }
    }
}
