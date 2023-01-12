using Application.Posts.DTO;
using AutoMapper;
using Common.Kafka;
using Domain;
using Infrastructure.Elastic;
using Nest;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Posts
{
    public class PostService : IPostService
    {
        private readonly ElasticClient _client;
        private readonly IMapper _mapper;

        public PostService(ElasticClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task HandleResolvePost(KafkaMessage<PostDTO> message)
        {
            var postDto = message.Payload.After;

            if (postDto != null)
            {
                var result = await _client.GetAsync<Post>(postDto.Id, x => x.Index(ElasticIndex.Post));

                if (result?.Source == null)
                {
                    // Insert
                    var post = _mapper.Map<Post>(postDto);
                    await _client.IndexAsync(post, request => request.Index(ElasticIndex.Post));
                }
                else
                {
                    // Update
                    var post = result.Source;
                    post = _mapper.Map<Post>(postDto);
                    await _client.UpdateAsync<Post>(post.Id, u => u.Index(ElasticIndex.Post).Doc(post));
                }
            }
            else
            {
                // Delete
                await _client.DeleteAsync(DocumentPath<Post>.Id(message.Payload.Before?.Id).Index(ElasticIndex.Post));
            }
        }
    }
}

