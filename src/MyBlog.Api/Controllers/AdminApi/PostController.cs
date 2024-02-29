using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBlog.Core.Domain.Content;
using MyBlog.Core.Models;
using MyBlog.Core.Models.Content;
using MyBlog.Core.SeeWorks;

namespace MyBlog.Api.Controllers.AdminApi
{
    [Route("api/admin/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreateUpdatePostRequest request)
        {
            var post = _mapper.Map<CreateUpdatePostRequest, Post>(request);
            _unitOfWork.Posts.Add(post);
            var result = await _unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(Guid id,[FromBody] CreateUpdatePostRequest request)
        {
            var post=_unitOfWork.Posts.GetByIdAsync(id);
            if (post==null)
            {
                return NotFound();
            }
            _mapper.Map(post, request);
            var result=await _unitOfWork.CompleteAsync();
            return result>0?Ok() : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePosts([FromQuery] Guid[] ids)
        {
            foreach (var id in ids)
            {
                var post = await _unitOfWork.Posts.GetByIdAsync(id);
                if (post==null)
                {
                    return NotFound();
                }
                _unitOfWork.Posts.Remove(post);
            }
            var result=await _unitOfWork.CompleteAsync();
            return result >0 ? Ok() : BadRequest();
            
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(Guid id)
        {
            var post=await _unitOfWork.Posts.GetByIdAsync(id);
            if (post==null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpGet]
        [Route("paging")]
        public async Task<ActionResult<PagedResult<PostInListDto>>> GetPostsPaging(string? keywork, Guid categotyId,int pageIndex, int pageSize=10)
        {
            var result = await _unitOfWork.Posts.GetPostPagingAsync(keywork, categotyId, pageIndex, pageSize);
            return Ok(result);

        }
    }
}
