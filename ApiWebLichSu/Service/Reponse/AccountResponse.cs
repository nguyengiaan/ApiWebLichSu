using ApiWebLichSu.Data;
using ApiWebLichSu.Helpers;
using ApiWebLichSu.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiWebLichSu.Service.Interface;
using ApiWebLichSu.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApiWebLichSu.Service
{
    public class AccountResponse : IAccountReponse
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly MyDbcontext _context;

        public AccountResponse(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager,IConfiguration configuration,RoleManager<IdentityRole> roleManager,MyDbcontext context)
        { 
            this.userManager=userManager;
            this.signInManager=signInManager;
            this.configuration=configuration;
            this.roleManager = roleManager;
            _context=context;
        }
        public async Task<string> SignInAsync(SignIn model)
        {
            var name = await userManager.FindByNameAsync(model.Email);
            var user=await userManager.FindByEmailAsync(model.Email);
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !passwordValid) 
            {
                return string.Empty;
            }
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return String.Empty;
            }
            var userid = await userManager.FindByEmailAsync(model.Email);
            if (userid == null)
            {
                return String.Empty;
            }
            var userId = await userManager.GetUserIdAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name,name.LastName),
                new Claim("UserId", user.Id)
            };
            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles) 
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                    issuer: configuration["JWT:ValidIssuer"],
                    audience: configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(20),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                ); ;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUp mode)
        {
            var user = new ApplicationUser
            {
                FirstName = mode.FirstName,
                LastName = mode.LastName,
                Email= mode.Email,
                UserName=mode.Email,
            };
            var result =await userManager.CreateAsync(user,mode.Password);
            if(result.Succeeded) 
            {
                // kiểm tra role Customer đã có
                if(!await roleManager.RoleExistsAsync(AppRole.Customer))
                {
                    await roleManager.CreateAsync(new IdentityRole(AppRole.Customer));
                }
                await userManager.AddToRoleAsync(user, AppRole.Customer);
            }
            return result;
        }

        public async Task<IdentityResult> SignUpAsyncAdmin(SignUp mode)
        {
            var user = new ApplicationUser
            {
                FirstName = mode.FirstName,
                LastName = mode.LastName,
                Email = mode.Email,
                UserName = mode.Email,
            };
            var result = await userManager.CreateAsync(user, mode.Password);
            if (result.Succeeded)
            {
                // kiểm tra role Customer đã có
                if (!await roleManager.RoleExistsAsync(AppRole.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(AppRole.Admin));
                }
                await userManager.AddToRoleAsync(user, AppRole.Admin);
            }
            return result;
        }
        public async Task<List<AccountVM>> GetUserAsp()
        {
            try
            {
                var account = new List<AccountVM>();
                var data=await  _context.Appuser.FromSqlRaw("EXECUTE GETUSERASP").ToListAsync();
                account = data.Select(user => new AccountVM
                {
                    Id = user.Id,
                    LastName = user.LastName,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash
                }).ToList();
                return (account);
            }
            catch (Exception ex) 
            {
                return new List<AccountVM>();
            }
        }

    }
}
