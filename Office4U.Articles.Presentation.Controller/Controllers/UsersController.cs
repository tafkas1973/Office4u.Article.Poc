using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Office4U.Articles.Common;
using Office4U.Articles.Data.Ef.SqlServer.Interfaces;
using Office4U.Articles.Domain.Model.Entities;
using Office4U.Articles.ImportExport.Api.Controllers.DTOs.AppUser;
using Office4U.Articles.ImportExport.Api.Extensions;

namespace Office4U.Articles.ImportExport.Api.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsersController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync(
            [FromQuery] UserParams userParams)
        {
            var users = await _unitOfWork.UserRepository.GetUsersAsync(userParams);

            var usersToReturn = _mapper.Map<IEnumerable<AppUserDto>>(users);

            // users is of type PagedList<User>
            // inherits List, so it's a List<Users> plus Pagination info
            Response.AddPaginationHeader(
                users.CurrentPage,
                users.PageSize,
                users.TotalCount,
                users.TotalPages
            );

            return Ok(usersToReturn);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<AppUserDto>> GetUser(string username)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);

            var userToReturn = _mapper.Map<AppUserDto>(user);

            return userToReturn;
        }
    }
}