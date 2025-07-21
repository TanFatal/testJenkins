using back_end.DataAccess;
using back_end.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    public class CommentController : BaseApiController
    {
        private IRepository repo;

        public CommentController(IRepository repo)
        {
            this.repo = repo;
        }


        [HttpPost("[action]/{productId}/{personId}")]   //api/comment/AddComment/{productId}/{personId}
        public async Task<ActionResult<CommentDTO>> AddComment(CommentDTO commentDTO,string productId,string personId)
        {
            var commentDtoToReturn = await repo.AddCommentAsync(commentDTO, productId, personId);  


            return Ok(commentDtoToReturn);
        }

    }
}
