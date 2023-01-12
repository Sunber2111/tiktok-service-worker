using Application.Posts.DTO;
using Common.Kafka;

namespace Application.Posts
{
    public interface IPostService
    {
        Task HandleResolvePost(KafkaMessage<PostDTO> message);
    }
}

