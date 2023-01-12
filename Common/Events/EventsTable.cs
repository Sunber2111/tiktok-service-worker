using Common.Utils;

namespace Common.Events
{
    public static class EventsTable
    {
        public static string Posts => "posts".GenerateTopic();

        public static string UsersLikePosts => "users_like_posts".GenerateTopic();

        public static string UsersCommentPosts => "users_comment_posts".GenerateTopic();

        public static string UsersSharePosts => "users_share_posts".GenerateTopic();
    }
}

