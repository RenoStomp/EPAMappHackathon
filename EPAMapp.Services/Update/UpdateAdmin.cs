using EPAMapp.Domain.Models.Entities;
using EPAMapp.Services.DTO.Update;

namespace EPAMapp.Services.Update
{
    public static class UpdateAdmin
    {
        public static async Task Update(Admin admin, DTOUpdateAdmin adminModel)
        {
            admin.Name = adminModel.Name;
            admin.Surname = adminModel.Surname;
            admin.Email = adminModel.Email;
            admin.Password = adminModel.Password;
            admin.NickName = adminModel.NickName;
        }
    }
}
