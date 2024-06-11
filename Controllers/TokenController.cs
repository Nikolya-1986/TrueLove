using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Love.DbContext;
using Love.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Love.Controllers
{
    public class TokenController
    {
        private readonly TokenService _tokenService;
        private readonly TrueLoveDbContext _DbContext;
        private string userName;

        public TokenController(TokenService tokenService, TrueLoveDbContext DbContext)
        {
            _tokenService = tokenService;
            _DbContext = DbContext;
        }
        
        [HttpPost]
        public async Task<IActionResult> Refresh(string token, string refreshToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token);
            userName = principal.Identity.Name; //this is mapped to the Name claim by default

            var user = _DbContext.MainUserInfo.SingleOrDefault(item => item.userName == userName);
            if (user == null || user.RefreshToken != refreshToken) return BadRequest();

            var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _DbContext.SaveChangesAsync();

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Revoke()
        {
            // var userName = User.Identity.Name;

            var user = _DbContext.MainUserInfo.SingleOrDefault(item => item.userName == userName);
            if (user == null) return BadRequest();

            user.RefreshToken = null;

            await _DbContext.SaveChangesAsync();

            return NoContent();
        }

        private IActionResult NoContent()
        {
            throw new NotImplementedException();
        }

        private IActionResult BadRequest()
        {
            throw new NotImplementedException();
        }
    }
}