using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Model;

namespace WebAPI.Service
{
    public class TokenService
    {
        public static object GenerateToken(Fornecedor fornecedor)
        {
            //buscando a chave
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            //Definindo a configuração do token
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    //adicionando o id do fornecedor
                    new Claim("fornecedorId", fornecedor.id.ToString()),
                }),
                //tempo maximo ate expeirar o token
                Expires = DateTime.UtcNow.AddHours(3),
                //configuraçoes JWT
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            //criando o token
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString
            };
        }
    }
}
