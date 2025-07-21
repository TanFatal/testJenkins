using back_end.Models;

namespace back_end.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(TaiKhoan taikhoan);
    }
}
